﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AlphaESI
{
    public static class EventLog
    {
        public static string FilePath { get; set; }

        public static void Write(string format, params object[] arg)
        {
            Write(string.Format(format, arg));
        }

        public static void Write(string message)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                FilePath = Directory.GetCurrentDirectory();
            }
            string filename = Application.StartupPath + "\\log" + string.Format("\\{0:yyyy-MM-dd}.txt", DateTime.Now);

            FileInfo finfo = new FileInfo(filename);
            if (finfo.Directory.Exists == false)
            {
                finfo.Directory.Create();
            }
            string writeString = string.Format("{0:yyyy/MM/dd HH:mm:ss} {1}", DateTime.Now, message) + Environment.NewLine;

            File.AppendAllText(filename, writeString, Encoding.Unicode);
        }
    }
}
