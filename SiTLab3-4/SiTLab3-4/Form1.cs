using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace SiTLab3_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxIPTo.Text == "")
            {
                richTextBox1.Text += "Введите IP-адрес\n";
                return;
            }

            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);

                byte[] icmpData = new byte[1024]; // данные
                int bytes;

                IPAddress ipFrom = IPAddress.Parse(textBoxIPTo.Text); // адрес отправителя
                IPAddress ipTo = IPAddress.Parse(textBoxIPTo.Text); // адрес приемника
                IPEndPoint ipEndPoint = new IPEndPoint(ipFrom, 0);
                EndPoint endPoint = (EndPoint)ipEndPoint; // сетевой адрес
                ICMP icmp = new ICMP();
                icmp.type = (byte)Convert.ToInt32(textBoxType.Text);
                icmp.code = (byte)Convert.ToInt32(textBoxCode.Text);
                icmp.checksum = 0;

                //Отправление сообщения
                ///////////////////////

                icmpData = Encoding.ASCII.GetBytes("Hello!"); // данные переводим в байты
                Buffer.BlockCopy(icmpData, 0, icmp.message, 4, icmpData.Length); // помещаем в message сообщение (4 байта оставляем для ICMP-заголовка)
                icmp.size = icmpData.Length + 4;
                int sizePacket = icmp.size + 4; // 4 байта резервных
                UInt16 checksum = icmp.getChecksum(); // контрольная сумма
                icmp.checksum = checksum;
                socket.SendTo(icmp.getData(), sizePacket, SocketFlags.None, ipEndPoint);

                //Приём сообщения
                ///////////////////////

                icmpData = new byte[1024];
                bytes = socket.ReceiveFrom(icmpData, ref endPoint); // к-во считанных байтов (принимаем данные в буфер данных и сохраняем конечную точку)
                ICMP response = new ICMP(icmpData, bytes);
                richTextBox1.Text += "\nОтвет от: " + endPoint.ToString();

                string result = Encoding.ASCII.GetString(response.message, 4, response.size - 4); // декодируем данные (4 байта резервных)
                richTextBox1.Text += "\nСообщение: " + result;

                socket.Close();
            }
            catch (SocketException exc)
            {
                richTextBox1.Text += "\n" + exc.Message + "\n";
            }
            catch (FormatException exc)
            {
                richTextBox1.Text += "\n" + exc.Message + "\n";
            }
        }
    }

    public class ICMP
    {
        public byte type; // тип
        public byte code; // код
        public UInt16 checksum; // контрольная сумма
        public int size; // размер сообщение
        public byte[] message = new byte[1024]; // сообщение

        public ICMP()
        {}

        public ICMP(byte[] data, int size)
        {
            // с [0] по [19] - байты для IP-заголовка
            type = data[20]; // тип
            code = data[21]; // код
            checksum = BitConverter.ToUInt16(data, 22); // контрольная сумма
            this.size = size - 24; // 20 байтов для IP-заголовка, 4 байта ICMP-заголовка
            Buffer.BlockCopy(data, 24, message, 0, this.size);
        }

        public byte[] getData()
        {
            // помещаем данные (тип, код, контрольную сумму, сообщение) в массив buffer
            byte[] icmpData = new byte[size + 8];
            Buffer.BlockCopy(BitConverter.GetBytes(type), 0, icmpData, 0, 1); // тип
            Buffer.BlockCopy(BitConverter.GetBytes(code), 0, icmpData, 1, 1);  // код
            Buffer.BlockCopy(BitConverter.GetBytes(checksum), 0, icmpData, 2, 2); // контрольная сумма
            Buffer.BlockCopy(message, 0, icmpData, 4, size); // сообщение
            return icmpData;
        }

        // контрольная сумма
        public UInt16 getChecksum()
        {
            UInt32 crc = 0;
            byte[] buffer = getData();
            int sizePacket = size + 8;
            int index = 0;

            while (index < sizePacket)
            {
                crc += Convert.ToUInt32(BitConverter.ToUInt16(buffer, index));
                index += sizeof(short);
            }
            crc = (crc >> 16) + (crc & 0xffff);
            crc += (crc >> 16);

            return (UInt16)(~crc);
        }
    }
}
