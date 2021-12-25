using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace SIT_Lab5_6
{
    public partial class HTTPClient : Form
    {
        public HTTPClient()
        {
            InitializeComponent();
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

        private void send_Click(object sender, EventArgs e)
        {
            string uri = httpAddress.Text;
            if (!string.IsNullOrEmpty(uri))
            {
                try
                {
                    HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
                    request.Method = "GET";
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    string encoding = "utf-8";
                    string ct = response.Headers["Content-Type"];
                    if (ct != null)
                        encoding = ct.Substring(ct.IndexOf("charset=") + 8);
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
                    httpResult.Text = reader.ReadToEnd();
                    reader.Close();
                }
                catch
                {
                    httpResult.Text = "Ошибка. Неверный запрос";
                }

            }
            else
                MessageBox.Show("Введите запрос");
        }
    }
}
