using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace ServerManifestBuilder
{
    public partial class frmMain : Form
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement oElmntRoot;




        #region Method

        public frmMain()
        {
            InitializeComponent();
        }

        private void createRootNode()
        {
            try
            {
                oElmntRoot = xmlDoc.CreateElement("update");
                //Second Child: update 
                xmlDoc.AppendChild(oElmntRoot);
                //Add the element to the xml document 


                loopNodes(oElmntRoot, this.tbxPath.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void loopNodes(XmlElement oElmntParent, string strPath)
        {
            DirectoryInfo ofs = new DirectoryInfo(strPath + "\\");

            //Files Loop ------------------------------------------------------ 
            this.pbBuild.Maximum = ofs.GetFiles().Length;
            this.pbBuild.Value = 0;
            this.pbBuild.Visible = true;
            foreach (FileInfo oFile in ofs.GetFiles())
            {

                if (oFile.Name != "ServerManifest.xml" & !oFile.Name.EndsWith(".pdb") & !oFile.Name.EndsWith(".config"))
                {
                    XmlElement oElmntLeaf1 = default(XmlElement);
                    //Manipulates the files nodes 
                    XmlElement oElmntFileName = default(XmlElement);
                    XmlElement oElmntFileVersion = default(XmlElement);
                    XmlElement oElmntFileModified = default(XmlElement);

                    oElmntLeaf1 = xmlDoc.CreateElement("name");
                    oElmntLeaf1.SetAttribute("file", oFile.Name);
                    oElmntParent.AppendChild(oElmntLeaf1);

                    oElmntFileName = xmlDoc.CreateElement("filename");
                    oElmntFileName.InnerText = oFile.Name;
                    oElmntLeaf1.AppendChild(oElmntFileName);

                    FileVersionInfo fv = FileVersionInfo.GetVersionInfo(oFile.FullName);
                    oElmntFileVersion = xmlDoc.CreateElement("fileversion");
                    oElmntFileVersion.InnerText = fv.FileVersion;
                    oElmntLeaf1.AppendChild(oElmntFileVersion);

                    oElmntFileModified = xmlDoc.CreateElement("filelastmodified");
                    oElmntFileModified.InnerText = oFile.LastAccessTimeUtc.ToString();
                    oElmntLeaf1.AppendChild(oElmntFileModified);
                }
                this.pbBuild.Value++;

                Application.DoEvents();

            }
        }
        #endregion

        #region Event

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK.Equals(this.fbdPath.ShowDialog()))
            {
                this.tbxPath.Text = this.fbdPath.SelectedPath;
            }
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tbxPath.Text.Trim()))
            {
                xmlDoc.RemoveAll();
                xmlDoc.AppendChild(xmlDoc.CreateProcessingInstruction("xml", "version='1.0' encoding='UTF-8'"));
                createRootNode();
                if (DialogResult.OK.Equals(this.sfdSave.ShowDialog()))
                {
                    xmlDoc.Save(sfdSave.FileName);
                }
                MessageBox.Show("The XML document of manifest was created");
                pbBuild.Visible = false;
            }
        }

        #endregion


    }
}
