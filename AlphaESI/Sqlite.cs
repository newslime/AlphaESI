using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AlphaESI
{
    class Sqlite
    {
        static string SQLITE_DB = Application.StartupPath + "\\ESI.db";
        static string PARAMETERS_TBL_NAME = "Parameters";

        private static SQLiteConnection sqlite_connect = null;
        private static SQLiteCommand sqlite_cmd;

        public static void Open()
        {
            if (!File.Exists(SQLITE_DB))
            {
                SQLiteConnection.CreateFile(SQLITE_DB);
            }

            sqlite_connect = new SQLiteConnection("Data source=" + SQLITE_DB);

            sqlite_connect.Open();// Open
            sqlite_cmd = sqlite_connect.CreateCommand();//create command

            sqlite_cmd.CommandText = @"CREATE TABLE IF NOT EXISTS " + PARAMETERS_TBL_NAME + " (device TEXT, product TEXT, z_value TEXT, energy_threshold TEXT, energy_percent INTEGER, stability_threshold TEXT, stability_percent INTEGER, refence INTEGER)";
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void Close()
        {
            if (sqlite_connect != null)
                sqlite_connect.Close();
        }

        //----------------------------Columns Info Table----------------------------
        public static void InsertParameter(DeviceType device, string product, double zThreshold, double energyThreshold, int energyPercent, double lsThreshold, int lsPercent,  int refence)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = "INSERT INTO " + PARAMETERS_TBL_NAME + " VALUES ('" + device + "','" + product + "','" + zThreshold.ToString("f2") + "','" + energyThreshold.ToString("f2") + "','" + energyPercent + "','" + lsThreshold.ToString("f2") + "','" + lsPercent + "','" + refence + "');";

            try
            {
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                EventLog.Write("Sqlite.InsertParameter: " + ex.Message);
            }
        }

        public static int SelectParameter(DeviceType device, string product, ref double zThreshold, ref double energyThreshold, ref int energyPercent, ref double lsThreshold, ref int lsPercent, ref int refence)
        {
            int result = 0;
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = "SELECT z_value, energy_threshold, energy_percent, stability_threshold, stability_percent, refence FROM " + PARAMETERS_TBL_NAME + " WHERE device='" + device.ToString() + "' AND product='" + product + "'";

            try
            {
                using (SQLiteDataReader rdr = sqlite_cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Double.TryParse(rdr.GetString(0), out zThreshold);
                        Double.TryParse(rdr.GetString(1), out energyThreshold);
                        energyPercent = rdr.GetInt32(2);
                        Double.TryParse(rdr.GetString(3), out lsThreshold);
                        lsPercent = rdr.GetInt32(4);
                        refence = rdr.GetInt32(5);
                        result = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.Write("Sqlite.SelectParameter" + ex.Message);
            }

            return result;
        }

        public static void UpdateZThreshold(DeviceType device, string product, double thresholdZ)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = ("UPDATE " + PARAMETERS_TBL_NAME + " SET z_value='" + thresholdZ.ToString("f2") + "' WHERE device ='" + device.ToString() + "' AND product='" + product + "'");

            try
            {
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                EventLog.Write("Sqlite.UpdateThresholdZ" + ex.Message);
            }
        }

        public static void UpdateEnergyThreshold(DeviceType device, string product, double energyThreshold)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = ("UPDATE " + PARAMETERS_TBL_NAME + " SET energy_threshold='" + energyThreshold.ToString("f2") + "' WHERE device ='" + device.ToString() + "' AND product='" + product + "'");

            try
            {
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                EventLog.Write("Sqlite.UpdateThresholdEnergy" + ex.Message);
            }
        }

        public static void UpdateStabilityThreshold(DeviceType device, string product, double lsThreshold)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = ("UPDATE " + PARAMETERS_TBL_NAME + " SET stability_threshold='" + lsThreshold.ToString("f2") + "' WHERE device ='" + device.ToString() + "' AND product='" + product + "'");

            try
            {
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                EventLog.Write("Sqlite.UpdateThresholdStability" + ex.Message);
            }
        }

        public static void UpdateEnergyPercent(DeviceType device, string product, int energyPercent)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = ("UPDATE " + PARAMETERS_TBL_NAME + " SET energy_percent='" + energyPercent + "' WHERE device ='" + device.ToString() + "' AND product='" + product + "'");

            try
            {
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                EventLog.Write("Sqlite.UpdateEnergyPercent" + ex.Message);
            }
        }

        public static void UpdateStabilityPercent(DeviceType device, string product, int lsPercent)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = ("UPDATE " + PARAMETERS_TBL_NAME + " SET stability_percent='" + lsPercent + "' WHERE device ='" + device.ToString() + "' AND product='" + product + "'");

            try
            {
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                EventLog.Write("Sqlite.UpdateEnergyPercent" + ex.Message);
            }
        }

        public static void UpdateRefence(DeviceType device, string product, int refence)
        {
            sqlite_cmd = sqlite_connect.CreateCommand();//create command
            sqlite_cmd.CommandText = ("UPDATE " + PARAMETERS_TBL_NAME + " SET refence='" + refence + "' WHERE device ='" + device.ToString() + "' AND product='" + product + "'");

            try
            {
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                EventLog.Write("Sqlite.UpdateRefence" + ex.Message);
            }
        }
    }
}
