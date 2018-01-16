using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace AlphaESI
{
    public partial class HistoryListForm : Form
    {
        List<string> _historyList = new List<string>();
        List<string> _fileList = new List<string>();

        uTextBox keyTextBox1;
        uTextBox keyTextBox2;
        uTextBox searchTextBox;

        private DataSet ds;
        private const int _columns = 2;

        public HistoryListForm(int x, int y, int width, int height)
        {
            InitializeComponent();

            this.Location = new Point(x, y);
            this.Width = width;
            this.Height = height;

            searchTextBox = new uTextBox();
            searchTextBox.TipFont = new Font("微軟正黑體", 9);
            searchTextBox.TipColor = Color.FromArgb(243, 243, 243);
            searchTextBox.TipText = "               Search";
            searchTextBox.Font = new Font("微軟正黑體", 10);
            searchTextBox.TextAlign = HorizontalAlignment.Center;
            searchTextBox.ForeColor = Color.FromArgb(255, 255, 255);
            searchTextBox.AutoSize = false;
            searchTextBox.Size = new Size(150, 25);
            searchTextBox.Location = new Point(historyLabel.Location.X + historyLabel.Width + 10, historyLabel.Location.Y);
            searchTextBox.BackColor = Color.FromArgb(50, 54, 66);
            searchTextBox.BorderStyle = BorderStyle.FixedSingle;
            searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchTextBox_KeyPress);
            searchTextBox.Click += new System.EventHandler(this.searchTextBox_Click);
            this.Controls.Add(searchTextBox);

            searchLabel.Size = searchLabel.Image.Size;
            searchLabel.Parent = searchTextBox;
            searchLabel.Location = new Point(5, searchTextBox.Height / 2 - searchLabel.Height / 2);

            waferListBox.Width = this.Width - 60;
            waferListBox.Height = this.Height - historyLabel.Location.Y - historyLabel.Height - 30;
            waferListBox.Location = new Point(historyLabel.Location.X, historyLabel.Location.Y + historyLabel.Height + 20);

            string[,] historyList = GetHistoryList();
            ds = AsYetUnnamed.DataArray.ToDataSet(historyList);
            waferListBox.ColumnWidths[0] = 200;
            waferListBox.ColumnWidths[1] = 200;
            waferListBox.DataSource = ds.Tables[0];

            searchPanel.Width = this.Width;

            keyTextBox1 = new uTextBox();
            keyTextBox1.TipFont = new Font("微軟正黑體", 10, FontStyle.Underline);
            keyTextBox1.TipColor = Color.FromArgb(243, 243, 243);
            keyTextBox1.TipText = "Time...";
            keyTextBox1.Font = new Font("微軟正黑體", 12, FontStyle.Underline);
            keyTextBox1.TextAlign = HorizontalAlignment.Left;
            keyTextBox1.ForeColor = Color.FromArgb(43, 129, 178);
            keyTextBox1.AutoSize = false;
            keyTextBox1.Size = new Size(150, 25);
            keyTextBox1.Location = new Point(50, 12);
            keyTextBox1.BackColor = Color.FromArgb(211,210, 211);
            keyTextBox1.BorderStyle = BorderStyle.None;
            keyTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyTextBox1_KeyUp);
            searchPanel.Controls.Add(keyTextBox1);

            keyTextBox2 = new uTextBox();
            keyTextBox2.TipFont = new Font("微軟正黑體", 10, FontStyle.Underline);
            keyTextBox2.TipColor = Color.FromArgb(243, 243, 243);
            keyTextBox2.TipText = "Name...";
            keyTextBox2.Font = new Font("微軟正黑體", 12, FontStyle.Underline);
            keyTextBox2.TextAlign = HorizontalAlignment.Left;
            keyTextBox2.ForeColor = Color.FromArgb(43, 129, 178);
            keyTextBox2.AutoSize = false;
            keyTextBox2.Size = new Size(150, 25);
            keyTextBox2.Location = new Point(keyTextBox1.Location.X + keyTextBox1.Width + 100, 12);
            keyTextBox2.BackColor = Color.FromArgb(211, 210, 211);
            keyTextBox2.BorderStyle = BorderStyle.None;
            keyTextBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyTextBox2_KeyUp);
            searchPanel.Controls.Add(keyTextBox2);
        }

        private string[,] GetHistoryList()
        {
            string[,] historyList;

            string name = "", filepath;
            DateTime dateTime = new DateTime();

            if (Parameter.CurrentDevice == DeviceType.HL9309)
            {
                filepath = Parameter.DeviceHL9309.HistoryPath + Parameter.DeviceHL9309.ProductName;
            }
            else
            {
                filepath = Parameter.DeviceHL9308.HistoryPath + Parameter.DeviceHL9308.ProductName;
            }

            string[] directories = Directory.GetDirectories(filepath);

            if (directories.Length == 0)
            {
                historyList = new string[1, _columns];
                historyList[0, 0] = "NULL";
                historyList[0, 1] = "NULL";
                return historyList; 
            }

            historyList = new string[directories.Length, _columns];

            for (int i = 0; i < directories.Length; i++ )
            {
                string[] files = Directory.GetFiles(directories[i]);

                if (files == null)
                    continue;

                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".log")
                    {
                        using (StreamReader sr = new StreamReader(file))
                        {
                            string line;
                            string keyword = "Starting processing";
                            string[] tempStr; ;

                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line.Contains(keyword))
                                {
                                    tempStr = line.Substring(0, line.IndexOf(keyword)).Split(' ');
                                    if (tempStr.Length >= 5)
                                    {
                                        dateTime = Convert.ToDateTime(string.Format("{0}/{1}/{2} {3}", tempStr[1], tempStr[2], tempStr[4], tempStr[3]));
                                    }
                                    break;
                                }
                            }
                            sr.Close();
                        }
                    }
                    else if (Path.GetExtension(file) == ".pmon")
                    {
                        name = Path.GetFileName(file);
                        string filea = file.Replace(@"/", @"\");
                        _fileList.Add(filea);
                    }
                }

                historyList[i, 0] = string.Format("{0:yyyy/MM/dd}", dateTime);
                historyList[i, 1] = name;

                _historyList.Add(string.Format("{0:yyyy/MM/dd},{1}", dateTime, name));
            }

            return historyList;
        }

        private void HistoryForm_Click(object sender, EventArgs e)
        {
            searchPanel.Visible = false;
            waferListBox.Height = this.Height - historyLabel.Location.Y - historyLabel.Height - 30;
            waferListBox.Location = new Point(historyLabel.Location.X, historyLabel.Location.Y + historyLabel.Height + 20);
            
            this.ActiveControl = historyLabel;
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void searchTextBox_Click(object sender, EventArgs e)
        {
            searchPanel.Visible = true;
            searchPanel.Location = new Point(0, historyLabel.Location.Y + historyLabel.Height + 30);
            waferListBox.Location = new Point(historyLabel.Location.X, searchPanel.Location.Y + searchPanel.Height + 20);
            waferListBox.Height = this.Height - searchPanel.Location.Y - searchPanel.Height - 30;
        }

        private void keyTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string[] matches1 = Array.FindAll(_historyList.ToArray(), x => (x.IndexOf(keyTextBox1.Text, StringComparison.OrdinalIgnoreCase) != -1)/* && !SelectedValues.Contains(x)*/);
            string[] matches2 = Array.FindAll(_historyList.ToArray(), x => (x.IndexOf(keyTextBox2.Text, StringComparison.OrdinalIgnoreCase) != -1)/* && !SelectedValues.Contains(x)*/);
            List<string> result = new List<string>();

            waferListBox.DataSource = null;

            for (int i = 0; i < matches1.Length; i++)
            {
                for (int j = 0; j < matches2.Length; j++)
                {
                    if (matches1[i].CompareTo(matches2[j]) == 0)
                    {
                        result.Add(matches1[i]);
                    }
                }
            }

            if (result.Count > 0)
            {
                string[,] historyList = new string[result.Count, _columns];

                for (int i = 0; i < result.Count; i++)
                {
                    string[] names = result[i].Split(',');
                    historyList[i, 0] = names[0];
                    historyList[i, 1] = names[1];
                }

                ds = AsYetUnnamed.DataArray.ToDataSet(historyList);
                waferListBox.DataSource = ds.Tables[0];
            }
            else
            {
                string[,] historyList = new string[1, _columns];

                historyList[0, 0] = "NULL";
                historyList[0, 1] = "NULL";

                ds = AsYetUnnamed.DataArray.ToDataSet(historyList);
                waferListBox.DataSource = ds.Tables[0];
            }
        }

        private void keyTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            string[] matches1 = Array.FindAll(_historyList.ToArray(), x => (x.IndexOf(keyTextBox1.Text, StringComparison.OrdinalIgnoreCase) != -1)/* && !SelectedValues.Contains(x)*/);
            string[] matches2 = Array.FindAll(_historyList.ToArray(), x => (x.IndexOf(keyTextBox2.Text, StringComparison.OrdinalIgnoreCase) != -1)/* && !SelectedValues.Contains(x)*/);
            List<string> result = new List<string>();

            waferListBox.DataSource = null;

            for (int i = 0; i < matches1.Length; i++)
            {
                for (int j = 0; j < matches2.Length; j++)
                {
                    if (matches1[i].CompareTo(matches2[j]) == 0)
                    {
                        result.Add(matches1[i]);
                    }
                }
            }

            if (result.Count > 0)
            {
                string[,] historyList = new string[result.Count, _columns];

                for (int i = 0; i < result.Count; i++)
                {
                    string[] names = result[i].Split(',');
                    historyList[i, 0] = names[0];
                    historyList[i, 1] = names[1];
                }

                ds = AsYetUnnamed.DataArray.ToDataSet(historyList);
                waferListBox.DataSource = ds.Tables[0];
            }
            else
            {
                string[,] historyList = new string[1, _columns];

                historyList[0, 0] = "NULL";
                historyList[0, 1] = "NULL";

                ds = AsYetUnnamed.DataArray.ToDataSet(historyList);
                waferListBox.DataSource = ds.Tables[0];
            }
        }

        private void waferListBox_DoubleClick(object sender, EventArgs e)
        {
            string name = waferListBox.GetItemAt(waferListBox.SelectedIndex, 1).ToString();

            foreach (string file in _fileList)
            {
                if (Path.GetFileName(file).CompareTo(name) == 0)
                {
                    HistoryDrawingForm form = new HistoryDrawingForm(file);

                    form.ShowDialog(this);
                    break;
                }
            }
        }

        private void waferListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel.Worksheet xlWorksheet = null;
            Excel.Sheets xlSheets = null;
            Excel.Range xlRange;

            int startX, startY, endX, endY, value, column, index = 2;
            string filename, filepath, device, product, savepath = "";
            WaferDie die;
            string[] points;
            string[] title = { "Device", "Product", "Filename", "Focus Field", "Z", "Average laser energy", "Laser stability" };
            Dictionary<string, WaferDie> waferdies = new Dictionary<string, WaferDie>();

            Application.UseWaitCursor = true;
            this.Cursor = Cursors.WaitCursor;

            backBtn.Enabled = false;
            searchTextBox.Enabled = false;
            waferListBox.Enabled = false;

            if (waferListBox.SelectedIndices.Count > 0)
            {
                if (Parameter.CurrentDevice == DeviceType.HL9309)
                {
                    device = "1HL9309";
                    product = Parameter.DeviceHL9309.ProductName;
                    filepath = Parameter.DeviceHL9309.HistoryPath + product + "/";
                }
                else
                {
                    device = "1HL9308";
                    product = Parameter.DeviceHL9308.ProductName;
                    filepath = Parameter.DeviceHL9308.HistoryPath + product + "/";
                }

                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
                xlSheets = xlWorkbook.Sheets as Excel.Sheets;
                xlApp.Visible = false;
                xlApp.DisplayAlerts = false;

                int count = xlWorkbook.Worksheets.Count;

                for (; count < waferListBox.SelectedIndices.Count; count++)
                    xlWorkbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                for (int i = 0; i < waferListBox.SelectedIndices.Count; i++)
                {
                    try
                    {
                        filename = waferListBox.GetItemAt(waferListBox.SelectedIndices[i], 1).ToString();
                        filename = filepath + Path.GetFileNameWithoutExtension(filename) + ".wafer/" + filename;
                        if (File.Exists(filename))
                        {

                            WaferFile.GetInfo(Parameter.CurrentDevice, filename, ref waferdies);

                            xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets[i + 1];
                            xlWorksheet.Name = Path.GetFileNameWithoutExtension(filename) + ".wafer";

                            column = 1;
                            for (int j = 0; j < title.Length; j++)
                            {
                                xlRange = (Excel.Range)xlWorksheet.Cells[column, j + 1];
                                xlRange.Value2 = title[j];
                                xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            }
                            column++;

                            foreach (string key in waferdies.Keys)
                            {
                                points = key.Split(',');

                                if (points.Length >= 4)
                                {
                                    Int32.TryParse(points[0], out value);
                                    startX = (value - Parameter.Offset) / Parameter.RectangleWeight;

                                    Int32.TryParse(points[1], out value);
                                    startY = (value - Parameter.Offset) / Parameter.RectangleWeight;

                                    Int32.TryParse(points[2], out value);
                                    endX = value / Parameter.RectangleWeight + startX;

                                    Int32.TryParse(points[3], out value);
                                    endY = value / Parameter.RectangleWeight + startY;

                                    die = waferdies[key];

                                    try
                                    {
                                        xlRange = (Excel.Range)xlWorksheet.Cells[column, 1];
                                        xlRange.Value2 = device;
                                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                                        xlRange = (Excel.Range)xlWorksheet.Cells[column, 2];
                                        xlRange.Value2 = product;
                                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                                        xlRange = (Excel.Range)xlWorksheet.Cells[column, 3];
                                        xlRange.Value2 = Path.GetFileName(filename);
                                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                                        xlRange = (Excel.Range)xlWorksheet.Cells[column, 4];
                                        string location = string.Format("({0},{1}) ({2},{3})", startX, startY, endX, endY);
                                        xlRange.Value2 = location;
                                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                                        xlRange = (Excel.Range)xlWorksheet.Cells[column, 5];
                                        xlRange.Value2 = die.z.ToString("f2");
                                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                                        xlRange = (Excel.Range)xlWorksheet.Cells[column, 6];
                                        xlRange.Value2 = die.energy.ToString("f2");
                                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                                        xlRange = (Excel.Range)xlWorksheet.Cells[column, 7];
                                        xlRange.Value2 = die.stability.ToString("f2");
                                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                                    }
                                    catch (Exception ex)
                                    {
                                        EventLog.Write(ex.Message);
                                    }

                                    column++;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.Write("SPC: " + ex.Message);
                    }
                }

                savepath = Parameter.SpcPath + device + "_" + product + "_wafers.xlsx";
                while (File.Exists(savepath))
                {
                    savepath = Parameter.SpcPath + device + "_" + product + "_wafers_" + index.ToString() + ".xlsx";
                    index++;
                }

                try
                {
                    xlWorkbook.SaveAs(savepath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                catch (Exception ex)
                {
                    EventLog.Write("SPC: " + ex.Message);
                }

                if (xlApp != null)
                {
                    xlWorkbook.Close(Type.Missing, savepath, Type.Missing);
                    xlApp.Quit();

                    if (xlWorksheet != null)
                    {
                        Marshal.ReleaseComObject(xlWorksheet);
                        xlWorksheet = null;
                    }

                    if (xlWorkbook != null)
                    {
                        Marshal.ReleaseComObject(xlWorkbook);
                        xlWorkbook = null;
                    }

                    Marshal.ReleaseComObject(xlApp);
                    xlApp = null;
                }

                GC.Collect();

                MessageBox.Show("Save to " + savepath, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } //count > 0
            
            Application.UseWaitCursor = false;
            this.Cursor = Cursors.Default;

            backBtn.Enabled = true;
            searchTextBox.Enabled = true;
            waferListBox.Enabled = true;

            waferdies.Clear();
            waferdies = null;
        }
    }
}
