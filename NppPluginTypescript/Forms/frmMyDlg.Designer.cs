namespace NppPluginTypescript
{
    partial class frmMyDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.label1 = new System.Windows.Forms.Label();
      this.linkLabel1 = new System.Windows.Forms.LinkLabel();
      this.linkLabel2 = new System.Windows.Forms.LinkLabel();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(27, 29);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(320, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "You will need node.js and typescript installed for this plugin to work";
      // 
      // linkLabel1
      // 
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Location = new System.Drawing.Point(110, 105);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new System.Drawing.Size(85, 13);
      this.linkLabel1.TabIndex = 2;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Node.js Website";
      this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      // 
      // linkLabel2
      // 
      this.linkLabel2.AutoSize = true;
      this.linkLabel2.Location = new System.Drawing.Point(110, 169);
      this.linkLabel2.Name = "linkLabel2";
      this.linkLabel2.Size = new System.Drawing.Size(98, 13);
      this.linkLabel2.TabIndex = 2;
      this.linkLabel2.TabStop = true;
      this.linkLabel2.Text = "Typescript Website";
      this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(27, 248);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(156, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Windhoff Engineering, Denver, ";
      // 
      // frmMyDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(445, 283);
      this.Controls.Add(this.linkLabel2);
      this.Controls.Add(this.linkLabel1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "frmMyDlg";
      this.Text = "Typescript Plugin Info";
      this.Load += new System.EventHandler(this.frmMyDlg_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label2;

    }
}