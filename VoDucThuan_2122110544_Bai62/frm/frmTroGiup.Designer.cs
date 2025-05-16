namespace Buoi06_02.frm
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
            this.btnOpenOnlineHelp = new System.Windows.Forms.Button();
            this.btnOpenHelpFile = new System.Windows.Forms.Button();
            this.btnShowHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenOnlineHelp
            // 
            this.btnOpenOnlineHelp.Location = new System.Drawing.Point(85, 167);
            this.btnOpenOnlineHelp.Name = "btnOpenOnlineHelp";
            this.btnOpenOnlineHelp.Size = new System.Drawing.Size(283, 48);
            this.btnOpenOnlineHelp.TabIndex = 5;
            this.btnOpenOnlineHelp.Text = "Trợ Giúp Trực Tuyến";
            this.btnOpenOnlineHelp.UseVisualStyleBackColor = true;
            // 
            // btnOpenHelpFile
            // 
            this.btnOpenHelpFile.Location = new System.Drawing.Point(85, 107);
            this.btnOpenHelpFile.Name = "btnOpenHelpFile";
            this.btnOpenHelpFile.Size = new System.Drawing.Size(283, 48);
            this.btnOpenHelpFile.TabIndex = 4;
            this.btnOpenHelpFile.Text = "Mở Tài Liệu Trợ Giúp";
            this.btnOpenHelpFile.UseVisualStyleBackColor = true;
            // 
            // btnShowHelp
            // 
            this.btnShowHelp.Location = new System.Drawing.Point(85, 47);
            this.btnShowHelp.Name = "btnShowHelp";
            this.btnShowHelp.Size = new System.Drawing.Size(283, 48);
            this.btnShowHelp.TabIndex = 3;
            this.btnShowHelp.Text = "Hiển Thị Trợ Giúp";
            this.btnShowHelp.UseVisualStyleBackColor = true;
            // 
            // frmTroGiup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 264);
            this.Controls.Add(this.btnOpenOnlineHelp);
            this.Controls.Add(this.btnOpenHelpFile);
            this.Controls.Add(this.btnShowHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTroGiup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Võ Đức Thuận - 2122110544 - MÀN HÌNH TRỢ GIÚP";
            this.Load += new System.EventHandler(this.frmTroGiup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenOnlineHelp;
        private System.Windows.Forms.Button btnOpenHelpFile;
        private System.Windows.Forms.Button btnShowHelp;
    }
}