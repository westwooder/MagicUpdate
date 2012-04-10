namespace MagicUpdate
{
    partial class frmAutoUpDate
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        
    //NOTE: The following procedure is required by the Windows Form Designer 
    //It can be modified using the Windows Form Designer. 
    //Do not modify it using the code editor. 
    internal System.Windows.Forms.ProgressBar pbProcess; 
    internal System.Windows.Forms.Label lblDetail;
    internal System.Windows.Forms.Label lblNotice; 
    [System.Diagnostics.DebuggerStepThrough()] 
    private void InitializeComponent() 
    {
        this.pbProcess = new System.Windows.Forms.ProgressBar();
        this.lblDetail = new System.Windows.Forms.Label();
        this.lblNotice = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // pbProcess
        // 
        this.pbProcess.Location = new System.Drawing.Point(8, 33);
        this.pbProcess.Name = "pbProcess";
        this.pbProcess.Size = new System.Drawing.Size(386, 18);
        this.pbProcess.TabIndex = 5;
        // 
        // lblDetail
        // 
        this.lblDetail.Location = new System.Drawing.Point(8, 61);
        this.lblDetail.Name = "lblDetail";
        this.lblDetail.Size = new System.Drawing.Size(386, 28);
        this.lblDetail.TabIndex = 4;
        // 
        // lblNotice
        // 
        this.lblNotice.Location = new System.Drawing.Point(8, 9);
        this.lblNotice.Name = "lblNotice";
        this.lblNotice.Size = new System.Drawing.Size(386, 23);
        this.lblNotice.TabIndex = 3;
        this.lblNotice.Text = "检查应用程序更新，请稍后...";
        // 
        // frmAutoUpDate
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
        this.ClientSize = new System.Drawing.Size(406, 91);
        this.ControlBox = false;
        this.Controls.Add(this.pbProcess);
        this.Controls.Add(this.lblDetail);
        this.Controls.Add(this.lblNotice);
        this.Name = "frmAutoUpDate";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "自动更新程序";
        this.Shown += new System.EventHandler(this.frmAutoUpDate_Shown);
        this.ResumeLayout(false);

    } 
    


    }
}

