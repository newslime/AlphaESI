using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace AlphaESI
{
    public partial class NotifyForm : Form
    {
        private SoundPlayer Player = new SoundPlayer();
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public NotifyForm(DeviceType device, string filename, double zValue, Color zColor, double energyValue, Color eColor)
        {
            InitializeComponent();

            this.Text = device.ToString() + filename;

            deviceTextBox.Text = device.ToString();
            fileTextBox.Text = filename;
            zTextBox.Text = zValue.ToString("#0.00") + "μm";
            energyTextBox.Text = energyValue.ToString("#0.00") + "μJ";

            zTextBox.ForeColor = zColor;
            energyTextBox.ForeColor = eColor;

            this.ActiveControl = titleLabel;

            try
            {  
                this.Player.SoundLocation =  Application.StartupPath + "\\notify.wav";
                this.Player.PlayLooping();
            }
            catch (Exception ex)
            {
                EventLog.Write(ex.Message);
            }
        }

        private void clostBtn_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            this.Player.Stop();
            this.Close();
        }

        private void NotifyForm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void NotifyForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void NotifyForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
