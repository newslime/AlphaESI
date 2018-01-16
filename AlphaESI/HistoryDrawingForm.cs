using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AlphaESI
{
    public partial class HistoryDrawingForm : Form
    {
        Dictionary<string, WaferDie> _WaferDieDic = new Dictionary<string, WaferDie>();
        string _Filepath = "";
     
        public HistoryDrawingForm(string filepath)
        {
            InitializeComponent();

            nameLabel.Text = Path.GetFileName(filepath);
            exportBtn.Location = new Point(nameLabel.Location.X + nameLabel.Width + 20, nameLabel.Location.Y - 5);
            pictureBox1.Location = new Point(this.Width / 2 - pictureBox1.Width / 2, nameLabel.Location.Y + nameLabel.Height + 30);
            closeBtn.Location = new Point(pictureBox1.Location.X + pictureBox1.Width - closeBtn.Width, nameLabel.Location.Y);

            _Filepath = filepath;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(SystemColors.ControlDark, 1);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Font font = new Font(new FontFamily("Times New Roman"), 10, FontStyle.Regular, GraphicsUnit.Pixel);
            Color color1, color2;
            int x, y, width, height;
            double zThreshold;
            WaferDie die;
            PointF pointF;
            string[] points;

            for (int i = 0; i < 55; i++)
            {
                for (int j = 0; j < 55; j++)
                {
                    e.Graphics.DrawRectangle(pen, i * 10, j * 10, 10, 10);
                }
            }

            if (Parameter.CurrentDevice == DeviceType.HL9309)
            {
                zThreshold = Parameter.DeviceHL9309.Z_Threshold;
                color1 = Parameter.DeviceHL9309.DieColor1;
                color2 = Parameter.DeviceHL9309.DieColor2;
            }
            else
            {
                zThreshold = Parameter.DeviceHL9308.Z_Threshold;
                color1 = Parameter.DeviceHL9308.DieColor1;
                color2 = Parameter.DeviceHL9308.DieColor2;
            }

            foreach (string key in _WaferDieDic.Keys)
            {
                points = key.Split(',');

                if (points.Length >= 4)
                {
                    Int32.TryParse(points[0], out x);
                    Int32.TryParse(points[1], out y);
                    Int32.TryParse(points[2], out width);
                    Int32.TryParse(points[3], out height);

                    die = _WaferDieDic[key];

                    solidBrush.Color = (Math.Abs(die.z) > zThreshold) ? color2 : color1;

                    e.Graphics.FillRectangle(solidBrush, x, y, width, height);

                    pointF = new PointF(x + (width - 9) / 2, y + (height - 9) / 2 - 2);
                    solidBrush.Color = Color.Black;
                    e.Graphics.DrawString(Convert.ToInt32(die.z).ToString(), font, solidBrush, pointF);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WaferDrawing(string filepath, Graphics graphics)
        {
            Pen pen = new Pen(SystemColors.ControlDark, 1);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Font font = new Font(new FontFamily("Times New Roman"), 10, FontStyle.Regular, GraphicsUnit.Pixel);
            Color color1, color2;
            int x, y, width, height;
            double zThreshold;
            WaferDie die;
            PointF pointF;
            string[] points;

            pictureBox1.Refresh();

            _WaferDieDic.Clear();
            WaferFile.GetInfo(Parameter.CurrentDevice, filepath, ref _WaferDieDic);

            if (Parameter.CurrentDevice == DeviceType.HL9309)
            {
                zThreshold = Parameter.DeviceHL9309.Z_Threshold;
                color1 = Parameter.DeviceHL9309.DieColor1;
                color2 = Parameter.DeviceHL9309.DieColor2;
            }
            else
            {
                zThreshold = Parameter.DeviceHL9308.Z_Threshold;
                color1 = Parameter.DeviceHL9308.DieColor1;
                color2 = Parameter.DeviceHL9308.DieColor2;
            }

            foreach (string key in _WaferDieDic.Keys)
            {
                points = key.Split(',');

                if (points.Length >= 4)
                {
                    Int32.TryParse(points[0], out x);
                    Int32.TryParse(points[1], out y);
                    Int32.TryParse(points[2], out width);
                    Int32.TryParse(points[3], out height);

                    die = _WaferDieDic[key];

                    solidBrush.Color = (Math.Abs(die.z) > zThreshold) ? color2 : color1;

                    graphics.FillRectangle(solidBrush, x, y, width, height);

                    pointF = new PointF(x + (width - 9) / 2, y + (height - 9) / 2 - 2);
                    solidBrush.Color = Color.Black;
                    graphics.DrawString(Convert.ToInt32(die.z).ToString(), font, solidBrush, pointF);
                }
            }
        }

        private void HistoryDrawingForm_Load(object sender, EventArgs e)
        {
            WaferDrawing(_Filepath, pictureBox1.CreateGraphics());
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle rec;
            string[] points;
            int x, y, width, height;
            WaferDie die;

            foreach (string key in _WaferDieDic.Keys)
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
                        die = _WaferDieDic[key];
                        toolTip1.SetToolTip(pictureBox1, "Z=" + die.z.ToString("#0.00") + "\nE=" + die.energy.ToString("#0.000") + "μ");
                        break;
                    }
                }
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            if (_WaferDieDic.Count == 0)
                return;

            string device, product, excelFile;
  
            if (Parameter.CurrentDevice == DeviceType.HL9309)
            {
                device = "1HL9309";
                product =Parameter.DeviceHL9309.ProductName;
                excelFile = Path.GetDirectoryName(Parameter.DeviceHL9309.FilePath) + "\\" + Path.GetFileNameWithoutExtension(Parameter.DeviceHL9309.FilePath) + ".xlsx";
            }
            else
            {
                device = "1HL9308";
                product =Parameter.DeviceHL9308.ProductName;
                excelFile = Path.GetDirectoryName(Parameter.DeviceHL9308.FilePath) + "\\" + Path.GetFileNameWithoutExtension(Parameter.DeviceHL9308.FilePath) + ".xlsx";
            }

            Application.UseWaitCursor = true;
            this.Cursor = Cursors.WaitCursor;
            exportBtn.Enabled = false;
            closeBtn.Enabled = false;

            if(WaferFile.SaveToExcel(excelFile, device, product, Path.GetFileName(_Filepath), _WaferDieDic) == 0)
                MessageBox.Show("Save to " + excelFile, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            exportBtn.Enabled = true;
            closeBtn.Enabled = true;
            Application.UseWaitCursor = false;
            this.Cursor = Cursors.Default;
        }
    }
}
