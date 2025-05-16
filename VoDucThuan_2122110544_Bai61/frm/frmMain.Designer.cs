namespace Buoi06_01.frm
{
    partial class frmMain
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.SinhVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThanhVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KhoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tùyChọnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoiMatKhauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DangXuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HeThongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TroGiupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelTenDangNhap = new System.Windows.Forms.ToolStripStatusLabel();
            this.XemChiTietTVtoolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(210, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(465, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHẦN MỀM QUẢN LÝ SINH VIÊN";
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SinhVienToolStripMenuItem,
            this.ThanhVienToolStripMenuItem,
            this.KhoaToolStripMenuItem,
            this.tùyChọnToolStripMenuItem,
            this.HeThongToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1182, 30);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // SinhVienToolStripMenuItem
            // 
            this.SinhVienToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SinhVienToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SinhVienToolStripMenuItem.Image")));
            this.SinhVienToolStripMenuItem.Name = "SinhVienToolStripMenuItem";
            this.SinhVienToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.SinhVienToolStripMenuItem.Text = "Quản lý sinh viên";
            this.SinhVienToolStripMenuItem.Click += new System.EventHandler(this.SinhVienToolStripMenuItem_Click);
            // 
            // ThanhVienToolStripMenuItem
            // 
            this.ThanhVienToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ThanhVienToolStripMenuItem.Image")));
            this.ThanhVienToolStripMenuItem.Name = "ThanhVienToolStripMenuItem";
            this.ThanhVienToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.ThanhVienToolStripMenuItem.Text = "Quản lý thành viên";
            this.ThanhVienToolStripMenuItem.Click += new System.EventHandler(this.ThanhVienToolStripMenuItem_Click);
            // 
            // KhoaToolStripMenuItem
            // 
            this.KhoaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("KhoaToolStripMenuItem.Image")));
            this.KhoaToolStripMenuItem.Name = "KhoaToolStripMenuItem";
            this.KhoaToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.KhoaToolStripMenuItem.Text = "Quản lý khoa";
            this.KhoaToolStripMenuItem.Click += new System.EventHandler(this.KhoaToolStripMenuItem_Click);
            // 
            // tùyChọnToolStripMenuItem
            // 
            this.tùyChọnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DoiMatKhauToolStripMenuItem,
            this.DangXuatToolStripMenuItem});
            this.tùyChọnToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tùyChọnToolStripMenuItem.Image")));
            this.tùyChọnToolStripMenuItem.Name = "tùyChọnToolStripMenuItem";
            this.tùyChọnToolStripMenuItem.Size = new System.Drawing.Size(102, 26);
            this.tùyChọnToolStripMenuItem.Text = "Tùy chọn";
            // 
            // DoiMatKhauToolStripMenuItem
            // 
            this.DoiMatKhauToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DoiMatKhauToolStripMenuItem.Image")));
            this.DoiMatKhauToolStripMenuItem.Name = "DoiMatKhauToolStripMenuItem";
            this.DoiMatKhauToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.DoiMatKhauToolStripMenuItem.Text = "Đổi mật khẩu";
            this.DoiMatKhauToolStripMenuItem.Click += new System.EventHandler(this.DoiMatKhauToolStripMenuItem_Click);
            // 
            // DangXuatToolStripMenuItem
            // 
            this.DangXuatToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DangXuatToolStripMenuItem.Image")));
            this.DangXuatToolStripMenuItem.Name = "DangXuatToolStripMenuItem";
            this.DangXuatToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.DangXuatToolStripMenuItem.Text = "Đăng xuất";
            this.DangXuatToolStripMenuItem.Click += new System.EventHandler(this.DangXuatToolStripMenuItem_Click);
            // 
            // HeThongToolStripMenuItem
            // 
            this.HeThongToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TroGiupToolStripMenuItem,
            this.ThoatToolStripMenuItem});
            this.HeThongToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("HeThongToolStripMenuItem.Image")));
            this.HeThongToolStripMenuItem.Name = "HeThongToolStripMenuItem";
            this.HeThongToolStripMenuItem.Size = new System.Drawing.Size(105, 26);
            this.HeThongToolStripMenuItem.Text = "Hệ thống";
            // 
            // TroGiupToolStripMenuItem
            // 
            this.TroGiupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("TroGiupToolStripMenuItem.Image")));
            this.TroGiupToolStripMenuItem.Name = "TroGiupToolStripMenuItem";
            this.TroGiupToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.TroGiupToolStripMenuItem.Text = "Trợ giúp";
            this.TroGiupToolStripMenuItem.Click += new System.EventHandler(this.TroGiupToolStripMenuItem_Click);
            // 
            // ThoatToolStripMenuItem
            // 
            this.ThoatToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ThoatToolStripMenuItem.Image")));
            this.ThoatToolStripMenuItem.Name = "ThoatToolStripMenuItem";
            this.ThoatToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ThoatToolStripMenuItem.Text = "Thoát";
            this.ThoatToolStripMenuItem.Click += new System.EventHandler(this.ThoatToolStripMenuItem_Click);
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStripMain.Location = new System.Drawing.Point(0, 30);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1182, 31);
            this.toolStripMain.TabIndex = 2;
            this.toolStripMain.Text = "toolStripMain";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(225, 22);
            this.toolStripLabel1.Text = "PHẦN MỀM QUẢN LÝ SINH VIÊN";
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelTenDangNhap,
            this.toolStripStatusLabel1,
            this.XemChiTietTVtoolStripSplitButton});
            this.statusStripMain.Location = new System.Drawing.Point(0, 677);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1182, 26);
            this.statusStripMain.TabIndex = 3;
            this.statusStripMain.Text = "statusStripMain";
            // 
            // toolStripStatusLabelTenDangNhap
            // 
            this.toolStripStatusLabelTenDangNhap.Name = "toolStripStatusLabelTenDangNhap";
            this.toolStripStatusLabelTenDangNhap.Size = new System.Drawing.Size(75, 20);
            this.toolStripStatusLabelTenDangNhap.Text = "Welcome ";
            // 
            // XemChiTietTVtoolStripSplitButton
            // 
            this.XemChiTietTVtoolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.XemChiTietTVtoolStripSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("XemChiTietTVtoolStripSplitButton.Image")));
            this.XemChiTietTVtoolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.XemChiTietTVtoolStripSplitButton.Name = "XemChiTietTVtoolStripSplitButton";
            this.XemChiTietTVtoolStripSplitButton.Size = new System.Drawing.Size(39, 24);
            this.XemChiTietTVtoolStripSplitButton.Text = "toolStripSplitButton1";
            this.XemChiTietTVtoolStripSplitButton.ButtonClick += new System.EventHandler(this.XemChiTietTVtoolStripSplitButton_ButtonClick);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 61);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1182, 616);
            this.tabControlMain.TabIndex = 4;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(88, 20);
            this.toolStripStatusLabel1.Text = "Xem chi tiết";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1182, 703);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHẦN MỀM QUẢN LÝ SINH VIÊN";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem SinhVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThanhVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KhoaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tùyChọnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoiMatKhauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DangXuatToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTenDangNhap;
        private System.Windows.Forms.ToolStripMenuItem HeThongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TroGiupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThoatToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton XemChiTietTVtoolStripSplitButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}
