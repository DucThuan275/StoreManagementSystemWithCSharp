namespace Buoi06_01.frm
{
    partial class frmTroGiup
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
            this.btnShowHelp = new System.Windows.Forms.Button();
            this.btnOpenHelpFile = new System.Windows.Forms.Button();
            this.btnOpenOnlineHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowHelp
            // 
            this.btnShowHelp.Location = new System.Drawing.Point(12, 12);
            this.btnShowHelp.Name = "btnShowHelp";
            this.btnShowHelp.Size = new System.Drawing.Size(150, 23);
            this.btnShowHelp.TabIndex = 0;
            this.btnShowHelp.Text = "Hiển Thị Trợ Giúp";
            this.btnShowHelp.UseVisualStyleBackColor = true;
            this.btnShowHelp.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // btnOpenHelpFile
            // 
            this.btnOpenHelpFile.Location = new System.Drawing.Point(12, 41);
            this.btnOpenHelpFile.Name = "btnOpenHelpFile";
            this.btnOpenHelpFile.Size = new System.Drawing.Size(150, 23);
            this.btnOpenHelpFile.TabIndex = 1;
            this.btnOpenHelpFile.Text = "Mở Tài Liệu Trợ Giúp";
            this.btnOpenHelpFile.UseVisualStyleBackColor = true;
            this.btnOpenHelpFile.Click += new System.EventHandler(this.btnOpenHelpFile_Click);
            // 
            // btnOpenOnlineHelp
            // 
            this.btnOpenOnlineHelp.Location = new System.Drawing.Point(12, 70);
            this.btnOpenOnlineHelp.Name = "btnOpenOnlineHelp";
            this.btnOpenOnlineHelp.Size = new System.Drawing.Size(150, 23);
            this.btnOpenOnlineHelp.TabIndex = 2;
            this.btnOpenOnlineHelp.Text = "Trợ Giúp Trực Tuyến";
            this.btnOpenOnlineHelp.UseVisualStyleBackColor = true;
            this.btnOpenOnlineHelp.Click += new System.EventHandler(this.btnOpenOnlineHelp_Click);
            // 
            // frmTroGiup
            // 
            this.ClientSize = new System.Drawing.Size(200, 120);
            this.Controls.Add(this.btnOpenOnlineHelp);
            this.Controls.Add(this.btnOpenHelpFile);
            this.Controls.Add(this.btnShowHelp);
            this.Name = "frmTroGiup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trợ Giúp";
            this.Load += new System.EventHandler(this.frmTroGiup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowHelp;
        private System.Windows.Forms.Button btnOpenHelpFile;
        private System.Windows.Forms.Button btnOpenOnlineHelp;
    }
}
