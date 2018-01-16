using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Net;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AlphaESI
{
    public partial class Form1 : Form
    {
        private static Thread _LatestThread;
        private static bool _Run;
        private bool _refreshMain = false;

        Dictionary<string, WaferDie> _hl9309WaferDieDic = new Dictionary<string, WaferDie>();
        Dictionary<string, WaferDie> _hl9308WaferDieDic = new Dictionary<string, WaferDie>();
        RoundButton zColorBtn1, zColorBtn2;

        public Form1()
        {
            InitializeComponent();

            Parameter.Init();

            this.Text = "AlphaESI-" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Width = 1000;
            this.Height = 780;

            timeLabel.Location = new Point(productPanel.Location.X + productPanel.Width + 50, productPanel.Location.Y);
            timeValueLabel.Location = new Point(timeLabel.Location.X + timeLabel.Width + 5, timeLabel.Location.Y - 2);
            timeValueLabel.Text = string.Format("{0:yyyy-MM-dd   HH:mm:ss}", DateTime.Now);

            hl9309PictureBox.Location = new Point(timeLabel.Location.X, timeLabel.Location.Y + timeLabel.Height + 20);
            hl9309PictureBox.Width = Parameter.Columns * Parameter.RectangleWeight + 1;
            hl9309PictureBox.Height = Parameter.Rows * Parameter.RectangleWeight + 1;

            hl9308PictureBox.Location = new Point(hl9309PictureBox.Location.X, hl9309PictureBox.Location.Y);
            hl9308PictureBox.Width = Parameter.Columns * Parameter.RectangleWeight + 1;
            hl9308PictureBox.Height = Parameter.Rows * Parameter.RectangleWeight + 1;

            exportBtn.Location = new Point(hl9309PictureBox.Location.X + hl9309PictureBox.Width - exportBtn.Width, hl9309PictureBox.Location.Y - exportBtn.Height - 10);

            zColorBtn1 = new RoundButton();
            EventHandler handler1 = new EventHandler(zColorBtn1_Click);
            zColorBtn1.Click += handler1;
            zColorBtn1.Location = new Point(colorLabel.Location.X + 10, zThresholdTextBox.Location.Y);
            zColorBtn1.Size = new Size(23, 23);
            zColorBtn1.TabIndex = 11;
            thresholdPanel.Controls.Add(zColorBtn1);

            zColorBtn2 = new RoundButton();
            EventHandler handler2 = new EventHandler(zColorBtn2_Click);
            zColorBtn2.Click += handler2;
            zColorBtn2.Location = new Point(colorLabel.Location.X + 10, zThresholdTextBox2.Location.Y);
            zColorBtn2.Size = new Size(23, 23);
            zColorBtn2.TabIndex = 12;
            thresholdPanel.Controls.Add(zColorBtn2);

            this.ActiveControl = logoPictureBox;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String name = Process.GetCurrentProcess().ProcessName;
            Process[] ps = Process.GetProcessesByName(name);
            if (ps.Length > 1)
            {
                System.Environment.Exit(2);
            }

            Sqlite.Open();
            OracleClient.Open();

            _LatestThread = new Thread(new ThreadStart(HL930_Run));
            _LatestThread.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Run)
            {
                _Run = false;
                _LatestThread.Abort();
            }

            _hl9309WaferDieDic.Clear();
            _hl9309WaferDieDic = null;

            _hl9308WaferDieDic.Clear();
            _hl9308WaferDieDic = null;

            try
            {
                Sqlite.Close();
                OracleClient.Close();
            }
            catch (Exception ex)
            {
                EventLog.Write(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeValueLabel.Text = string.Format("{0:yyyy-MM-dd   HH:mm:ss}", DateTime.Now);
        }

        private void hl9309Btn_Click(object sender, EventArgs e)
        {
            Parameter.CurrentDevice = DeviceType.HL9309;

            hl9309Btn.BackColor = Color.FromArgb(102, 143, 226);
            hl9309Btn.ForeColor = Color.White;

            hl9308Btn.BackColor = Color.FromArgb(50, 66, 85);
            hl9308Btn.ForeColor = Color.FromArgb(149, 149, 149);

            productComboBox.Text = Parameter.DeviceHL9309.ProductName;
            fileComboBox.Text = Path.GetFileName(Parameter.DeviceHL9309.FilePath);

            if (Parameter.DeviceHL9309.ProductName != "")
            {
                zThresholdTextBox2.Text = Parameter.DeviceHL9309.Z_Threshold.ToString("f2");
                ePercentTextBox.Text = Parameter.DeviceHL9309.Energy_Percent.ToString();
                eThresholdTextBox.Text = Parameter.DeviceHL9309.Energy_Threshold.ToString("f2");
                lsPercentTextBox.Text = Parameter.DeviceHL9309.Stability_Percent.ToString();
                lsThresholdTextBox.Text = Parameter.DeviceHL9309.Stability_Threshold.ToString("f2");
                refenceTextBox.Text = Parameter.DeviceHL9309.Refence.ToString();
            }
            else
            {
                zThresholdTextBox2.Text = "";
                ePercentTextBox.Text = "";
                eThresholdTextBox.Text = "";
                lsPercentTextBox.Text = "";
                lsThresholdTextBox.Text = "";
                refenceTextBox.Text = "";
            }

            ChangeColor(zColorBtn1, Parameter.DeviceHL9309.DieColor1);
            ChangeColor(zColorBtn2, Parameter.DeviceHL9309.DieColor2);

            hl9309PictureBox.Visible = true;
            hl9308PictureBox.Visible = false;
        }

        private void hl9308Btn_Click(object sender, EventArgs e)
        {
            Parameter.CurrentDevice = DeviceType.HL9308;

            hl9308Btn.BackColor = Color.FromArgb(102, 143, 226);
            hl9308Btn.ForeColor = Color.White;

            hl9309Btn.BackColor = Color.FromArgb(50, 66, 85);
            hl9309Btn.ForeColor = Color.FromArgb(149, 149, 149);

            productComboBox.Text = Parameter.DeviceHL9308.ProductName;
            fileComboBox.Text = Path.GetFileName(Parameter.DeviceHL9308.FilePath);

            if (productComboBox.Text != "")
            {
                zThresholdTextBox2.Text = Parameter.DeviceHL9308.Z_Threshold.ToString("f2");
                ePercentTextBox.Text = Parameter.DeviceHL9308.Energy_Percent.ToString();
                eThresholdTextBox.Text = Parameter.DeviceHL9308.Energy_Threshold.ToString("f2");
                lsPercentTextBox.Text = Parameter.DeviceHL9308.Stability_Percent.ToString();
                lsThresholdTextBox.Text = Parameter.DeviceHL9308.Stability_Threshold.ToString("f2");
                refenceTextBox.Text = Parameter.DeviceHL9308.Refence.ToString();
            }
            else
            {
                zThresholdTextBox2.Text = "";
                ePercentTextBox.Text = "";
                eThresholdTextBox.Text = "";
                lsPercentTextBox.Text = "";
                lsThresholdTextBox.Text = "";
                refenceTextBox.Text = "";
            }

            ChangeColor(zColorBtn1, Parameter.DeviceHL9308.DieColor1);
            ChangeColor(zColorBtn2, Parameter.DeviceHL9308.DieColor2);

            hl9309PictureBox.Visible = false;
            hl9308PictureBox.Visible = true;
        }

        private void hl9309PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(SystemColors.ControlDark, 1);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Font font = new Font(new FontFamily("Times New Roman"), 10, FontStyle.Regular, GraphicsUnit.Pixel);
            int x, y, width, height;
            WaferDie die;
            PointF pointF;
            string[] points;

            for (int i = 0; i < Parameter.Columns; i++)
            {
                for (int j = 0; j < Parameter.Rows; j++)
                {
                    e.Graphics.DrawRectangle(pen, i * Parameter.RectangleWeight, j * Parameter.RectangleWeight, Parameter.RectangleWeight, Parameter.RectangleWeight);
                }
            }

            if (Parameter.DeviceHL9309.ProductName != "")
            {
                foreach (string key in _hl9309WaferDieDic.Keys)
                {
                    points = key.Split(',');

                    if (points.Length >= 4)
                    {
                        Int32.TryParse(points[0], out x);
                        Int32.TryParse(points[1], out y);
                        Int32.TryParse(points[2], out width);
                        Int32.TryParse(points[3], out height);

                        die = _hl9309WaferDieDic[key];

                        solidBrush.Color = (die.z > Parameter.DeviceHL9309.Z_Threshold) ? Parameter.DeviceHL9309.DieColor2 : Parameter.DeviceHL9309.DieColor1;

                        e.Graphics.FillRectangle(solidBrush, x, y, width, height);

                        pointF = new PointF(x + (width - 9) / 2, y + (height - 9) / 2 - 2);
                        solidBrush.Color = Color.Black;
                        e.Graphics.DrawString(Convert.ToInt32(die.z).ToString(), font, solidBrush, pointF);
                    }
                }
            }
        }

        private void hl9308PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(SystemColors.ControlDark, 1);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Font font = new Font(new FontFamily("Times New Roman"), 10, FontStyle.Regular, GraphicsUnit.Pixel);
            int x, y, width, height;
            WaferDie die;
            PointF pointF;
            string[] points;

            for (int i = 0; i < Parameter.Columns; i++)
            {
                for (int j = 0; j < Parameter.Rows; j++)
                {
                    e.Graphics.DrawRectangle(pen, i * Parameter.RectangleWeight, j * Parameter.RectangleWeight, Parameter.RectangleWeight, Parameter.RectangleWeight);
                }
            }

            if (Parameter.DeviceHL9308.ProductName != "")
            {
                foreach (string key in _hl9308WaferDieDic.Keys)
                {
                    points = key.Split(',');

                    if (points.Length >= 4)
                    {
                        Int32.TryParse(points[0], out x);
                        Int32.TryParse(points[1], out y);
                        Int32.TryParse(points[2], out width);
                        Int32.TryParse(points[3], out height);

                        die = _hl9308WaferDieDic[key];

                        solidBrush.Color = (die.z > Parameter.DeviceHL9308.Z_Threshold) ? Parameter.DeviceHL9308.DieColor2 : Parameter.DeviceHL9308.DieColor1;

                        e.Graphics.FillRectangle(solidBrush, x, y, width, height);

                        pointF = new PointF(x + (width - 9) / 2, y + (height - 9) / 2 - 2);
                        solidBrush.Color = Color.Black;
                        e.Graphics.DrawString(Convert.ToInt32(die.z).ToString(), font, solidBrush, pointF);
                    }
                }
            }
        }

        private void productComboBox_GotFocus(object sender, EventArgs e)
        {
            productComboBox.Items.Clear();
            string[] products = FTPClient.GetProducts(Parameter.CurrentDevice);
            if (products != null)
            {
                foreach (string product in products)
                {
                    productComboBox.Items.Add(product);
                }
            }
        }

        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            double zThreshold = 10.00, energyThreshold = 1.00, lsThreshold = 10.0;
            int energyPercent = 10, lsPercent = 10, refence = 5;

            fileComboBox.Text = "";
            ePercentTextBox.Text = "";
            eThresholdTextBox.Text = "";
            lsPercentTextBox.Text = "";
            refenceTextBox.Text = "";

            if (Parameter.CurrentDevice == DeviceType.HL9309)
            {
                Parameter.DeviceHL9309.ProductName = productComboBox.Text;
                _refreshMain = true;
            }
            else
            {
                Parameter.DeviceHL9308.ProductName = productComboBox.Text;
                _refreshMain = true;
            }

            this.ActiveControl = logoPictureBox;

            if (Sqlite.SelectParameter(Parameter.CurrentDevice, productComboBox.Text, ref zThreshold, ref energyThreshold, ref energyPercent, ref lsThreshold, ref lsPercent, ref refence) == 0)
            {
                Sqlite.InsertParameter(Parameter.CurrentDevice, productComboBox.Text, zThreshold, energyThreshold, energyPercent, lsThreshold, lsPercent, refence);
            }

            if (Parameter.CurrentDevice == DeviceType.HL9309)
            {
                fileComboBox.Text = Path.GetFileName(Parameter.DeviceHL9309.FilePath);
                Parameter.DeviceHL9309.Z_Threshold = zThreshold;
                Parameter.DeviceHL9309.Energy_Threshold = energyThreshold;
                Parameter.DeviceHL9309.Energy_Percent = energyPercent;
                Parameter.DeviceHL9309.Stability_Threshold = lsThreshold;
                Parameter.DeviceHL9309.Stability_Percent = lsPercent;
                Parameter.DeviceHL9309.Refence = refence;
            }
            else
            {
                fileComboBox.Text = Path.GetFileName(Parameter.DeviceHL9308.FilePath);
                Parameter.DeviceHL9308.Z_Threshold = zThreshold;
                Parameter.DeviceHL9308.Energy_Threshold = energyThreshold;
                Parameter.DeviceHL9308.Energy_Percent = energyPercent;
                Parameter.DeviceHL9308.Stability_Threshold = lsThreshold;
                Parameter.DeviceHL9308.Stability_Percent = lsPercent;
                Parameter.DeviceHL9308.Refence = refence;
            }    

            zThresholdTextBox2.Text = zThreshold.ToString("f2");
            ePercentTextBox.Text = energyPercent.ToString();
            eThresholdTextBox.Text = energyThreshold.ToString("f2");
            lsPercentTextBox.Text = lsPercent.ToString();
            lsThresholdTextBox.Text = lsThreshold.ToString("f2");
            refenceTextBox.Text = refence.ToString();
        }

        private void fileComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void zColorBtn1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                ChangeColor(sender, colorDialog1.Color);

                if (Parameter.CurrentDevice == DeviceType.HL9309)
                {
                    Parameter.DeviceHL9309.DieColor1 = colorDialog1.Color;
                    WaferDrawing(DeviceType.HL9309, Parameter.DeviceHL9309.FilePath, _hl9309WaferDieDic, hl9309PictureBox.CreateGraphics());
                }
                else
                {
                    Parameter.DeviceHL9308.DieColor1 = colorDialog1.Color;
                    WaferDrawing(DeviceType.HL9308, Parameter.DeviceHL9308.FilePath, _hl9308WaferDieDic, hl9308PictureBox.CreateGraphics());
                } 
            }
        }

        private void zColorBtn2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                ChangeColor(sender, colorDialog1.Color);

                if (Parameter.CurrentDevice == DeviceType.HL9309)
                {
                    Parameter.DeviceHL9309.DieColor2 = colorDialog1.Color;
                    WaferDrawing(DeviceType.HL9309, Parameter.DeviceHL9309.FilePath, _hl9309WaferDieDic, hl9309PictureBox.CreateGraphics());
                }
                else
                {
                    Parameter.DeviceHL9308.DieColor2 = colorDialog1.Color;
                    WaferDrawing(DeviceType.HL9308, Parameter.DeviceHL9308.FilePath, _hl9308WaferDieDic, hl9308PictureBox.CreateGraphics());
                }
            }
        }

        private void zThresholdTextBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (productComboBox.Text != "")
            {
                int locationX = this.Location.X + thresholdPanel.Location.X + zThresholdTextBox2.Location.X + zThresholdTextBox2.Width + 10;
                int locationY = this.Location.Y + thresholdPanel.Location.Y + zThresholdTextBox2.Location.Y + 25;

                LoginForm form = new LoginForm(locationX, locationY);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                }
                else
                {
                    this.ActiveControl = logoPictureBox;
                }
            }
        }

        private void zThresholdTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(productComboBox.Text != "")
            {
                double threshold;

                if (e.KeyChar >= (Char)48 && e.KeyChar <= (Char)57 || e.KeyChar == (Char)8)
                    e.Handled = false;
                else if(e.KeyChar == (Char)13)
                {
                    if (Parameter.CurrentDevice == DeviceType.HL9309)
                    {
                        Double.TryParse(zThresholdTextBox2.Text, out threshold);

                        Parameter.DeviceHL9309.Z_Threshold = threshold;
                        Sqlite.UpdateZThreshold(Parameter.CurrentDevice, productComboBox.Text, threshold);

                        WaferDrawing(DeviceType.HL9309, Parameter.DeviceHL9309.FilePath, _hl9309WaferDieDic, hl9309PictureBox.CreateGraphics());
                    }
                    else
                    {
                        Double.TryParse(zThresholdTextBox2.Text, out threshold);

                        Parameter.DeviceHL9308.Z_Threshold = threshold;
                        Sqlite.UpdateZThreshold(Parameter.CurrentDevice, productComboBox.Text, threshold);

                        WaferDrawing(DeviceType.HL9308, Parameter.DeviceHL9308.FilePath, _hl9308WaferDieDic, hl9308PictureBox.CreateGraphics());
                    }

                    this.ActiveControl = logoPictureBox;
                    e.Handled = false;
                }
                else if (e.KeyChar == (Char)46)
                {
                    if (zThresholdTextBox2.Text.Contains('.'))
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ePercentTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (productComboBox.Text != "")
            {
                int locationX = this.Location.X + thresholdPanel.Location.X + ePercentTextBox.Location.X + ePercentTextBox.Width + 10;
                int locationY = this.Location.Y + thresholdPanel.Location.Y + ePercentTextBox.Location.Y + 25;

                LoginForm form = new LoginForm(locationX, locationY);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                }
                else
                {
                    this.ActiveControl = logoPictureBox;
                }
            }
        }

        private void ePercentTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (productComboBox.Text != "")
            {
                int percent = 10;

                if (e.KeyChar >= (Char)48 && e.KeyChar <= (Char)57 || e.KeyChar == (Char)8)
                {
                    e.Handled = false;
                }
                else if (e.KeyChar == (Char)13)
                {
                    Int32.TryParse(ePercentTextBox.Text, out percent);

                    if (Parameter.CurrentDevice == DeviceType.HL9309)
                    {
                        Parameter.DeviceHL9309.Energy_Percent = percent;
                    }
                    else
                    {
                        Parameter.DeviceHL9308.Energy_Percent = percent;
                    }

                    Sqlite.UpdateEnergyPercent(Parameter.CurrentDevice, productComboBox.Text, percent);

                    this.ActiveControl = logoPictureBox;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void eThresholdTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (productComboBox.Text != "")
            {
                int locationX = this.Location.X + thresholdPanel.Location.X + eThresholdTextBox.Location.X + eThresholdTextBox.Width + 10;
                int locationY = this.Location.Y + thresholdPanel.Location.Y + eThresholdTextBox.Location.Y + 25;

                LoginForm form = new LoginForm(locationX, locationY);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                }
                else
                {
                    this.ActiveControl = logoPictureBox;
                }
            }
        }

        private void eThresholdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (productComboBox.Text != "")
            {
                double threshold = 10.00;

                if (e.KeyChar >= (Char)48 && e.KeyChar <= (Char)57 || e.KeyChar == (Char)8)
                {
                    e.Handled = false;
                }
                else if (e.KeyChar == (Char)13)
                {
                    Double.TryParse(eThresholdTextBox.Text, out threshold);

                    if (Parameter.CurrentDevice == DeviceType.HL9309)
                    {
                        Parameter.DeviceHL9309.Energy_Threshold = threshold;
                    }
                    else
                    {
                        Parameter.DeviceHL9308.Energy_Threshold = threshold;
                    }

                    Sqlite.UpdateEnergyThreshold(Parameter.CurrentDevice, productComboBox.Text, threshold);

                    this.ActiveControl = logoPictureBox;
                }
                else if (e.KeyChar == (Char)46)
                {
                    if (eThresholdTextBox.Text.Contains('.'))
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void lsPercentTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (productComboBox.Text != "")
            {
                int locationX = this.Location.X + thresholdPanel.Location.X + lsPercentTextBox.Location.X + lsPercentTextBox.Width + 10;
                int locationY = this.Location.Y + thresholdPanel.Location.Y + lsPercentTextBox.Location.Y;

                LoginForm form = new LoginForm(locationX, locationY);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                }
                else
                {
                    this.ActiveControl = logoPictureBox;
                }
            }
        }

        private void lsPercentTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (productComboBox.Text != "")
            {
                int percent = 10;

                if (e.KeyChar >= (Char)48 && e.KeyChar <= (Char)57 || e.KeyChar == (Char)8)
                {
                    e.Handled = false;
                }
                else if (e.KeyChar == (Char)13)
                {
                    Int32.TryParse(lsPercentTextBox.Text, out percent);

                    if (Parameter.CurrentDevice == DeviceType.HL9309)
                    {
                        Parameter.DeviceHL9309.Stability_Percent = percent;
                    }
                    else
                    {
                        Parameter.DeviceHL9308.Stability_Percent = percent;
                    }

                    Sqlite.UpdateStabilityPercent(Parameter.CurrentDevice, productComboBox.Text, percent);
                    this.ActiveControl = logoPictureBox;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void lsThresholdTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (productComboBox.Text != "")
            {
                int locationX = this.Location.X + thresholdPanel.Location.X + lsThresholdTextBox.Location.X + lsThresholdTextBox.Width + 10;
                int locationY = this.Location.Y + thresholdPanel.Location.Y + lsThresholdTextBox.Location.Y;

                LoginForm form = new LoginForm(locationX, locationY);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                }
                else
                {
                    this.ActiveControl = logoPictureBox;
                }
            }
        }

        private void lsThresholdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (productComboBox.Text != "")
            {
                double threshold = 10.00;

                if (e.KeyChar >= (Char)48 && e.KeyChar <= (Char)57 || e.KeyChar == (Char)8)
                {
                    e.Handled = false;
                }
                else if (e.KeyChar == (Char)13)
                {
                    Double.TryParse(lsThresholdTextBox.Text, out threshold);

                    if (Parameter.CurrentDevice == DeviceType.HL9309)
                    {
                        Parameter.DeviceHL9309.Stability_Threshold = threshold;
                    }
                    else
                    {
                        Parameter.DeviceHL9308.Stability_Threshold = threshold;
                    }

                    Sqlite.UpdateStabilityThreshold(Parameter.CurrentDevice, productComboBox.Text, threshold);

                    this.ActiveControl = logoPictureBox;
                }
                else if (e.KeyChar == (Char)46)
                {
                    if (lsThresholdTextBox.Text.Contains('.'))
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void refenceTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (productComboBox.Text != "")
            {
                int locationX = this.Location.X + thresholdPanel.Location.X + refenceTextBox.Location.X + refenceTextBox.Width + 10;
                int locationY = this.Location.Y + thresholdPanel.Location.Y + refenceTextBox.Location.Y - 100;

                LoginForm form = new LoginForm(locationX, locationY);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                }
                else
                {
                    this.ActiveControl = logoPictureBox;
                }
            }
        }

        private void refenceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (productComboBox.Text != "")
            {
                int refence = 10;

                if (e.KeyChar >= (Char)48 && e.KeyChar <= (Char)57 || e.KeyChar == (Char)8)
                {
                    e.Handled = false;
                }
                else if (e.KeyChar == (Char)13)
                {
                    Int32.TryParse(refenceTextBox.Text, out refence);

                    if (Parameter.CurrentDevice == DeviceType.HL9309)
                    {
                        Parameter.DeviceHL9309.Refence = refence;
                    }
                    else
                    {
                        Parameter.DeviceHL9308.Refence = refence;
                    }

                    Sqlite.UpdateRefence(Parameter.CurrentDevice, productComboBox.Text, refence);
                    this.ActiveControl = logoPictureBox;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void hl9309PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle rec;
            string[] points;
            int x, y, width, height;
            WaferDie die;

            foreach (string key in _hl9309WaferDieDic.Keys)
            {
                points = key.Split(',');

                if (points.Length >= 4)
                {
                    Int32.TryParse(points[0], out x);
                    Int32.TryParse(points[1], out y);
                    Int32.TryParse(points[2], out width);
                    Int32.TryParse(points[3], out height);

                    rec = new Rectangle(x, y, width, height);

                    if (rec.Contains(e.Location))
                    {
                        die = _hl9309WaferDieDic[key];
                        toolTip1.SetToolTip(hl9309PictureBox, "Z=" + die.z.ToString("#0.00") + "μm\nE=" + die.energy.ToString("#0.00") + "μJ");
                        break;
                    }
                }
            }
        }

        private void hl9308PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle rec;
            string[] points;
            int x, y, width, height;
            WaferDie die;

            foreach (string key in _hl9308WaferDieDic.Keys)
            {
                points = key.Split(',');

                if (points.Length >= 4)
                {
                    Int32.TryParse(points[0], out x);
                    Int32.TryParse(points[1], out y);
                    Int32.TryParse(points[2], out width);
                    Int32.TryParse(points[3], out height);

                    rec = new Rectangle(x, y, width, height);

                    if (rec.Contains(e.Location))
                    {
                        die = _hl9308WaferDieDic[key];
                        toolTip1.SetToolTip(hl9308PictureBox, "Z=" + die.z.ToString("#0.00") + "μm\nE=" + die.energy.ToString("#0.00") + "%");
                        break;
                    }
                }
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            if (productComboBox.Text == "" || fileComboBox.Text == "")
                return;

            int result;
            string excelFile, device;
            Dictionary<string, WaferDie> wafers = new Dictionary<string, WaferDie>();

            if (Parameter.CurrentDevice == DeviceType.HL9309)
            {
                if (_hl9309WaferDieDic.Count == 0)
                    return;

                device = "1HL9309";
                excelFile = Path.GetDirectoryName(Parameter.DeviceHL9309.FilePath) + "\\" + Path.GetFileNameWithoutExtension(Parameter.DeviceHL9309.FilePath) + ".xlsx";
                
                foreach (string key in _hl9309WaferDieDic.Keys)
                    wafers.Add(key, _hl9309WaferDieDic[key]);
            }
            else
            {
                if (_hl9308WaferDieDic.Count == 0)
                    return;

                device = "1HL9308";
                excelFile = Path.GetDirectoryName(Parameter.DeviceHL9308.FilePath) + "\\" + Path.GetFileNameWithoutExtension(Parameter.DeviceHL9308.FilePath) + ".xlsx";

                foreach (string key in _hl9308WaferDieDic.Keys)
                    wafers.Add(key, _hl9308WaferDieDic[key]);
            }

            Application.UseWaitCursor = true;
            this.Cursor = Cursors.WaitCursor;
            EnableControls(false);

            result = WaferFile.SaveToExcel(excelFile, device, productComboBox.Text, fileComboBox.Text, wafers);

            if(result == 0)
                MessageBox.Show("Save to " + excelFile, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            EnableControls(true);
            Application.UseWaitCursor = false;
            this.Cursor = Cursors.Default;

            wafers.Clear();
            wafers = null;

            GC.Collect();
        }

        private void histroyLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (productComboBox.Text == "")
                return;

            HistoryListForm form = new HistoryListForm(this.Left + 2, this.Top + logoPanel.Height + 28, this.Width - 4, this.Height - logoPanel.Height - 28);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
            }
        }

        private void ChangeColor(object sender, Color color)
        {
            RoundButton btn = (RoundButton)sender;
            Pen pen = new Pen(color);
            SolidBrush brush = new SolidBrush(color);

            btn.CreateGraphics().DrawEllipse(pen, 0, 0, 22, 22);
            btn.CreateGraphics().FillEllipse(brush, 0, 0, 22, 22);
            pen.Dispose();
        }

        private void HL930_Run()
        {
            _Run = true;
            DateTime runTime = new DateTime();
            string product = "";

            while (_Run)
            {
                if (_refreshMain)
                {
                    _refreshMain = false;

                    this.Invoke(new EventHandler(delegate
                    {
                        this.UseWaitCursor = true;
                        EnableControls(false);
                        product = productComboBox.Text;
                    }));

                    RefreshWafer(Parameter.CurrentDevice, product);

                    this.Invoke(new EventHandler(delegate
                    { 
                        EnableControls(true);
                        this.UseWaitCursor = false;
                    }));
                }

                if (DateTime.Now >= runTime.AddSeconds(30))
                {
                    runTime = DateTime.Now;
                    RefreshWafer(DeviceType.HL9309, Parameter.DeviceHL9309.ProductName);
                    RefreshWafer(DeviceType.HL9308, Parameter.DeviceHL9308.ProductName);
                }

                Thread.Sleep(200);
            }
        }

        private void RefreshWafer(DeviceType deviceType, string product)
        {
            if (product == "")
                return;

            string filename;
            Graphics graphics;
            Dictionary<string, WaferDie> wafers = new Dictionary<string, WaferDie>();

            filename = FTPClient.DownloadFile(Parameter.CurrentDevice, product);

            if (File.Exists(filename))
            {
                WaferFile.GetInfo(Parameter.CurrentDevice, filename, ref wafers);

                if (deviceType == DeviceType.HL9309)
                {
                    Parameter.DeviceHL9309.FilePath = filename;
                    graphics = hl9309PictureBox.CreateGraphics();

                    _hl9309WaferDieDic.Clear();
                    foreach (string key in wafers.Keys)
                        _hl9309WaferDieDic.Add(key, wafers[key]);
                }
                else
                {
                    Parameter.DeviceHL9308.FilePath = filename;
                    graphics = hl9308PictureBox.CreateGraphics();

                    _hl9308WaferDieDic.Clear();
                    foreach (string key in wafers.Keys)
                        _hl9308WaferDieDic.Add(key, wafers[key]);
                }

                this.Invoke(new EventHandler(delegate
                {
                    if (Parameter.CurrentDevice == deviceType)
                        fileComboBox.Text = Path.GetFileName(filename);

                    WaferDrawing(deviceType, filename, wafers, graphics);
                }));
            }

            wafers.Clear();
            wafers = null;
        }

        private void WaferDrawing(DeviceType devicetype, string filename, Dictionary<string, WaferDie> wafers, Graphics graphics)
        {
            if (wafers.Count == 0)
                return;

            EventLog.Write("WaferDrawing Start");

            Pen pen = new Pen(SystemColors.ControlDark, 1);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Font font = new Font(new FontFamily("Times New Roman"), 10, FontStyle.Regular, GraphicsUnit.Pixel);
            Color color1, color2, zColor = Color.Black, eColor = Color.Black;
            int x, y, width, height;
            bool beep = false, alreadyShow = false;
            double zValue = 0.0, energyValue = 0.0;
            double zThreshold = 10.0, energyThreshold = 1, percentage;
            int energyPercent = 10;
            WaferDie die;
            PointF pointF;
            string[] points;

            if (devicetype == DeviceType.HL9309)
            {
                hl9309PictureBox.Refresh();
                zThreshold = Parameter.DeviceHL9309.Z_Threshold;
                energyThreshold = Parameter.DeviceHL9309.Energy_Threshold;
                energyPercent = Parameter.DeviceHL9309.Energy_Percent;
                color1 = Parameter.DeviceHL9309.DieColor1;
                color2 = Parameter.DeviceHL9309.DieColor2;
            }
            else
            {
                hl9308PictureBox.Refresh();
                zThreshold = Parameter.DeviceHL9308.Z_Threshold;
                energyThreshold = Parameter.DeviceHL9308.Energy_Threshold;
                energyPercent = Parameter.DeviceHL9308.Energy_Percent;
                color1 = Parameter.DeviceHL9308.DieColor1;
                color2 = Parameter.DeviceHL9308.DieColor2;
            }

            foreach (string key in wafers.Keys)
            {
                points = key.Split(',');

                if (points.Length >= 4)
                {
                    try
                    {
                        Int32.TryParse(points[0], out x);
                        Int32.TryParse(points[1], out y);
                        Int32.TryParse(points[2], out width);
                        Int32.TryParse(points[3], out height);

                        die = wafers[key];

                        solidBrush.Color = (Math.Abs(die.z) > zThreshold) ? color2 : color1;

                        if (graphics != null)
                            graphics.FillRectangle(solidBrush, x, y, width, height);

                        pointF = new PointF(x + (width - 9) / 2, y + (height - 9) / 2 - 2);
                        solidBrush.Color = Color.Black;

                        if (graphics != null)
                            graphics.DrawString(Convert.ToInt32(die.z).ToString(), font, solidBrush, pointF);

                        if (Math.Abs(die.z) >= zThreshold)
                        {
                            zValue = die.z;
                            zColor = Color.Red;
                            beep = true;
                        }

                        if (die.energy >= energyThreshold)
                            percentage = ((die.energy / energyThreshold) - 1) * 100;
                        else
                            percentage = (1 - (die.energy / energyThreshold)) * 100;

                        if (percentage > energyPercent)
                        {
                            energyValue = die.energy;
                            eColor = Color.Red;
                            beep = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.Write(ex.Message);
                    }
                }
            }

            if (beep)
            {
                FormCollection forms = Application.OpenForms;

                foreach (Form form in forms)
                {
                    if (form.Text.CompareTo(devicetype.ToString() + Path.GetFileName(filename)) == 0)
                    {
                        alreadyShow = true;
                        break;
                    }
                }

                if (!alreadyShow)
                {
                    NotifyForm form = new NotifyForm(devicetype, Path.GetFileName(filename), zValue, zColor, energyValue, eColor);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Show();
                }
            }

            EventLog.Write("WaferDrawing End");
        }

        private void EnableControls(bool enable)
        {
            productComboBox.Enabled = enable;
            histroyLabel.Enabled = enable;
            fileComboBox.Enabled = enable;
            hl9309Btn.Enabled = enable;
            hl9308Btn.Enabled = enable;
            exportBtn.Enabled = enable;
            zThresholdTextBox2.Enabled = enable;
            ePercentTextBox.Enabled = enable;
            eThresholdTextBox.Enabled = enable;
            lsPercentTextBox.Enabled = enable;
            lsThresholdTextBox.Enabled = enable;
            refenceTextBox.Enabled = enable;
            hl9309PictureBox.Enabled = enable;
            hl9308PictureBox.Enabled = enable;
        }
    }      
}