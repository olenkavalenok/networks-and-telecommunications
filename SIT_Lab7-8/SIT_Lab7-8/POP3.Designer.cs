namespace SIT_Lab7_8
{
    partial class POP3
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
            this.incMessages = new System.Windows.Forms.Button();
            this.sendMessage = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Topic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messBody = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messTextLabel = new System.Windows.Forms.Label();
            this.messText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // incMessages
            // 
            this.incMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.incMessages.Location = new System.Drawing.Point(3, 88);
            this.incMessages.Name = "incMessages";
            this.incMessages.Size = new System.Drawing.Size(204, 66);
            this.incMessages.TabIndex = 4;
            this.incMessages.Text = "Входящие сообщения";
            this.incMessages.UseVisualStyleBackColor = true;
            this.incMessages.Click += new System.EventHandler(this.incMessages_Click);
            // 
            // sendMessage
            // 
            this.sendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendMessage.Location = new System.Drawing.Point(3, 21);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(204, 52);
            this.sendMessage.TabIndex = 3;
            this.sendMessage.Text = "Отправить письмо";
            this.sendMessage.UseVisualStyleBackColor = true;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sender,
            this.Topic,
            this.Date,
            this.messBody});
            this.dataGridView1.Location = new System.Drawing.Point(240, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(530, 224);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Sender
            // 
            this.Sender.HeaderText = "Отправитель";
            this.Sender.MinimumWidth = 6;
            this.Sender.Name = "Sender";
            this.Sender.Width = 145;
            // 
            // Topic
            // 
            this.Topic.HeaderText = "Тема";
            this.Topic.MinimumWidth = 6;
            this.Topic.Name = "Topic";
            this.Topic.Width = 130;
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.Width = 120;
            // 
            // messBody
            // 
            this.messBody.HeaderText = "Текст сообщения";
            this.messBody.MinimumWidth = 6;
            this.messBody.Name = "messBody";
            this.messBody.Width = 125;
            // 
            // messTextLabel
            // 
            this.messTextLabel.AutoSize = true;
            this.messTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messTextLabel.Location = new System.Drawing.Point(236, 265);
            this.messTextLabel.Name = "messTextLabel";
            this.messTextLabel.Size = new System.Drawing.Size(166, 24);
            this.messTextLabel.TabIndex = 2;
            this.messTextLabel.Text = "Текст сообщения";
            // 
            // messText
            // 
            this.messText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messText.Location = new System.Drawing.Point(240, 306);
            this.messText.Multiline = true;
            this.messText.Name = "messText";
            this.messText.Size = new System.Drawing.Size(530, 115);
            this.messText.TabIndex = 3;
            // 
            // POP3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.messText);
            this.Controls.Add(this.messTextLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "POP3";
            this.Text = "POP3";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.Button incMessages;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Topic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.Label messTextLabel;
        private System.Windows.Forms.TextBox messText;
        private System.Windows.Forms.DataGridViewTextBoxColumn messBody;
    }
}