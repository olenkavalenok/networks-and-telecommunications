namespace SIT_Lab7_8
{
    partial class SMTP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.recipient = new System.Windows.Forms.TextBox();
            this.recpLabel = new System.Windows.Forms.Label();
            this.topicLabel = new System.Windows.Forms.Label();
            this.topic = new System.Windows.Forms.TextBox();
            this.message = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.Button();
            this.sendMessage = new System.Windows.Forms.Button();
            this.incMessages = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.incMessages);
            this.panel1.Controls.Add(this.sendMessage);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 450);
            this.panel1.TabIndex = 0;
            // 
            // recipient
            // 
            this.recipient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recipient.Location = new System.Drawing.Point(318, 34);
            this.recipient.Name = "recipient";
            this.recipient.Size = new System.Drawing.Size(427, 28);
            this.recipient.TabIndex = 1;
            // 
            // recpLabel
            // 
            this.recpLabel.AutoSize = true;
            this.recpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recpLabel.Location = new System.Drawing.Point(257, 32);
            this.recpLabel.Name = "recpLabel";
            this.recpLabel.Size = new System.Drawing.Size(55, 24);
            this.recpLabel.TabIndex = 2;
            this.recpLabel.Text = "Кому";
            // 
            // topicLabel
            // 
            this.topicLabel.AutoSize = true;
            this.topicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.topicLabel.Location = new System.Drawing.Point(257, 89);
            this.topicLabel.Name = "topicLabel";
            this.topicLabel.Size = new System.Drawing.Size(56, 24);
            this.topicLabel.TabIndex = 3;
            this.topicLabel.Text = "Тема";
            // 
            // topic
            // 
            this.topic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.topic.Location = new System.Drawing.Point(319, 91);
            this.topic.Name = "topic";
            this.topic.Size = new System.Drawing.Size(426, 28);
            this.topic.TabIndex = 4;
            // 
            // message
            // 
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.message.Location = new System.Drawing.Point(261, 146);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(484, 209);
            this.message.TabIndex = 5;
            // 
            // send
            // 
            this.send.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.send.Location = new System.Drawing.Point(261, 376);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(157, 47);
            this.send.TabIndex = 6;
            this.send.Text = "Отправить";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // sendMessage
            // 
            this.sendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendMessage.Location = new System.Drawing.Point(3, 21);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(204, 52);
            this.sendMessage.TabIndex = 2;
            this.sendMessage.Text = "Отправить письмо";
            this.sendMessage.UseVisualStyleBackColor = true;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // incMessages
            // 
            this.incMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.incMessages.Location = new System.Drawing.Point(3, 88);
            this.incMessages.Name = "incMessages";
            this.incMessages.Size = new System.Drawing.Size(204, 66);
            this.incMessages.TabIndex = 3;
            this.incMessages.Text = "Входящие сообщения";
            this.incMessages.UseVisualStyleBackColor = true;
            this.incMessages.Click += new System.EventHandler(this.incMessages_Click);
            // 
            // SMTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.send);
            this.Controls.Add(this.message);
            this.Controls.Add(this.topic);
            this.Controls.Add(this.topicLabel);
            this.Controls.Add(this.recpLabel);
            this.Controls.Add(this.recipient);
            this.Controls.Add(this.panel1);
            this.Name = "SMTP";
            this.Text = "SMTP";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox recipient;
        private System.Windows.Forms.Label recpLabel;
        private System.Windows.Forms.Label topicLabel;
        private System.Windows.Forms.TextBox topic;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.Button incMessages;
    }
}