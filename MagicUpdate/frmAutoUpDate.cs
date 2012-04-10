using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace MagicUpdate
{
    public partial class frmAutoUpDate : Form
    {
        public frmAutoUpDate()
        {
            InitializeComponent();
        }

        private void UpdateComplete()
        {
            ShowMessage(lblNotice, "应用程序更新完成!");
            ProcessStartInfo startInfo = new ProcessStartInfo(Application.StartupPath + "\\" + Module.ExeFile);
            startInfo.Arguments = Module.CommandLine;
            Process.Start(startInfo);
        }


        void Module_onDownLoadFileStart(string FileName)
        {
            lblDetail.Text = "更新文件 " + FileName + "...";

            pbProcess.Value++;
            Application.DoEvents();
            Thread.Sleep(300);
        }



        private void ShowMessage(Label l, string Message)
        {
            l.Text = Message;
            Application.DoEvents();
        }



        private void frmAutoUpDate_Shown(object sender, EventArgs e)
        {
            Module.InitClass();
            this.TopMost = true;
            ShowMessage(lblDetail, "下载程序清单...");


            bool IsConnected = Module.DownLoadManifestFile();
            if (IsConnected)
            {
                int iNeedUpdateFileCount = Module.CheckUpdate();
                ShowMessage(lblDetail, "下载程序清单完成");
                if (iNeedUpdateFileCount == 0)
                {


                    ShowMessage(lblNotice, "您的程序是最新版本");
                }
                else
                {
                    ShowMessage(lblNotice, "发现新版本");

                   
                        Module.KillAppExe();
                        Module.onDownLoadFileStart += new Module.DownLoadFileStart(Module_onDownLoadFileStart);
                        ShowMessage(lblDetail, "正在执行软件更新");
                        this.pbProcess.Maximum = iNeedUpdateFileCount;
                        Module.ProcessUpdate();
                        UpdateComplete();
                   

                }
            }
            Environment.Exit(1);
        }





    }
}
