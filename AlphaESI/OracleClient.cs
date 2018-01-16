using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace AlphaESI
{
    class OracleClient
    {
        static OracleConnection conn = null; 

        public static int Open()
        {
            int result = -1;
#if (DEBUG)
            string connString = "User ID=test;Password=test;Data Source=SMICTEST";
#else
            string connString = "User ID=testinge2;Password=testinge2;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.224.25.105)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=SMICTEST)))";
#endif
            conn = new OracleConnection(connString); 
 
            try 
            { 
                conn.Open();
                result = 0;    
            } 
            catch (Exception ex) 
            {
                conn = null;
                MessageBox.Show(ex.Message);
                result = -1;
            }

            return result;
        }

        public static void Close()
        {
            try
            {
                if (conn != null)
                    conn.Close();
            }
            catch (Exception ex)
            {
                EventLog.Write("OracleClient.Close: " + ex.Message);
            }
        }

        public static int InsertWaferValue(string device, string product, string filename, string field, double z, double energy, double stability, DateTime datetime)
        {
            int result = -1;
            string time = string.Format("{0:yyyyMMdd HH:mm:ss}", datetime); 

            string insert = "INSERT INTO WaferInfo(Device, Product, File_name, Focus_Field, Z, Average_Laser_Energy, Laser_Stability, Time)" +
                " VALUES(:device, :product, :filename, :field, :z, :energy, :stability, :time)";

            if (conn != null)
            {
                OracleCommand cmd = new OracleCommand(insert, conn);

                cmd.Parameters.Add(new OracleParameter(":device", device));
                cmd.Parameters.Add(new OracleParameter(":product", product));
                cmd.Parameters.Add(new OracleParameter(":filename", filename));
                cmd.Parameters.Add(new OracleParameter(":field", field));
                cmd.Parameters.Add(new OracleParameter(":z", z.ToString("f2")));
                cmd.Parameters.Add(new OracleParameter(":energy", energy.ToString("f2")));
                cmd.Parameters.Add(new OracleParameter(":stability", stability.ToString("f2")));
                cmd.Parameters.Add(new OracleParameter(":time", time));

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    EventLog.Write("OracleClient.InsertWaferValue " + ex.Message);
                }
            }

            return result;
        }
    }
}
