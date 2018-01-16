using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace AlphaESI
{
    public partial class uTextBox : TextBox
    {
        private string _tipText = string.Empty; //提示訊息
        public string TipText
        {
            get { return _tipText; }
            set { _tipText = value; Invalidate(); }
        }

        private Color _tipColor = SystemColors.Highlight; //訊息顏色
        public Color TipColor
        {
            get { return _tipColor; }
            set { _tipColor = value; Invalidate(); }
        }

        private Font _tipFont = DefaultFont; //訊息字型
        public Font TipFont
        {
            get { return _tipFont; }
            set { _tipFont = value; Invalidate(); }
        }

        const int WM_PAINT = 0xF; //繪製的訊息
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT && !string.IsNullOrEmpty(_tipText) && Text.Length == 0 && Enabled && !ReadOnly && !Focused) //判斷TextBox的狀態決定要不要顯示提示訊息
            {
                TextFormatFlags formatFlags = TextFormatFlags.Default; //使用原始設定的對齊方式來顯示提示訊息
                formatFlags = TextFormatFlags.Left;

                Rectangle r = this.ClientRectangle;
                r.Inflate(-5, -5);

                TextRenderer.DrawText(Graphics.FromHwnd(Handle), _tipText, _tipFont, r, _tipColor, BackColor, formatFlags); //畫出提示訊息 

                var dc = GetWindowDC(Handle);
                using (Graphics g = Graphics.FromHdc(dc))
                {
                    Pen p = new Pen(Color.FromArgb(151, 151, 151));
                    g.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
                }
            }
        }

        public uTextBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
    }

    public class RoundButton : UserControl
    {
        //static int index = 1;
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen;
            SolidBrush brush;
            Color color1, color2;

            if (Parameter.CurrentDevice == DeviceType.HL9309)
            {
                color1 = Parameter.DeviceHL9309.DieColor1;
                color2 = Parameter.DeviceHL9309.DieColor2;
            }
            else
            {
                color1 = Parameter.DeviceHL9308.DieColor1;
                color2 = Parameter.DeviceHL9308.DieColor2;
            }

            Form1 form = (Form1)Application.OpenForms["Form1"];

            switch (this.TabIndex)
            {
                case 11:
                    pen = new Pen(color1);
                    brush = new SolidBrush(color1);
                    break;

                case 12:
                    pen = new Pen(color2);
                    brush = new SolidBrush(color2);
                    break;

                default:
                    pen = new Pen(Color.Green);
                    brush = new SolidBrush(Color.Green);
                    break;
            }

            Graphics graphics = e.Graphics;

            // Draw the button in the form of a circle
            graphics.DrawEllipse(pen, 0, 0, 22, 22);
            graphics.FillEllipse(brush, 0, 0, 22, 22);
            pen.Dispose();
            brush.Dispose();
        }
    }
}