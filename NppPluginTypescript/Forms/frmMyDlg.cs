using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NppPluginTypescript
{
    public partial class frmMyDlg : Form
    {
        public frmMyDlg()
        {
            InitializeComponent();
        }

        private void frmMyDlg_Load(object sender, EventArgs e)
        {
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          this.linkLabel2.LinkVisited = true;
          // Navigate to a URL.
          System.Diagnostics.Process.Start("http://www.typescriptlang.org/");


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          this.linkLabel1.LinkVisited = true;
          // Navigate to a URL.
          System.Diagnostics.Process.Start("http://nodejs.org/");

        }
    }
}
