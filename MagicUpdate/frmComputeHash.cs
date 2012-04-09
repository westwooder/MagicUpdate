using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MagicUpdate
{
    public partial class frmComputeHash : Form
    {
        public frmComputeHash()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string file=tbxFile.Text;
            if (!string.IsNullOrEmpty(file))
            {
                if (File.Exists(file))
                {
                    tbxMd5.Text = Core.GetHash(file);
                }
            }
        }
    }
}
