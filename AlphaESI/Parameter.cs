using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace AlphaESI
{
    class Parameter
    {
        public const int RectangleWeight = 10;
        public const int Offset = -19;
        public const int Columns = 58;
        public const int Rows = 58;

        public static DeviceType CurrentDevice = DeviceType.HL9309;
        public static Device DeviceHL9309 = new Device();
        public static Device DeviceHL9308 = new Device();
        public static string SpcPath = "E:/";

        public static void Init()
        {
            string xmlFile = Application.StartupPath + "\\Setting.xml";

            if (File.Exists(xmlFile))
            {
                XmlDocument doc;
                XmlNode node;

                doc = new XmlDocument();
                doc.Load(xmlFile);

                //HL9309
                node = doc.DocumentElement.SelectSingleNode("/Setting/FTP/HL9309/Hostname");
                if (node != null)
                    DeviceHL9309.FtpIP = "FTP://" + node.InnerText;

                node = doc.DocumentElement.SelectSingleNode("/Setting/FTP/HL9309/Path");
                if (node != null)
                {
                    DeviceHL9309.FtpIP += node.InnerText;

                    if (DeviceHL9309.FtpIP.Substring(DeviceHL9309.FtpIP.Length - 1, 1) != "/")
                        DeviceHL9309.FtpIP += "/";
                }

                node = doc.DocumentElement.SelectSingleNode("/Setting/FTP/HL9309/User");
                if (node != null)
                    DeviceHL9309.FtpUser = node.InnerText;

                node = doc.DocumentElement.SelectSingleNode("/Setting/FTP/HL9309/Password");
                if (node != null)
                    DeviceHL9309.FtpPwd = node.InnerText;

                node = doc.DocumentElement.SelectSingleNode("/Setting/FTP/HL9309/Folder");
                if (node != null)
                    DeviceHL9309.Folder = node.InnerText;

                node = doc.DocumentElement.SelectSingleNode("/Setting/LocalPath/HL9309/Log");
                if (node != null)
                {
                    DeviceHL9309.LogPath = node.InnerText;

                    if (DeviceHL9309.LogPath.Substring(DeviceHL9309.LogPath.Length - 1, 1) != "/")
                        DeviceHL9309.LogPath += "/";
                }

                node = doc.DocumentElement.SelectSingleNode("/Setting/LocalPath/HL9309/History");
                if (node != null)
                {
                    DeviceHL9309.HistoryPath = node.InnerText;

                    if (DeviceHL9309.HistoryPath.Substring(DeviceHL9309.HistoryPath.Length - 1, 1) != "/")
                        DeviceHL9309.HistoryPath += "/";
                }


                //HL9308
                node = doc.DocumentElement.SelectSingleNode("/Setting/FTP/HL9308/Hostname");
                if (node != null)
                    DeviceHL9308.FtpIP = "FTP://" + node.InnerText;

                node = doc.DocumentElement.SelectSingleNode("/Setting/FTP/HL9308/Path");
                if (node != null)
                {
                    DeviceHL9308.FtpIP += node.InnerText;

                    if (DeviceHL9308.FtpIP.Substring(DeviceHL9308.FtpIP.Length - 1, 1) != "/")
                        DeviceHL9308.FtpIP += "/";
                }

                node = doc.DocumentElement.SelectSingleNode("/Setting/FTP/HL9308/User");
                if (node != null)
                    DeviceHL9308.FtpUser = node.InnerText;

                node = doc.DocumentElement.SelectSingleNode("/Setting/FTP/HL9308/Password");
                if (node != null)
                    DeviceHL9308.FtpPwd = node.InnerText;

                node = doc.DocumentElement.SelectSingleNode("/Setting/FTP/HL9308/Folder");
                if (node != null)
                    DeviceHL9308.Folder = node.InnerText;

                node = doc.DocumentElement.SelectSingleNode("/Setting/LocalPath/HL9308/Log");
                if (node != null)
                {
                    DeviceHL9308.LogPath = node.InnerText;

                    if (DeviceHL9308.LogPath.Substring(DeviceHL9308.LogPath.Length - 1, 1) != "/")
                        DeviceHL9308.LogPath += "/";
                }

                node = doc.DocumentElement.SelectSingleNode("/Setting/LocalPath/HL9308/History");
                if (node != null)
                {
                    DeviceHL9308.HistoryPath = node.InnerText;

                    if (DeviceHL9308.HistoryPath.Substring(DeviceHL9308.HistoryPath.Length - 1, 1) != "/")
                        DeviceHL9308.HistoryPath += "/";
                }

                node = doc.DocumentElement.SelectSingleNode("/Setting/LocalPath/SPC");
                if (node != null)
                {
                    SpcPath = node.InnerText + "\\";
                }
            }

            try
            {
                Directory.CreateDirectory(DeviceHL9309.LogPath);
                Directory.CreateDirectory(DeviceHL9309.HistoryPath);
                Directory.CreateDirectory(DeviceHL9308.LogPath);
                Directory.CreateDirectory(DeviceHL9308.HistoryPath);
                Directory.CreateDirectory(SpcPath);
            }
            catch(Exception ex)
            {
                EventLog.Write("FTPClient.Init: " + ex.Message);    
            }
        }
    }

    public enum DeviceType
    {
        HL9309,
        HL9308
    };

    class Device
    {
        public string LogPath = "C:/";
        public string HistoryPath = "C:/";
        public string Folder = "00Null.wafer";
        public string FtpIP = "FTP://127.0.0.1";
        public string FtpUser = "esi";
        public string FtpPwd = "esi_user";
        public int Timeout = 10000;

        public double Z_Threshold = 10.0;
        public double Energy_Threshold = 1.0;
        public int Energy_Percent = 10;
        public double Stability_Threshold = 10.0;
        public int Stability_Percent = 10;
        public int Refence = 5;

        public Color DieColor1 = Color.Green;
        public Color DieColor2 = Color.Red;

        public string ProductName = "";
        public string FilePath = "";
    }

    public struct WaferDie
    {
        public double z, energy, stability;

        public WaferDie(double p1, double p2, double p3)
        {
            z = p1;
            energy = p2;
            stability = p3;
        }
    }
}
