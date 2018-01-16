using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace AlphaESI
{
    class FTPClient
    {
        static FtpWebRequest _request = null;

        public static string[] GetProducts(DeviceType deviceType)
        {
            EventLog.Write("FTPClient.GetProducts Start");

            StreamReader streamReader = null;
            StringBuilder result;
            string uri, line, ftpIp, user, pwd;
            string[] products = null;

            if (deviceType == DeviceType.HL9309)
            {
                ftpIp = Parameter.DeviceHL9309.FtpIP;
                user = Parameter.DeviceHL9309.FtpUser;
                pwd = Parameter.DeviceHL9309.FtpPwd;
            }
            else
            {
                ftpIp = Parameter.DeviceHL9308.FtpIP;
                user = Parameter.DeviceHL9308.FtpUser;
                pwd = Parameter.DeviceHL9308.FtpPwd;
            }

            uri = ftpIp;
            _request = (FtpWebRequest)FtpWebRequest.Create(uri);
            _request.Method = WebRequestMethods.Ftp.ListDirectory;
            _request.Timeout = 5000;
            _request.Credentials = new NetworkCredential(user, pwd);
            _request.KeepAlive = true;

            try
            {
                streamReader = new StreamReader(_request.GetResponse().GetResponseStream());
                result = new StringBuilder();
                line = streamReader.ReadLine();

                while (line != null)
                {
                    result.Append(line + "\n");
                    line = streamReader.ReadLine();
                }

                if (result.Length > 0)
                {
                    result.Remove(result.ToString().LastIndexOf('\n'), 1);
                    products = result.ToString().Split('\n');
                }
            }
            catch (Exception ex)
            {
                EventLog.Write(ex.Message);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                    streamReader = null;
                }
            }

            EventLog.Write("FTPClient.GetProducts End");

            return products;
        }

        public static string DownloadFile(DeviceType deviceType, string product)
        {
            FileStream writeStream = null;
            StreamReader streamReader = null;
            Stream stream = null;
            StringBuilder result;
            string[] dirs = null, files = null;
            string line, filepath, uri, ftpIp, user, pwd, logPath, historyPath, folder;
            string extension, dirname;
            int Length = 2048, bytesRead;
            Byte[] buffer;

            if (deviceType == DeviceType.HL9309)
            {
                ftpIp = Parameter.DeviceHL9309.FtpIP;
                user = Parameter.DeviceHL9309.FtpUser;
                pwd = Parameter.DeviceHL9309.FtpPwd;
                logPath = Parameter.DeviceHL9309.LogPath + product + "/";
                historyPath = Parameter.DeviceHL9309.HistoryPath + product + "/";
                folder = "/" + Parameter.DeviceHL9309.Folder + "/";                
            }
            else
            {
                ftpIp = Parameter.DeviceHL9308.FtpIP;
                user = Parameter.DeviceHL9308.FtpUser;
                pwd = Parameter.DeviceHL9308.FtpPwd;
                logPath = Parameter.DeviceHL9308.LogPath + product + "/";
                historyPath = Parameter.DeviceHL9308.HistoryPath + product + "/";
                folder = "/" + Parameter.DeviceHL9308.Folder + "/";
            }

            try
            {
                Directory.CreateDirectory(logPath);
                Directory.CreateDirectory(historyPath);
            }
            catch (Exception ex)
            {
                EventLog.Write(ex.Message);
                return "";
            }

            EventLog.Write("FTPClient.DownloadFile Start");

            uri = ftpIp + product + folder;
            _request = (FtpWebRequest)FtpWebRequest.Create(uri);
            _request.Method = WebRequestMethods.Ftp.ListDirectory;
            _request.Credentials = new NetworkCredential(user, pwd);
            _request.Timeout = 10000;
            _request.KeepAlive = true;

            try
            {
                EventLog.Write("FTPClient.Download ListDirectory");
                streamReader = new StreamReader(_request.GetResponse().GetResponseStream());
                result = new StringBuilder();
                line = streamReader.ReadLine();

                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = streamReader.ReadLine();
                }

                if (result.Length > 0)
                {
                    result.Remove(result.ToString().LastIndexOf('\n'), 1);
                    dirs = result.ToString().Split('\n');
                }
            }
            catch (Exception ex)
            {
                EventLog.Write(ex.Message);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                    streamReader = null;
                }
            }

            if (dirs != null)
            {
                EventLog.Write("FTPClient.Download files");
                foreach (string dir in dirs)
                {
                    extension = Path.GetExtension(dir);
                    dirname = Path.GetFileNameWithoutExtension(dir);

                    if (extension.CompareTo(".wafer") != 0)
                        continue;

                    if (Directory.Exists(historyPath + dir))
                        continue;

                    try
                    {
                        Directory.CreateDirectory(logPath + dir);
                    }
                    catch (Exception ex)
                    {
                        EventLog.Write(ex.Message);
                        continue;
                    }


                    files = null;

                    uri = ftpIp + product + folder + dir + "/";
                    _request = (FtpWebRequest)FtpWebRequest.Create(uri);
                    _request.Method = WebRequestMethods.Ftp.ListDirectory;
                    _request.Credentials = new NetworkCredential(user, pwd);
                    _request.Timeout = 10000;
                    _request.KeepAlive = true;

                    try
                    {
                        streamReader = new StreamReader(_request.GetResponse().GetResponseStream());
                        result = new StringBuilder();
                        line = streamReader.ReadLine();

                        while (line != null)
                        {
                            result.Append(line);
                            result.Append("\n");
                            line = streamReader.ReadLine();
                        }

                        if (result.Length > 0)
                        {
                            result.Remove(result.ToString().LastIndexOf('\n'), 1);
                            files = result.ToString().Split('\n');
                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog.Write(ex.Message);
                    }
                    finally
                    {
                        if (streamReader != null)
                        {
                            streamReader.Close();
                            streamReader = null;
                        }
                    }

                    if (files == null)
                        continue;

                    foreach (string file in files)
                    {
                        filepath = logPath + dir + "/" + file;
                        uri = ftpIp + product + folder + dir + "/" + file;

                        _request = (FtpWebRequest)FtpWebRequest.Create(uri);
                        _request.Method = WebRequestMethods.Ftp.DownloadFile;
                        _request.Credentials = new NetworkCredential(user, pwd);
                        _request.Timeout = 10000;
                        _request.KeepAlive = true;

                        try
                        {
                            stream = _request.GetResponse().GetResponseStream();
                            writeStream = new FileStream(filepath, FileMode.Create);

                            buffer = new Byte[Length];
                            bytesRead = stream.Read(buffer, 0, Length);

                            while (bytesRead > 0)
                            {
                                writeStream.Write(buffer, 0, bytesRead);
                                bytesRead = stream.Read(buffer, 0, Length);
                            }
                        }
                        catch (Exception ex)
                        {
                            EventLog.Write(ex.Message);
                        }
                        finally
                        {
                            if (writeStream != null)
                            {
                                writeStream.Close();
                                writeStream = null;
                            }

                            if (stream != null)
                            {
                                stream.Close();
                                stream = null;
                            }
                        }
                    }
                }
            }

            EventLog.Write("FTPClient.DownloadFile End");
            return WaferFile.Sort(deviceType, product, logPath, historyPath);
        }

        /*public static bool DeleteFile(string dir, string file)
        {
            if (dir == "")
                return false;

            bool result = false;
            string uri = _FtpIP + dir + "/" + file;

            _Request = (FtpWebRequest)WebRequest.Create(uri);
            _Request.Credentials = new NetworkCredential(_User, _Pwd);
            _Request.Method = WebRequestMethods.Ftp.DeleteFile;
            _Request.Timeout = _Timeout;
            _Request.KeepAlive = true;

            try
            {
                _Response = (FtpWebResponse)_Request.GetResponse();
                _Response = null;
                _Request = null;

                result = true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "FTP DownloadFile Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }*/
    }
}