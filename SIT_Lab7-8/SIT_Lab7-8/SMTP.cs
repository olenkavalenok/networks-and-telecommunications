using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace SIT_Lab7_8
{
    public partial class SMTP : Form
    {
        public SMTP()
        {
            InitializeComponent();
        }

        public async Task sendEmail()
        {
            MailAddress from = new MailAddress("olgazilen0101@gmail.com", "Olga Zhilenkova");
            MailAddress to = new MailAddress(recipient.Text);
            MailMessage mess = new MailMessage(from, to);
            mess.Subject = topic.Text;
            mess.Body = message.Text;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("olgazilen0101@gmail.com", "olgazilen1213");
            smtpClient.EnableSsl = true;
            await smtpClient.SendMailAsync(mess);
            MessageBox.Show("Письмо отправлено");
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
            this.Hide();
            pop3.Show();
            
        }

        private void send_Click(object sender, EventArgs e)
        {
            sendEmail();
        }
    }
}
