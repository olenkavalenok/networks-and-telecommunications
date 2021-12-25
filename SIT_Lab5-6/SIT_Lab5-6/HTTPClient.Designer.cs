namespace SIT_Lab5_6
{
    partial class HTTPClient
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.toFtpClient = new System.Windows.Forms.Button();
            this.toHttpClient = new System.Windows.Forms.Button();
            this.httpAddress = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.Button();
            this.httpResult = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.toFtpClient);
            this.panel1.Controls.Add(this.toHttpClient);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 450);
            this.panel1.TabIndex = 0;
            // 
            // toFtpClient
            // 
            this.toFtpClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toFtpClient.Location = new System.Drawing.Point(3, 70);
            this.toFtpClient.Name = "toFtpClient";
            this.toFtpClient.Size = new System.Drawing.Size(213, 46);
            this.toFtpClient.TabIndex = 1;
            this.toFtpClient.Text = "FTP клиент";
            this.toFtpClient.UseVisualStyleBackColor = true;
            this.toFtpClient.Click += new System.EventHandler(this.toFtpClient_Click);
            // 
            // toHttpClient
            // 
            this.toHttpClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toHttpClient.Location = new System.Drawing.Point(3, 11);
            this.toHttpClient.Name = "toHttpClient";
            this.toHttpClient.Size = new System.Drawing.Size(213, 46);
            this.toHttpClient.TabIndex = 0;
            this.toHttpClient.Text = "HTTP клиент";
            this.toHttpClient.UseVisualStyleBackColor = true;
            this.toHttpClient.Click += new System.EventHandler(this.toHttpClient_Click);
            // 
            // httpAddress
            // 
            this.httpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.httpAddress.Location = new System.Drawing.Point(228, 13);
            this.httpAddress.Name = "httpAddress";
            this.httpAddress.Size = new System.Drawing.Size(407, 41);
            this.httpAddress.TabIndex = 1;
            // 
            // send
            // 
            this.send.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.send.Location = new System.Drawing.Point(642, 11);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(146, 47);
            this.send.TabIndex = 2;
            this.send.Text = "Отправить";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // httpResult
            // 
            this.httpResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.httpResult.Location = new System.Drawing.Point(228, 71);
            this.httpResult.Multiline = true;
            this.httpResult.Name = "httpResult";
            this.httpResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.httpResult.Size = new System.Drawing.Size(560, 367);
            this.httpResult.TabIndex = 3;
            // 
            // HTTPClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.httpResult);
            this.Controls.Add(this.send);
            this.Controls.Add(this.httpAddress);
            this.Controls.Add(this.panel1);
            this.Name = "HTTPClient";
            this.Text = "HTTPClient";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button toFtpClient;
        private System.Windows.Forms.Button toHttpClient;
        private System.Windows.Forms.TextBox httpAddress;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox httpResult;
    }
}

