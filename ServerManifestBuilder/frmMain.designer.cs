namespace ServerManifestBuilder
{
    partial class frmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.pbBuild = new System.Windows.Forms.ProgressBar();
            this.fbdPath = new System.Windows.Forms.FolderBrowserDialog();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update File Folder";
            // 
            // btnBrowser
            // 
            this.btnBrowser.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowser.Location = new System.Drawing.Point(594, 33);
            this.btnBrowser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(38, 23);
            this.btnBrowser.TabIndex = 1;
            this.btnBrowser.Text = "...";
            this.btnBrowser.UseVisualStyleBackColor = false;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // tbxPath
            // 
            this.tbxPath.Location = new System.Drawing.Point(173, 34);
            this.tbxPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.Size = new System.Drawing.Size(413, 21);
            this.tbxPath.TabIndex = 2;
            // 
            // btnBuild
            // 
            this.btnBuild.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuild.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuild.Location = new System.Drawing.Point(451, 78);
            this.btnBuild.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(181, 26);
            this.btnBuild.TabIndex = 3;
            this.btnBuild.Text = "Create Manifest";
            this.btnBuild.UseVisualStyleBackColor = false;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // pbBuild
            // 
            this.pbBuild.Location = new System.Drawing.Point(47, 117);
            this.pbBuild.Name = "pbBuild";
            this.pbBuild.Size = new System.Drawing.Size(585, 13);
            this.pbBuild.TabIndex = 4;
            this.pbBuild.Visible = false;
            // 
            // fbdPath
            // 
            this.fbdPath.Description = "Select Path";
            this.fbdPath.ShowNewFolderButton = false;
            // 
            // sfdSave
            // 
            this.sfdSave.DefaultExt = "xml";
            this.sfdSave.FileName = "ServerManifest.xml";
            this.sfdSave.Filter = "xml files (*.xml)|*.xml";
            this.sfdSave.RestoreDirectory = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(664, 138);
            this.Controls.Add(this.pbBuild);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.tbxPath);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Server Manifest Utility";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.ProgressBar pbBuild;
        private System.Windows.Forms.FolderBrowserDialog fbdPath;
        private System.Windows.Forms.SaveFileDialog sfdSave;
    }
}

