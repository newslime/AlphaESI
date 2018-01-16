namespace AlphaESI
{
    partial class HistoryListForm
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
            this.waferListBox = new AsYetUnnamed.MultiColumnListBox();
            this.historyLabel = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // waferListBox
            // 
            this.waferListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.waferListBox.ColumnCount = 0;
            this.waferListBox.ColumnWidth = 75;
            this.waferListBox.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.waferListBox.HorizontalScrollbar = true;
            this.waferListBox.ItemHeight = 20;
            this.waferListBox.Location = new System.Drawing.Point(55, 277);
            this.waferListBox.MatchBufferTimeOut = 1000;
            this.waferListBox.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.ColpleteBestMatch;
            this.waferListBox.Name = "waferListBox";
            this.waferListBox.ScrollAlwaysVisible = true;
            this.waferListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.waferListBox.Size = new System.Drawing.Size(472, 44);
            this.waferListBox.TabIndex = 0;
            this.waferListBox.TextIndex = 0;
            this.waferListBox.TextMember = null;
            this.waferListBox.ValueIndex = -1;
            this.waferListBox.DoubleClick += new System.EventHandler(this.waferListBox_DoubleClick);
            this.waferListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.waferListBox_MouseDown);
            // 
            // historyLabel
            // 
            this.historyLabel.AutoSize = true;
            this.historyLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.historyLabel.ForeColor = System.Drawing.Color.White;
            this.historyLabel.Location = new System.Drawing.Point(30, 70);
            this.historyLabel.Name = "historyLabel";
            this.historyLabel.Size = new System.Drawing.Size(62, 20);
            this.historyLabel.TabIndex = 2;
            this.historyLabel.Text = "History";
            // 
            // backBtn
            // 
            this.backBtn.FlatAppearance.BorderSize = 0;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.backBtn.ForeColor = System.Drawing.Color.White;
            this.backBtn.Image = global::AlphaESI.Properties.Resources.back;
            this.backBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.backBtn.Location = new System.Drawing.Point(30, 20);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(70, 25);
            this.backBtn.TabIndex = 1;
            this.backBtn.Text = "Back";
            this.backBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // searchLabel
            // 
            this.searchLabel.BackColor = System.Drawing.Color.Transparent;
            this.searchLabel.ForeColor = System.Drawing.Color.White;
            this.searchLabel.Image = global::AlphaESI.Properties.Resources.search;
            this.searchLabel.Location = new System.Drawing.Point(151, 77);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(50, 23);
            this.searchLabel.TabIndex = 3;
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(210)))), ((int)(((byte)(211)))));
            this.searchPanel.Location = new System.Drawing.Point(0, 120);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(600, 50);
            this.searchPanel.TabIndex = 5;
            this.searchPanel.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::AlphaESI.Properties.Resources.save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // HistoryListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.historyLabel);
            this.Controls.Add(this.waferListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "HistoryListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "HistoryForm";
            this.Click += new System.EventHandler(this.HistoryForm_Click);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label historyLabel;
        private AsYetUnnamed.MultiColumnListBox waferListBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}