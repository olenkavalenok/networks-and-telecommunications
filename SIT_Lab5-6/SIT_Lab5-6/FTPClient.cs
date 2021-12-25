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
using System.IO;

namespace SIT_Lab5_6
{
    public partial class FTPClient : Form
    {
        private string fileName;
        private static string server = "ftp://<IPv4-адрес>/";

        public FTPClient()
        {
            InitializeComponent();
            downloadFileLabel.Text = downloadFileLabel.Text + server;
        }

        private void toHttpClient_Click(object sender, EventArgs e)
        {
            HTTPClient httpClient = new HTTPClient();
            httpClient.Show();
            this.Hide();
        }

        private void toFtpClient_Click(object sender, EventArgs e)
        {
            FTPClient ftpClient = new FTPClient();
            ftpClient.Show();
            this.Hide();
        }

        private void selectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog ofd = new FolderBrowserDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = ofd.SelectedPath;
                    downloadFolderPath.Text = selectedPath;
                }
            }
        }

        private void download_Click(object sender, EventArgs e)
        {
            ftpResult.Text = DateTime.Now.ToString("HH:mm:ss.fff") + " Начало загрузки\r\n";
            fileName = downloadFileName.Text;

            if (fileName == "")
                MessageBox.Show("Введите название файла");
            else
            {
                if (downloadFolderPath.Text == "")
                    MessageBox.Show("Выберите папку");
                else
                {
                    try
                    {
                        ftpResult.Text = ftpResult.Text + DateTime.Now.ToString("HH:mm:ss.fff") + " Соединение ...\r\n";
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server + fileName);
                        request.Method = WebRequestMethods.Ftp.DownloadFile;

                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                        ftpResult.Text = ftpResult.Text + DateTime.Now.ToString("HH:mm:ss.fff") + " Получен ответ от сервера\r\n";
                        Stream responseStream = response.GetResponseStream();
                        ftpResult.Text = ftpResult.Text + DateTime.Now.ToString("HH:mm:ss.fff") + " Получены данные с сервера\r\n";
                        ftpResult.Text = ftpResult.Text + DateTime.Now.ToString("HH:mm:ss.fff") + " Копирование файла ...\r\n";

                        FileStream fs = new FileStream(downloadFolderPath.Text + "\\" + fileName, FileMode.Create);
                        ftpResult.Text = ftpResult.Text + DateTime.Now.ToString("HH:mm:ss.fff") + " Создан поток для сохранения\r\n";
                        ftpResult.Text = ftpResult.Text + DateTime.Now.ToString("HH:mm:ss.fff") + " Чтение данных ...\r\n";
                        byte[] buffer = new byte[64];
                        int size = 0;
                        while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                            fs.Write(buffer, 0, size);
                        fs.Close();
                        response.Close();
                        ftpResult.Text = ftpResult.Text + DateTime.Now.ToString("HH:mm:ss.fff") + " Загрузка завершена\r\n";
                        MessageBox.Show("Загрузка завершена");
                        downloadFolderPath.Text = "";
                    }
                    catch
                    {
                        ftpResult.Text = ftpResult.Text + "Ошибка в загрузке файла\r\n";
                    }
                }
            }
        }
    }
}
