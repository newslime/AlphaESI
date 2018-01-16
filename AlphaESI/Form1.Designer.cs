namespace AlphaESI
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.logoPanel = new System.Windows.Forms.Panel();
            this.hl9308Btn = new System.Windows.Forms.Button();
            this.hl9309Btn = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.productPanel = new System.Windows.Forms.Panel();
            this.productComboBox = new System.Windows.Forms.ComboBox();
            this.productLabel = new System.Windows.Forms.Label();
            this.refenceLabel = new System.Windows.Forms.Label();
            this.exportBtn = new System.Windows.Forms.Button();
            this.lsLabel = new System.Windows.Forms.Label();
            this.thresholdPanel = new System.Windows.Forms.Panel();
            this.refenceTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsThresholdTextBox = new System.Windows.Forms.TextBox();
            this.eLabel = new System.Windows.Forms.Label();
            this.eThresholdTextBox = new System.Windows.Forms.TextBox();
            this.μjLabel1 = new System.Windows.Forms.Label();
            this.settingLabel = new System.Windows.Forms.Label();
            this.μmLabel2 = new System.Windows.Forms.Label();
            this.μmLabel1 = new System.Windows.Forms.Label();
            this.zThresholdTextBox2 = new System.Windows.Forms.TextBox();
            this.zThresholdLabel2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ePercentTextBox = new System.Windows.Forms.TextBox();
            this.stabilityThresholdLabel = new System.Windows.Forms.Label();
            this.energyValueLabel = new System.Windows.Forms.Label();
            this.hl9309ThresholdRangeLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.lsPercentTextBox = new System.Windows.Forms.TextBox();
            this.zThresholdTextBox = new System.Windows.Forms.TextBox();
            this.energyThresholdLabel = new System.Windows.Forms.Label();
            this.zThresholdLabel = new System.Windows.Forms.Label();
            this.zLabel = new System.Windows.Forms.Label();
            this.filePanel = new System.Windows.Forms.Panel();
            this.histroyLabel = new System.Windows.Forms.LinkLabel();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileComboBox = new System.Windows.Forms.ComboBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timeValueLabel = new System.Windows.Forms.Label();
            this.hl9309PictureBox = new System.Windows.Forms.PictureBox();
            this.hl9308PictureBox = new System.Windows.Forms.PictureBox();
            this.logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.productPanel.SuspendLayout();
            this.thresholdPanel.SuspendLayout();
            this.filePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hl9309PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hl9308PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // logoPanel
            // 
            this.logoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(66)))), ((int)(((byte)(85)))));
            this.logoPanel.Controls.Add(this.hl9308Btn);
            this.logoPanel.Controls.Add(this.hl9309Btn);
            this.logoPanel.Controls.Add(this.logoPictureBox);
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(1000, 50);
            this.logoPanel.TabIndex = 54;
            // 
            // hl9308Btn
            // 
            this.hl9308Btn.FlatAppearance.BorderSize = 0;
            this.hl9308Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hl9308Btn.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.hl9308Btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            this.hl9308Btn.Location = new System.Drawing.Point(240, 12);
            this.hl9308Btn.Name = "hl9308Btn";
            this.hl9308Btn.Size = new System.Drawing.Size(80, 26);
            this.hl9308Btn.TabIndex = 2;
            this.hl9308Btn.Text = "1HL9308";
            this.hl9308Btn.UseVisualStyleBackColor = true;
            this.hl9308Btn.Click += new System.EventHandler(this.hl9308Btn_Click);
            // 
            // hl9309Btn
            // 
            this.hl9309Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(143)))), ((int)(((byte)(226)))));
            this.hl9309Btn.FlatAppearance.BorderSize = 0;
            this.hl9309Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hl9309Btn.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.hl9309Btn.ForeColor = System.Drawing.Color.White;
            this.hl9309Btn.Location = new System.Drawing.Point(150, 12);
            this.hl9309Btn.Name = "hl9309Btn";
            this.hl9309Btn.Size = new System.Drawing.Size(80, 26);
            this.hl9309Btn.TabIndex = 1;
            this.hl9309Btn.Text = "1HL9309";
            this.hl9309Btn.UseVisualStyleBackColor = false;
            this.hl9309Btn.Click += new System.EventHandler(this.hl9309Btn_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackgroundImage = global::AlphaESI.Properties.Resources.AlphaLogo;
            this.logoPictureBox.Location = new System.Drawing.Point(30, 15);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(90, 19);
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // productPanel
            // 
            this.productPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.productPanel.Controls.Add(this.productComboBox);
            this.productPanel.Controls.Add(this.productLabel);
            this.productPanel.Location = new System.Drawing.Point(30, 70);
            this.productPanel.Name = "productPanel";
            this.productPanel.Size = new System.Drawing.Size(300, 85);
            this.productPanel.TabIndex = 70;
            // 
            // productComboBox
            // 
            this.productComboBox.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.productComboBox.FormattingEnabled = true;
            this.productComboBox.Location = new System.Drawing.Point(10, 40);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(250, 25);
            this.productComboBox.TabIndex = 1;
            this.productComboBox.SelectedIndexChanged += new System.EventHandler(this.productComboBox_SelectedIndexChanged);
            this.productComboBox.GotFocus += new System.EventHandler(this.productComboBox_GotFocus);
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.productLabel.ForeColor = System.Drawing.Color.White;
            this.productLabel.Location = new System.Drawing.Point(10, 10);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(92, 19);
            this.productLabel.TabIndex = 0;
            this.productLabel.Text = "Product No.";
            // 
            // refenceLabel
            // 
            this.refenceLabel.AutoSize = true;
            this.refenceLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.refenceLabel.ForeColor = System.Drawing.Color.White;
            this.refenceLabel.Location = new System.Drawing.Point(10, 280);
            this.refenceLabel.Name = "refenceLabel";
            this.refenceLabel.Size = new System.Drawing.Size(118, 17);
            this.refenceLabel.TabIndex = 69;
            this.refenceLabel.Text = "Refence Hight(H2)";
            // 
            // exportBtn
            // 
            this.exportBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.exportBtn.FlatAppearance.BorderSize = 0;
            this.exportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportBtn.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.exportBtn.ForeColor = System.Drawing.Color.White;
            this.exportBtn.Image = global::AlphaESI.Properties.Resources.shape;
            this.exportBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportBtn.Location = new System.Drawing.Point(776, 77);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(100, 30);
            this.exportBtn.TabIndex = 67;
            this.exportBtn.Text = "Export File";
            this.exportBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportBtn.UseVisualStyleBackColor = false;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // lsLabel
            // 
            this.lsLabel.AutoSize = true;
            this.lsLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lsLabel.ForeColor = System.Drawing.Color.White;
            this.lsLabel.Location = new System.Drawing.Point(15, 212);
            this.lsLabel.Name = "lsLabel";
            this.lsLabel.Size = new System.Drawing.Size(22, 17);
            this.lsLabel.TabIndex = 68;
            this.lsLabel.Text = "LS";
            // 
            // thresholdPanel
            // 
            this.thresholdPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.thresholdPanel.Controls.Add(this.refenceTextBox);
            this.thresholdPanel.Controls.Add(this.label6);
            this.thresholdPanel.Controls.Add(this.label5);
            this.thresholdPanel.Controls.Add(this.label4);
            this.thresholdPanel.Controls.Add(this.label3);
            this.thresholdPanel.Controls.Add(this.label2);
            this.thresholdPanel.Controls.Add(this.lsThresholdTextBox);
            this.thresholdPanel.Controls.Add(this.eLabel);
            this.thresholdPanel.Controls.Add(this.eThresholdTextBox);
            this.thresholdPanel.Controls.Add(this.μjLabel1);
            this.thresholdPanel.Controls.Add(this.settingLabel);
            this.thresholdPanel.Controls.Add(this.μmLabel2);
            this.thresholdPanel.Controls.Add(this.μmLabel1);
            this.thresholdPanel.Controls.Add(this.zThresholdTextBox2);
            this.thresholdPanel.Controls.Add(this.zThresholdLabel2);
            this.thresholdPanel.Controls.Add(this.label1);
            this.thresholdPanel.Controls.Add(this.ePercentTextBox);
            this.thresholdPanel.Controls.Add(this.stabilityThresholdLabel);
            this.thresholdPanel.Controls.Add(this.energyValueLabel);
            this.thresholdPanel.Controls.Add(this.hl9309ThresholdRangeLabel);
            this.thresholdPanel.Controls.Add(this.refenceLabel);
            this.thresholdPanel.Controls.Add(this.colorLabel);
            this.thresholdPanel.Controls.Add(this.lsPercentTextBox);
            this.thresholdPanel.Controls.Add(this.lsLabel);
            this.thresholdPanel.Controls.Add(this.zThresholdTextBox);
            this.thresholdPanel.Controls.Add(this.energyThresholdLabel);
            this.thresholdPanel.Controls.Add(this.zThresholdLabel);
            this.thresholdPanel.Controls.Add(this.zLabel);
            this.thresholdPanel.Location = new System.Drawing.Point(30, 290);
            this.thresholdPanel.Name = "thresholdPanel";
            this.thresholdPanel.Size = new System.Drawing.Size(300, 388);
            this.thresholdPanel.TabIndex = 62;
            // 
            // refenceTextBox
            // 
            this.refenceTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.refenceTextBox.Location = new System.Drawing.Point(15, 300);
            this.refenceTextBox.Name = "refenceTextBox";
            this.refenceTextBox.Size = new System.Drawing.Size(80, 25);
            this.refenceTextBox.TabIndex = 85;
            this.refenceTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.refenceTextBox_MouseDown);
            this.refenceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.refenceTextBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(15, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 17);
            this.label6.TabIndex = 84;
            this.label6.Text = "H3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 17);
            this.label5.TabIndex = 83;
            this.label5.Text = "H2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(95, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 17);
            this.label4.TabIndex = 82;
            this.label4.Text = "μm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(260, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 17);
            this.label3.TabIndex = 81;
            this.label3.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(145, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 17);
            this.label2.TabIndex = 80;
            this.label2.Text = "%";
            // 
            // lsThresholdTextBox
            // 
            this.lsThresholdTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lsThresholdTextBox.Location = new System.Drawing.Point(180, 210);
            this.lsThresholdTextBox.Name = "lsThresholdTextBox";
            this.lsThresholdTextBox.Size = new System.Drawing.Size(80, 25);
            this.lsThresholdTextBox.TabIndex = 9;
            this.lsThresholdTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsThresholdTextBox_MouseDown);
            this.lsThresholdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lsThresholdTextBox_KeyPress);
            // 
            // eLabel
            // 
            this.eLabel.AutoSize = true;
            this.eLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.eLabel.ForeColor = System.Drawing.Color.White;
            this.eLabel.Location = new System.Drawing.Point(15, 182);
            this.eLabel.Name = "eLabel";
            this.eLabel.Size = new System.Drawing.Size(15, 17);
            this.eLabel.TabIndex = 78;
            this.eLabel.Text = "E";
            // 
            // eThresholdTextBox
            // 
            this.eThresholdTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.eThresholdTextBox.Location = new System.Drawing.Point(180, 180);
            this.eThresholdTextBox.Name = "eThresholdTextBox";
            this.eThresholdTextBox.Size = new System.Drawing.Size(80, 25);
            this.eThresholdTextBox.TabIndex = 7;
            this.eThresholdTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.eThresholdTextBox_MouseDown);
            this.eThresholdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eThresholdTextBox_KeyPress);
            // 
            // μjLabel1
            // 
            this.μjLabel1.AutoSize = true;
            this.μjLabel1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.μjLabel1.ForeColor = System.Drawing.Color.White;
            this.μjLabel1.Location = new System.Drawing.Point(260, 182);
            this.μjLabel1.Name = "μjLabel1";
            this.μjLabel1.Size = new System.Drawing.Size(21, 17);
            this.μjLabel1.TabIndex = 76;
            this.μjLabel1.Text = "μJ";
            // 
            // settingLabel
            // 
            this.settingLabel.AutoSize = true;
            this.settingLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.settingLabel.ForeColor = System.Drawing.Color.White;
            this.settingLabel.Location = new System.Drawing.Point(175, 160);
            this.settingLabel.Name = "settingLabel";
            this.settingLabel.Size = new System.Drawing.Size(88, 17);
            this.settingLabel.TabIndex = 75;
            this.settingLabel.Text = "Setting Value";
            // 
            // μmLabel2
            // 
            this.μmLabel2.AutoSize = true;
            this.μmLabel2.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.μmLabel2.ForeColor = System.Drawing.Color.White;
            this.μmLabel2.Location = new System.Drawing.Point(145, 92);
            this.μmLabel2.Name = "μmLabel2";
            this.μmLabel2.Size = new System.Drawing.Size(28, 17);
            this.μmLabel2.TabIndex = 74;
            this.μmLabel2.Text = "μm";
            // 
            // μmLabel1
            // 
            this.μmLabel1.AutoSize = true;
            this.μmLabel1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.μmLabel1.ForeColor = System.Drawing.Color.White;
            this.μmLabel1.Location = new System.Drawing.Point(145, 62);
            this.μmLabel1.Name = "μmLabel1";
            this.μmLabel1.Size = new System.Drawing.Size(28, 17);
            this.μmLabel1.TabIndex = 73;
            this.μmLabel1.Text = "μm";
            // 
            // zThresholdTextBox2
            // 
            this.zThresholdTextBox2.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.zThresholdTextBox2.Location = new System.Drawing.Point(65, 90);
            this.zThresholdTextBox2.Name = "zThresholdTextBox2";
            this.zThresholdTextBox2.Size = new System.Drawing.Size(80, 25);
            this.zThresholdTextBox2.TabIndex = 5;
            this.zThresholdTextBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zThresholdTextBox2_MouseDown);
            this.zThresholdTextBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zThresholdTextBox2_KeyPress);
            // 
            // zThresholdLabel2
            // 
            this.zThresholdLabel2.AutoSize = true;
            this.zThresholdLabel2.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.zThresholdLabel2.ForeColor = System.Drawing.Color.White;
            this.zThresholdLabel2.Location = new System.Drawing.Point(35, 92);
            this.zThresholdLabel2.Name = "zThresholdLabel2";
            this.zThresholdLabel2.Size = new System.Drawing.Size(28, 17);
            this.zThresholdLabel2.TabIndex = 71;
            this.zThresholdLabel2.Text = ">=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(145, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 17);
            this.label1.TabIndex = 70;
            this.label1.Text = "%";
            // 
            // ePercentTextBox
            // 
            this.ePercentTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ePercentTextBox.Location = new System.Drawing.Point(65, 180);
            this.ePercentTextBox.Name = "ePercentTextBox";
            this.ePercentTextBox.Size = new System.Drawing.Size(80, 25);
            this.ePercentTextBox.TabIndex = 6;
            this.ePercentTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ePercentTextBox_MouseDown);
            this.ePercentTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ePercentTextBox_KeyPress);
            // 
            // stabilityThresholdLabel
            // 
            this.stabilityThresholdLabel.AutoSize = true;
            this.stabilityThresholdLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.stabilityThresholdLabel.ForeColor = System.Drawing.Color.White;
            this.stabilityThresholdLabel.Location = new System.Drawing.Point(35, 212);
            this.stabilityThresholdLabel.Name = "stabilityThresholdLabel";
            this.stabilityThresholdLabel.Size = new System.Drawing.Size(28, 17);
            this.stabilityThresholdLabel.TabIndex = 26;
            this.stabilityThresholdLabel.Text = ">=";
            // 
            // energyValueLabel
            // 
            this.energyValueLabel.AutoSize = true;
            this.energyValueLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.energyValueLabel.ForeColor = System.Drawing.Color.White;
            this.energyValueLabel.Location = new System.Drawing.Point(10, 160);
            this.energyValueLabel.Name = "energyValueLabel";
            this.energyValueLabel.Size = new System.Drawing.Size(87, 17);
            this.energyValueLabel.TabIndex = 24;
            this.energyValueLabel.Text = "Energy Value";
            // 
            // hl9309ThresholdRangeLabel
            // 
            this.hl9309ThresholdRangeLabel.AutoSize = true;
            this.hl9309ThresholdRangeLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.hl9309ThresholdRangeLabel.ForeColor = System.Drawing.Color.White;
            this.hl9309ThresholdRangeLabel.Location = new System.Drawing.Point(10, 10);
            this.hl9309ThresholdRangeLabel.Name = "hl9309ThresholdRangeLabel";
            this.hl9309ThresholdRangeLabel.Size = new System.Drawing.Size(128, 19);
            this.hl9309ThresholdRangeLabel.TabIndex = 0;
            this.hl9309ThresholdRangeLabel.Text = "Threshold Range";
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.colorLabel.ForeColor = System.Drawing.Color.White;
            this.colorLabel.Location = new System.Drawing.Point(200, 40);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(41, 17);
            this.colorLabel.TabIndex = 0;
            this.colorLabel.Text = "Color";
            this.colorLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lsPercentTextBox
            // 
            this.lsPercentTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lsPercentTextBox.Location = new System.Drawing.Point(65, 210);
            this.lsPercentTextBox.Name = "lsPercentTextBox";
            this.lsPercentTextBox.Size = new System.Drawing.Size(80, 25);
            this.lsPercentTextBox.TabIndex = 8;
            this.lsPercentTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsPercentTextBox_MouseDown);
            this.lsPercentTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lsPercentTextBox_KeyPress);
            // 
            // zThresholdTextBox
            // 
            this.zThresholdTextBox.Enabled = false;
            this.zThresholdTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.zThresholdTextBox.Location = new System.Drawing.Point(65, 60);
            this.zThresholdTextBox.Name = "zThresholdTextBox";
            this.zThresholdTextBox.Size = new System.Drawing.Size(80, 25);
            this.zThresholdTextBox.TabIndex = 4;
            this.zThresholdTextBox.Text = "0.00";
            // 
            // energyThresholdLabel
            // 
            this.energyThresholdLabel.AutoSize = true;
            this.energyThresholdLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.energyThresholdLabel.ForeColor = System.Drawing.Color.White;
            this.energyThresholdLabel.Location = new System.Drawing.Point(35, 182);
            this.energyThresholdLabel.Name = "energyThresholdLabel";
            this.energyThresholdLabel.Size = new System.Drawing.Size(28, 17);
            this.energyThresholdLabel.TabIndex = 15;
            this.energyThresholdLabel.Text = ">=";
            // 
            // zThresholdLabel
            // 
            this.zThresholdLabel.AutoSize = true;
            this.zThresholdLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.zThresholdLabel.ForeColor = System.Drawing.Color.White;
            this.zThresholdLabel.Location = new System.Drawing.Point(35, 62);
            this.zThresholdLabel.Name = "zThresholdLabel";
            this.zThresholdLabel.Size = new System.Drawing.Size(28, 17);
            this.zThresholdLabel.TabIndex = 0;
            this.zThresholdLabel.Text = ">=";
            // 
            // zLabel
            // 
            this.zLabel.AutoSize = true;
            this.zLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.zLabel.ForeColor = System.Drawing.Color.White;
            this.zLabel.Location = new System.Drawing.Point(10, 40);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(53, 17);
            this.zLabel.TabIndex = 0;
            this.zLabel.Text = "Z Value";
            // 
            // filePanel
            // 
            this.filePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.filePanel.Controls.Add(this.histroyLabel);
            this.filePanel.Controls.Add(this.fileLabel);
            this.filePanel.Controls.Add(this.fileComboBox);
            this.filePanel.Location = new System.Drawing.Point(30, 180);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(300, 85);
            this.filePanel.TabIndex = 63;
            // 
            // histroyLabel
            // 
            this.histroyLabel.AutoSize = true;
            this.histroyLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.histroyLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.histroyLabel.Location = new System.Drawing.Point(180, 10);
            this.histroyLabel.Name = "histroyLabel";
            this.histroyLabel.Size = new System.Drawing.Size(80, 17);
            this.histroyLabel.TabIndex = 3;
            this.histroyLabel.TabStop = true;
            this.histroyLabel.Text = "view histroy";
            this.histroyLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.histroyLabel_LinkClicked);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fileLabel.ForeColor = System.Drawing.Color.White;
            this.fileLabel.Location = new System.Drawing.Point(10, 10);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(33, 19);
            this.fileLabel.TabIndex = 0;
            this.fileLabel.Text = "File";
            // 
            // fileComboBox
            // 
            this.fileComboBox.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fileComboBox.FormattingEnabled = true;
            this.fileComboBox.Location = new System.Drawing.Point(10, 40);
            this.fileComboBox.Name = "fileComboBox";
            this.fileComboBox.Size = new System.Drawing.Size(250, 25);
            this.fileComboBox.TabIndex = 2;
            this.fileComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fileComboBox_KeyPress);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.timeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            this.timeLabel.Location = new System.Drawing.Point(360, 80);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(39, 15);
            this.timeLabel.TabIndex = 64;
            this.timeLabel.Text = "Time";
            // 
            // timeValueLabel
            // 
            this.timeValueLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            this.timeValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.timeValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(255)))), ((int)(((byte)(203)))));
            this.timeValueLabel.Location = new System.Drawing.Point(402, 77);
            this.timeValueLabel.Name = "timeValueLabel";
            this.timeValueLabel.Size = new System.Drawing.Size(140, 20);
            this.timeValueLabel.TabIndex = 65;
            this.timeValueLabel.Text = "time";
            this.timeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hl9309PictureBox
            // 
            this.hl9309PictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(72)))), ((int)(((byte)(84)))));
            this.hl9309PictureBox.Location = new System.Drawing.Point(380, 127);
            this.hl9309PictureBox.Name = "hl9309PictureBox";
            this.hl9309PictureBox.Size = new System.Drawing.Size(601, 551);
            this.hl9309PictureBox.TabIndex = 66;
            this.hl9309PictureBox.TabStop = false;
            this.hl9309PictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hl9309PictureBox_MouseDown);
            this.hl9309PictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.hl9309PictureBox_Paint);
            // 
            // hl9308PictureBox
            // 
            this.hl9308PictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(72)))), ((int)(((byte)(84)))));
            this.hl9308PictureBox.Location = new System.Drawing.Point(980, 127);
            this.hl9308PictureBox.Name = "hl9308PictureBox";
            this.hl9308PictureBox.Size = new System.Drawing.Size(551, 551);
            this.hl9308PictureBox.TabIndex = 73;
            this.hl9308PictureBox.TabStop = false;
            this.hl9308PictureBox.Visible = false;
            this.hl9308PictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hl9308PictureBox_MouseDown);
            this.hl9308PictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.hl9308PictureBox_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1194, 752);
            this.Controls.Add(this.hl9308PictureBox);
            this.Controls.Add(this.productPanel);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.thresholdPanel);
            this.Controls.Add(this.filePanel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.timeValueLabel);
            this.Controls.Add(this.hl9309PictureBox);
            this.Controls.Add(this.logoPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "AlphaESI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.productPanel.ResumeLayout(false);
            this.productPanel.PerformLayout();
            this.thresholdPanel.ResumeLayout(false);
            this.thresholdPanel.PerformLayout();
            this.filePanel.ResumeLayout(false);
            this.filePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hl9309PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hl9308PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button hl9309Btn;
        private System.Windows.Forms.Button hl9308Btn;
        private System.Windows.Forms.Panel productPanel;
        private System.Windows.Forms.ComboBox productComboBox;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.Label refenceLabel;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Label lsLabel;
        private System.Windows.Forms.Panel thresholdPanel;
        private System.Windows.Forms.TextBox ePercentTextBox;
        private System.Windows.Forms.Label stabilityThresholdLabel;
        private System.Windows.Forms.Label energyValueLabel;
        private System.Windows.Forms.Label hl9309ThresholdRangeLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.TextBox lsPercentTextBox;
        private System.Windows.Forms.TextBox zThresholdTextBox;
        private System.Windows.Forms.Label energyThresholdLabel;
        private System.Windows.Forms.Label zThresholdLabel;
        private System.Windows.Forms.Label zLabel;
        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.LinkLabel histroyLabel;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.ComboBox fileComboBox;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label timeValueLabel;
        private System.Windows.Forms.PictureBox hl9309PictureBox;
        private System.Windows.Forms.PictureBox hl9308PictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label μmLabel1;
        private System.Windows.Forms.TextBox zThresholdTextBox2;
        private System.Windows.Forms.Label zThresholdLabel2;
        private System.Windows.Forms.Label μmLabel2;
        private System.Windows.Forms.Label settingLabel;
        private System.Windows.Forms.Label μjLabel1;
        private System.Windows.Forms.TextBox eThresholdTextBox;
        private System.Windows.Forms.Label eLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lsThresholdTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox refenceTextBox;


    }
}

