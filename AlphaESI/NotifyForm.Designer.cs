namespace AlphaESI
{
    partial class NotifyForm
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
            this.titlePanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.energyTextBox = new System.Windows.Forms.TextBox();
            this.zTextBox = new System.Windows.Forms.TextBox();
            this.energyLabel = new System.Windows.Forms.Label();
            this.zLabel = new System.Windows.Forms.Label();
            this.clostBtn = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.deviceLabel = new System.Windows.Forms.Label();
            this.deviceTextBox = new System.Windows.Forms.TextBox();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(77)))));
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Controls.Add(this.pictureBox1);
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(280, 40);
            this.titlePanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(80, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(154, 20);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Wrong Notification";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(77)))));
            this.pictureBox1.BackgroundImage = global::AlphaESI.Properties.Resources.notify;
            this.pictureBox1.Location = new System.Drawing.Point(60, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // energyTextBox
            // 
            this.energyTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.energyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.energyTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.energyTextBox.Location = new System.Drawing.Point(105, 150);
            this.energyTextBox.Name = "energyTextBox";
            this.energyTextBox.ReadOnly = true;
            this.energyTextBox.Size = new System.Drawing.Size(150, 25);
            this.energyTextBox.TabIndex = 14;
            // 
            // zTextBox
            // 
            this.zTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.zTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.zTextBox.Location = new System.Drawing.Point(105, 120);
            this.zTextBox.Name = "zTextBox";
            this.zTextBox.ReadOnly = true;
            this.zTextBox.Size = new System.Drawing.Size(150, 25);
            this.zTextBox.TabIndex = 13;
            // 
            // energyLabel
            // 
            this.energyLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.energyLabel.ForeColor = System.Drawing.Color.White;
            this.energyLabel.Location = new System.Drawing.Point(15, 150);
            this.energyLabel.Name = "energyLabel";
            this.energyLabel.Size = new System.Drawing.Size(90, 20);
            this.energyLabel.TabIndex = 12;
            this.energyLabel.Text = "Energy Value";
            // 
            // zLabel
            // 
            this.zLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.zLabel.ForeColor = System.Drawing.Color.White;
            this.zLabel.Location = new System.Drawing.Point(15, 120);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(90, 20);
            this.zLabel.TabIndex = 11;
            this.zLabel.Text = "Z Value";
            this.zLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // clostBtn
            // 
            this.clostBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clostBtn.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clostBtn.ForeColor = System.Drawing.Color.White;
            this.clostBtn.Location = new System.Drawing.Point(80, 200);
            this.clostBtn.Name = "clostBtn";
            this.clostBtn.Size = new System.Drawing.Size(120, 30);
            this.clostBtn.TabIndex = 15;
            this.clostBtn.Text = "Close";
            this.clostBtn.UseVisualStyleBackColor = true;
            this.clostBtn.Click += new System.EventHandler(this.clostBtn_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fileLabel.ForeColor = System.Drawing.Color.White;
            this.fileLabel.Location = new System.Drawing.Point(15, 90);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(90, 20);
            this.fileLabel.TabIndex = 16;
            this.fileLabel.Text = "File Name";
            this.fileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fileTextBox
            // 
            this.fileTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.fileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fileTextBox.Location = new System.Drawing.Point(105, 90);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(150, 25);
            this.fileTextBox.TabIndex = 17;
            // 
            // deviceLabel
            // 
            this.deviceLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.deviceLabel.ForeColor = System.Drawing.Color.White;
            this.deviceLabel.Location = new System.Drawing.Point(15, 60);
            this.deviceLabel.Name = "deviceLabel";
            this.deviceLabel.Size = new System.Drawing.Size(90, 20);
            this.deviceLabel.TabIndex = 18;
            this.deviceLabel.Text = "Device";
            this.deviceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deviceTextBox
            // 
            this.deviceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.deviceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deviceTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.deviceTextBox.Location = new System.Drawing.Point(105, 60);
            this.deviceTextBox.Name = "deviceTextBox";
            this.deviceTextBox.Size = new System.Drawing.Size(150, 25);
            this.deviceTextBox.TabIndex = 19;
            // 
            // NotifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(280, 250);
            this.Controls.Add(this.deviceTextBox);
            this.Controls.Add(this.deviceLabel);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.clostBtn);
            this.Controls.Add(this.energyTextBox);
            this.Controls.Add(this.zTextBox);
            this.Controls.Add(this.energyLabel);
            this.Controls.Add(this.zLabel);
            this.Controls.Add(this.titlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NotifyForm";
            this.Text = "NotifyForm";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NotifyForm_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NotifyForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NotifyForm_MouseMove);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox energyTextBox;
        private System.Windows.Forms.TextBox zTextBox;
        private System.Windows.Forms.Label energyLabel;
        private System.Windows.Forms.Label zLabel;
        private System.Windows.Forms.Button clostBtn;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Label deviceLabel;
        private System.Windows.Forms.TextBox deviceTextBox;
    }
}