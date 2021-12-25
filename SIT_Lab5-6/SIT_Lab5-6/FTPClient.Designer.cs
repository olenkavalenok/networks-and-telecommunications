namespace SIT_Lab5_6
{
    partial class FTPClient
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
            this.toHttpClient = new System.Windows.Forms.Button();
            this.toFtpClient = new System.Windows.Forms.Button();
            this.downloadFileName = new System.Windows.Forms.TextBox();
            this.downloadFileLabel = new System.Windows.Forms.Label();
            this.downloadFolderPath = new System.Windows.Forms.TextBox();
            this.downloadFolderLabel = new System.Windows.Forms.Label();
            this.ftpResult = new System.Windows.Forms.TextBox();
            this.selectFolder = new System.Windows.Forms.Button();
            this.download = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.toHttpClient);
            this.panel1.Controls.Add(this.toFtpClient);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 450);
            this.panel1.TabIndex = 0;
            // 
            // toHttpClient
            // 
            this.toHttpClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toHttpClient.Location = new System.Drawing.Point(3, 13);
            this.toHttpClient.Name = "toHttpClient";
            this.toHttpClient.Size = new System.Drawing.Size(213, 46);
            this.toHttpClient.TabIndex = 2;
            this.toHttpClient.Text = "HTTP клиент";
            this.toHttpClient.UseVisualStyleBackColor = true;
            this.toHttpClient.Click += new System.EventHandler(this.toHttpClient_Click);
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
            // downloadFileName
            // 
            this.downloadFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downloadFileName.Location = new System.Drawing.Point(545, 14);
            this.downloadFileName.Name = "downloadFileName";
            this.downloadFileName.Size = new System.Drawing.Size(224, 27);
            this.downloadFileName.TabIndex = 4;
            // 
            // downloadFileLabel
            // 
            this.downloadFileLabel.AutoSize = true;
            this.downloadFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downloadFileLabel.Location = new System.Drawing.Point(227, 14);
            this.downloadFileLabel.Name = "downloadFileLabel";
            this.downloadFileLabel.Size = new System.Drawing.Size(162, 20);
            this.downloadFileLabel.TabIndex = 6;
            this.downloadFileLabel.Text = "Название файла: ";
            // 
            // downloadFolderPath
            // 
            this.downloadFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downloadFolderPath.Location = new System.Drawing.Point(389, 57);
            this.downloadFolderPath.Name = "downloadFolderPath";
            this.downloadFolderPath.Size = new System.Drawing.Size(338, 27);
            this.downloadFolderPath.TabIndex = 7;
            // 
            // downloadFolderLabel
            // 
            this.downloadFolderLabel.AutoSize = true;
            this.downloadFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downloadFolderLabel.Location = new System.Drawing.Point(227, 57);
            this.downloadFolderLabel.Name = "downloadFolderLabel";
            this.downloadFolderLabel.Size = new System.Drawing.Size(100, 20);
            this.downloadFolderLabel.TabIndex = 8;
            this.downloadFolderLabel.Text = "Скачать в:";
            // 
            // ftpResult
            // 
            this.ftpResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ftpResult.Location = new System.Drawing.Point(231, 167);
            this.ftpResult.Multiline = true;
            this.ftpResult.Name = "ftpResult";
            this.ftpResult.Size = new System.Drawing.Size(538, 271);
            this.ftpResult.TabIndex = 9;
            // 
            // selectFolder
            // 
            this.selectFolder.Location = new System.Drawing.Point(733, 55);
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.Size = new System.Drawing.Size(36, 31);
            this.selectFolder.TabIndex = 12;
            this.selectFolder.Text = "...";
            this.selectFolder.UseVisualStyleBackColor = true;
            this.selectFolder.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // download
            // 
            this.download.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.download.Location = new System.Drawing.Point(231, 104);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(193, 46);
            this.download.TabIndex = 13;
            this.download.Text = "Скачать файл";
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // FTPClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.download);
            this.Controls.Add(this.selectFolder);
            this.Controls.Add(this.ftpResult);
            this.Controls.Add(this.downloadFolderLabel);
            this.Controls.Add(this.downloadFolderPath);
            this.Controls.Add(this.downloadFileLabel);
            this.Controls.Add(this.downloadFileName);
            this.Controls.Add(this.panel1);
            this.Name = "FTPClient";
            this.Text = "FTPClient";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button toFtpClient;
        private System.Windows.Forms.TextBox downloadFileName;
        private System.Windows.Forms.Button toHttpClient;
        private System.Windows.Forms.Label downloadFileLabel;
        private System.Windows.Forms.TextBox downloadFolderPath;
        private System.Windows.Forms.Label downloadFolderLabel;
        private System.Windows.Forms.TextBox ftpResult;
        private System.Windows.Forms.Button selectFolder;
        private System.Windows.Forms.Button download;
    }
}