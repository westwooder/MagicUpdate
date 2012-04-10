using System.Net;
using System.IO;
using System.Windows.Forms;
using System;
using System.Xml;
using System.Diagnostics;
using System.Collections.Generic;
namespace MagicUpdate
{
    public static class Module
    {

        static internal string ExeFile;
        static string RemoteUri;
        static Dictionary<string, DateTime> NeedUpdateFile = new Dictionary<string, DateTime>();
        static string ManifestFile;
        public static string CommandLine;
        static WebClient myWebClient = new WebClient();

        public delegate void DownLoadFileStart(string FileName);
        public static event DownLoadFileStart onDownLoadFileStart;



        public static void InitClass()
        {
            try
            {
                string[] param = CommandLine.Split('|');
                ExeFile = param[0];
                RemoteUri = param[1];
                ManifestFile = param[2];


                if (string.IsNullOrEmpty(ExeFile) | string.IsNullOrEmpty(RemoteUri) | string.IsNullOrEmpty(ManifestFile)) Environment.Exit(1);
            }
            catch (Exception)
            {
                ShowErrorMessage("自动更新参数错误，请重新安装软件。");
                Application.Exit();
            }
        }

        public static bool DownLoadManifestFile()
        {

            // Download manifest file 
            try
            {
                myWebClient.UseDefaultCredentials = true;
                myWebClient.DownloadFile(RemoteUri + ManifestFile, ManifestFile);
                return true;
            }
            catch (Exception)
            {
                ShowErrorMessage("更新出现错误，请确认网络连接正常。若无法解决问题，请与管理员联系。");
                return false;
            }
        }

        public static int CheckUpdate()
        {
            try
            {
                XmlDocument m_xmld = default(XmlDocument);
                XmlNodeList m_nodelist = default(XmlNodeList);
                //Create the XML Document 
                m_xmld = new XmlDocument();
                //Load the Xml file 
                m_xmld.Load(Application.StartupPath + "\\" + ManifestFile);
                //Get the list of name nodes 
                m_nodelist = m_xmld.SelectNodes("/update/name");

                //Loop through the nodes 
                foreach (XmlNode m_node in m_nodelist)
                {
                    //Get the file Attribute Value 
                    var fileAttribute = m_node.Attributes.GetNamedItem("file").Value;
                    //Get the fileName Element Value 
                    var fileNameValue = m_node.ChildNodes.Item(0).InnerText;
                    //Get the fileVersion Element Value 
                    var fileVersionValue = m_node.ChildNodes.Item(1).InnerText;
                    //Get the fileLastModified Value 
                    var fileLastModiValue = m_node.ChildNodes.Item(2).InnerText;
                    bool isToUpgrade = false;

                    string RealFileName = Application.StartupPath + "\\" + fileNameValue;
                    System.DateTime LastModified = Convert.ToDateTime(fileLastModiValue);

                    bool FileExists = File.Exists(RealFileName);
                    //If file not exist then download file 
                    if (!FileExists)
                    {
                        isToUpgrade = true;
                    }
                    else if (!string.IsNullOrEmpty(fileVersionValue))
                    {
                        //verify the file version 
                        FileVersionInfo fv = FileVersionInfo.GetVersionInfo(RealFileName);
                        isToUpgrade = (GetVersion(fileVersionValue) != GetVersion(fv.FileMajorPart + "." + fv.FileMinorPart + "." + fv.FileBuildPart + "." + fv.FilePrivatePart));

                        ////check if version not upgrade then check last modified 
                        //if (!isToUpgrade)
                        //{
                        //    isToUpgrade = (LastModified > File.GetLastWriteTimeUtc(RealFileName));
                        //}
                    }

                    if (isToUpgrade)
                    {
                        NeedUpdateFile.Add(fileNameValue, LastModified);
                    }
                }
                return NeedUpdateFile.Count;

            }
            catch (Exception)
            {
                ShowErrorMessage("更新出现错误，请确认网络连接正常。若无法解决问题，请与管理员联系。");
                return 0;
            }

        }


        public static void ProcessUpdate()
        {
            try
            {
                string LastestSoftFolder = "Soft//";

                foreach (KeyValuePair<string, DateTime> fileNameValue in NeedUpdateFile)
                {
                    if (!object.Equals(null, onDownLoadFileStart))
                    {
                        onDownLoadFileStart(fileNameValue.Key);
                    }

                    string TempFileName = Application.StartupPath + "\\" + DateTime.Now.TimeOfDay.TotalMilliseconds;

                    string RealFileName = Application.StartupPath + "\\" + fileNameValue.Key;

                    // Download file and name it with temporary name 
                    myWebClient.UseDefaultCredentials = true;
                    myWebClient.DownloadFile(RemoteUri + LastestSoftFolder + fileNameValue.Key, TempFileName);
                    // Rename temporary file to real file name 
                    File.Copy(TempFileName, RealFileName, true);
                    // Set Last modified 
                    File.SetLastWriteTimeUtc(RealFileName, fileNameValue.Value);
                    // Delete temporary file 
                    File.Delete(TempFileName);

                }

            }

            catch (Exception ex)
            {
                ShowErrorMessage(ex.ToString());
            }
        }

        private static string GetVersion(string Version)
        {
            try
            {
                string[] x = Version.Split('.');
                return string.Format("{0:00000}{1:00000}{2:00000}{3:00000}", Convert.ToInt32(x[0]), Convert.ToInt32(x[1]), Convert.ToInt32(x[2]), Convert.ToInt32(x[3]));
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static void KillAppExe()
        {
            // Get MainApp exe name without extension 
            string AppExe = ExeFile.Replace(".exe", "");

            Process[] local = Process.GetProcesses();
            int i = 0;
            // Search MainApp process in windows process 
            for (i = 0; i <= local.Length - 1; i++)
            {
                // If MainApp process found then close or kill MainApp 
                if (local[i].ProcessName.ToLower().Trim() == AppExe.ToLower().Trim())
                {
                    local[i].Kill();
                }
            }
        }
        /// <summary>
        /// 异常错误提示
        /// </summary>
        /// <param name="stMessage">错误信息</param>
        static void ShowErrorMessage(string stMessage)
        {
            MessageBox.Show(stMessage, "系统错误 ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
    }
}