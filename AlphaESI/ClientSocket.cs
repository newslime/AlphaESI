using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AlphaESI
{
    class ClientSocket
    {
        public static void Send(bool beepZ, bool beepEnergy)
        {
            TcpClient tcpclient = new TcpClient();

            /*try
            {
                var result = tcpclient.BeginConnect(Parameter.ServerIP, 8080, null, null);
                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3));

                if (success)
                {
                    NetworkStream ns = tcpclient.GetStream();
                    ns.WriteTimeout = 3000;

                    if (beepZ)
                    {
                        var header = BitConverter.GetBytes(1);
                        ns.Write(header, 0, header.Length); ;
                    }

                    if (beepEnergy)
                    {
                        var header = BitConverter.GetBytes(2);
                        ns.Write(header, 0, header.Length); ;

                    }
                    ns.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            tcpclient.Close();
            tcpclient = null;
        }
    }
}
