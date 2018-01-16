using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace AlphaESI
{
    class WaferFile
    {
        public static void GetInfo(DeviceType deviceType, string filepath, ref Dictionary<string, WaferDie> wafers)
        {
            EventLog.Write("WaferFile.GetInfo Start");
            wafers.Clear();

            if (File.Exists(filepath))
            {
                List<string> dieList = new List<string>();
                List<double> z_values = new List<double>();

                WaferDie waferDie;
                StreamReader sr = null;
                string keyStart = "Start=", keyEnd = "Zmap=", keyZ = "Z=", keyAvg = "Average laser energy", keyStab = "Laser stability";
                string line, stringZ, stringCoor, numbering;
                double valueZ, avgZ, energy, stabilityValue = 0.00;
                int startX = 0, endX = 0, startY = 0, endY = 0;
                int pointX, pointY, widthX, heightY;

                try
                {
                    using (sr = new StreamReader(filepath))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Contains(keyStart))
                            {
                                //get position
                                int tempresult = 0;
                                string[] tempStr = line.Split(',');

                                stringCoor = tempStr[0].Substring(tempStr[0].IndexOf("=") + 1, (tempStr[0].Length - tempStr[0].IndexOf("=") - 1));
                                if (Int32.TryParse(stringCoor, out tempresult))
                                {
                                    startX = tempresult;
                                }

                                stringCoor = tempStr[2].Substring(tempStr[2].IndexOf("=") + 1, (tempStr[2].LastIndexOf("=") - tempStr[2].IndexOf("=") - 1));
                                stringCoor = stringCoor.Substring(0, stringCoor.IndexOf(" "));
                                if (Int32.TryParse(stringCoor, out tempresult))
                                {
                                    startY = tempresult;
                                }

                                stringCoor = tempStr[1].Substring(tempStr[1].LastIndexOf("=") + 1, tempStr[1].Length - tempStr[1].LastIndexOf("=") - 1);
                                if (Int32.TryParse(stringCoor, out tempresult))
                                {
                                    endX = tempresult;
                                }

                                stringCoor = tempStr[1].Substring(tempStr[1].IndexOf("=") + 1, tempStr[1].LastIndexOf("=") - tempStr[1].IndexOf("=") - 1 - 4);
                                if (Int32.TryParse(stringCoor, out tempresult))
                                {
                                    endY = tempresult;
                                }
                            }

                            if (line.Contains(keyZ))
                            {
                                //get z value
                                stringZ = line.Remove(0, line.IndexOf(keyZ) + keyZ.Length).Trim();
                                if (Double.TryParse(stringZ, out valueZ))
                                {
                                    z_values.Add(valueZ);
                                }
                            }

                            if (line.Contains(keyEnd))
                            {
                                //drawing
                                if (z_values.Count > 0)
                                {
                                    avgZ = 0.0f;
                                    for (int i = 0; i < z_values.Count; i++)
                                    {
                                        avgZ += z_values[i];
                                    }
                                    avgZ = avgZ / z_values.Count;

                                    pointX = startX * Parameter.RectangleWeight + Parameter.Offset;
                                    pointY = startY * Parameter.RectangleWeight + Parameter.Offset;
                                    widthX = Parameter.RectangleWeight * (endX - startX);
                                    heightY = Parameter.RectangleWeight * (endY - startY);

                                    waferDie = new WaferDie(avgZ, 0.0, 0.0);
                                    numbering = string.Format("{0},{1},{2},{3}", pointX, pointY, widthX + 9, heightY + 9);

                                    wafers[numbering] = waferDie;
                                    dieList.Add(numbering);

                                    startX = startY = endX = endY = 0;
                                    z_values.Clear();
                                }
                            }

                            if (line.Contains(keyAvg))
                            {
                                //get energy value
                                string tempStr = line.Substring(line.LastIndexOf(" "), line.Length - line.LastIndexOf(" "));
                                Double.TryParse(tempStr, out energy);
                                for (int i = 0; i < dieList.Count; i++)
                                {
                                    waferDie = wafers[dieList[i]];
                                    waferDie.energy = energy;
                                    waferDie.stability = stabilityValue;
                                    wafers[dieList[i]] = waferDie;
                                }
                                dieList.Clear();
                            }

                            if (line.Contains(keyStab))
                            {
                                //get stability value
                                string tempStr = line.Substring(line.LastIndexOf(" "), line.Length - line.LastIndexOf(" "));
                                Double.TryParse(tempStr, out stabilityValue);
                            }
                        }//end of while
                    }
                }
                catch (Exception ex)
                {
                    EventLog.Write(ex.Message);
                }
                finally
                {
                    if (sr != null)
                    {
                        sr.Close();
                        sr = null;
                    }

                    dieList.Clear();
                    z_values.Clear();

                    dieList = null;
                    z_values = null;
                }
            }//End File.Exists

            EventLog.Write("WaferFile.GetInfo End");
        }

        public static string Sort(DeviceType deviceType, string product, string logPath, string historyPath)
        {
            EventLog.Write("WaferFile.Sort Start");

            DateTime dt = new DateTime();
            DateTime fileDt = new DateTime();
            string line, log, pmon, filepath, result = "", sourceDir, destDir, device;
            string[] tempStr;
            Dictionary<string, WaferDie> wafers = new Dictionary<string, WaferDie>();
            StreamReader sr = null;

            if (deviceType == DeviceType.HL9309)
                device = "1HL9303";
            else
                device = "1HL9308";

            string keyword = "Starting processing";

            string[] dirs = Directory.GetDirectories(logPath);

            if (dirs != null)
            {
                foreach (string dir in dirs)
                {
                    try
                    {
                        log = dir + "/" + Path.GetFileNameWithoutExtension(dir) + ".log";
                        pmon = dir + "/" + Path.GetFileNameWithoutExtension(dir) + ".pmon";
                        if (File.Exists(log) && File.Exists(pmon))
                        {
                            using (sr = new StreamReader(log))
                            {
                                while ((line = sr.ReadLine()) != null)
                                {
                                    if (line.Contains(keyword))
                                    {
                                        tempStr = line.Substring(0, line.IndexOf(keyword)).Split(' ');
                                        if (tempStr.Length >= 5)
                                        {
                                            fileDt = Convert.ToDateTime(string.Format("{0}/{1}/{2} {3}", tempStr[1], tempStr[2], tempStr[4], tempStr[3]));
                                        }
                                        break;
                                    }
                                }
                            }

                            if (fileDt > dt)
                            {
                                if (File.Exists(result))
                                {
                                    GetInfo(deviceType, result, ref wafers);
                                    SaveToDB(device, product, Path.GetFileName(result), wafers, dt);

                                    sourceDir = Path.GetDirectoryName(result);
                                    destDir = historyPath + Path.GetFileNameWithoutExtension(result) + ".wafer";

                                    if (Directory.Exists(destDir))
                                        Directory.Delete(destDir, true);

                                    Directory.Move(sourceDir, destDir);
                                }

                                dt = fileDt;
                                result = pmon;
                            }
                            else
                            {
                                filepath = dir + "/" + Path.GetFileNameWithoutExtension(dir) + ".pmon";
                                GetInfo(deviceType, filepath, ref wafers);
                                SaveToDB(device, product, Path.GetFileName(filepath), wafers, fileDt);

                                sourceDir = dir;
                                destDir = historyPath + Path.GetFileName(dir);

                                if (Directory.Exists(destDir))
                                    Directory.Delete(destDir, true);

                                Directory.Move(sourceDir, destDir);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.Write(ex.Message);
                    }
                    finally
                    {
                        if (sr != null)
                        {
                            sr.Close();
                            sr = null;
                        }
                    }
                }
            }

            wafers.Clear();
            wafers = null;

            EventLog.Write("WaferFile.Sort End");

            return result;
        }

        private static void SaveToDB(string device, string product, string filename, Dictionary<string, WaferDie> wafers, DateTime dateTime)
        {
            EventLog.Write("WaferFile.SaveToDB Start");

            int startX, startY, endX, endY, value;
            string field;
            string[] points;
            WaferDie die;
            
            foreach (string key in wafers.Keys)
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

                    die = wafers[key];
                    field = string.Format("({0},{1}) ({2},{3})", startX, startY, endX, endY);

                    OracleClient.InsertWaferValue(device, product, filename, field, die.z, die.energy, die.stability, dateTime);
                }
            }

            wafers.Clear();
            wafers = null;

            EventLog.Write("WaferFile.SaveToDB End");
        }

        public static int SaveToExcel(string excelFile, string device, string product, string filename, Dictionary<string, WaferDie> wafers)
        {
            EventLog.Write("WaferFile.SaveToExcel Start");

            int startX, startY, endX, endY, value, index = 2, result = 0;
            string[] points, title = { "Device", "Product", "Filename", "Focus Field", "Z", "Average laser energy", "Laser stability" };
            WaferDie die;

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(true);

            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlApp.ActiveSheet;
            xlWorksheet.Name = Path.GetFileNameWithoutExtension(filename) + ".wafer";
            Excel.Range xlRange = xlWorksheet.UsedRange;
            xlApp.Visible = false;
            xlApp.DisplayAlerts = false;

            for (int j = 0; j < title.Length; j++)
            {
                xlRange = (Excel.Range)xlWorksheet.Cells[1, j + 1];
                xlRange.Value2 = title[j];
                xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }

            foreach (string key in wafers.Keys)
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

                    die = wafers[key];

                    try
                    {
                        xlRange = (Excel.Range)xlWorksheet.Cells[index, 1];
                        xlRange.Value2 = device;
                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                        xlRange = (Excel.Range)xlWorksheet.Cells[index, 2];
                        xlRange.Value2 = product;
                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                        xlRange = (Excel.Range)xlWorksheet.Cells[index, 3];
                        xlRange.Value2 = filename;
                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                        xlRange = (Excel.Range)xlWorksheet.Cells[index, 4];
                        string location = string.Format("({0},{1}) ({2},{3})", startX, startY, endX, endY);
                        xlRange.Value2 = location;
                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                        xlRange = (Excel.Range)xlWorksheet.Cells[index, 5];
                        xlRange.Value2 = die.z.ToString("f2");
                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                        xlRange = (Excel.Range)xlWorksheet.Cells[index, 6];
                        xlRange.Value2 = die.energy.ToString("f2");
                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                        xlRange = (Excel.Range)xlWorksheet.Cells[index, 7];
                        xlRange.Value2 = die.stability.ToString("f2");
                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                    catch (Exception ex)
                    {
                        EventLog.Write(ex.Message);
                    }

                    index++;
                }
            }

            try
            {
                xlWorkbook.SaveAs(excelFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch (Exception ex)
            {
                result = -1;
                EventLog.Write(ex.Message);
            }

            if (xlApp != null)
            {
                xlWorkbook.Close(Type.Missing, excelFile, Type.Missing);
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

            EventLog.Write("WaferFile.SaveToExcel End");
            return result;
        }
    }
}
