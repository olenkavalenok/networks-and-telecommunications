using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPop.Mime;
using OpenPop.Pop3;

namespace SIT_Lab7_8
{
    public partial class POP3 : Form
    {
        public POP3()
        {
            InitializeComponent();
            OpenPop.Pop3.Pop3Client client = new OpenPop.Pop3.Pop3Client();
            
            client.Connect("pop.gmail.com", 995, true);
            client.Authenticate("barsik.404.error@gmail.com", "OlgaZilen1213");

            var count = client.GetMessageCount();
            for (int i = 1; i <= count; i++)
            {
                OpenPop.Mime.Message message = client.GetMessage(i);
                string topic = message.Headers.Subject;// заголовок
                string from = message.Headers.From.ToString();//от кого
                string date = message.Headers.DateSent.ToString();//Дата/Время

                string body = message.MessagePart.GetBodyAsText();

                dataGridView1.Rows.Add(from, topic, date, body);
            }
        }

        private void sendMessage_Click(object sender, EventArgs e)
        {
            SMTP smtp = new SMTP();
            smtp.Show();
            this.Hide();
        }

        private void incMessages_Click(object sender, EventArgs e)
        {
            POP3 pop3 = new POP3();
            pop3.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                messText.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }
    }
}
