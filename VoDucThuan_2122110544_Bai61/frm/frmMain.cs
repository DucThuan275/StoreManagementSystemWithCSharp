using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Buoi06_01.models;

namespace Buoi06_01.frm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public static ThanhVien thanhvien = null;

        public static TabControl tabControl = null;
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (thanhvien == null)
            {
                Form frm = new frmDangNhap();
                frm.ShowDialog();

                if (thanhvien != null)
                {
                    toolStripStatusLabelTenDangNhap.Text = "Welcome " + thanhvien.HoTen;
                }
                else
                {
                    MessageBox.Show("Login failed or cancelled.");
                }
            }
            else
            {
                toolStripStatusLabelTenDangNhap.Text = "Welcome " + thanhvien.HoTen;
            }
            tabControlMain.ImageList = LoadImageList();
            tabControl = tabControlMain;
        }

        private ImageList LoadImageList()
        {
            ImageList iconsList = new ImageList();
            iconsList.TransparentColor = Color.Blue;
            iconsList.ColorDepth = ColorDepth.Depth32Bit;
            iconsList.ImageSize = new Size(25, 25);
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\settings.png")); // 0
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\sinh-vien.png")); // 1
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\icon-khoa.png")); // 2
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\students.png")); // 3
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\question.png")); // 4
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\profile.png")); // 5
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\padlock.png")); // 6
            return iconsList;
        }

        private bool ExistTabPage(TabControl tabControl, string tabName)
        {
            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab.Name == tabName)
                {
                    return true;
                }
            }
            return false;
        }

        private void SinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Sinh Viên";
            tab.Name = "tbSinhVien";
            tab.ImageIndex = 1;

            // Tạo form và add vào tabpage tên tab
            Form frm = new frmSinhVien();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);

            // Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbSinhVien"))
            {
                tabControlMain.TabPages.Add(tab);
            }

            tabControlMain.SelectedTab = tabControlMain.TabPages["tbSinhVien"];
        }

        private void ThanhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Thành Viên";
            tab.Name = "tbThanhVien";
            tab.ImageIndex = 3;

            // Tạo form và add vào tabpage tên tab
            Form frm = new frmThanhVien(); // Giả sử bạn có form `frmThanhVien`
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);

            // Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbThanhVien"))
            {
                tabControlMain.TabPages.Add(tab);
            }

            tabControlMain.SelectedTab = tabControlMain.TabPages["tbThanhVien"];
        }

        private void KhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Khoa";
            tab.Name = "tbKhoa";
            tab.ImageIndex = 2;

            // Tạo form và add vào tabpage tên tab
            Form frm = new frmKhoa(); // Giả sử bạn có form `frmKhoa`
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);

            // Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbKhoa"))
            {
                tabControlMain.TabPages.Add(tab);
            }

            tabControlMain.SelectedTab = tabControlMain.TabPages["tbKhoa"];
        }

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmMain();
            frmMain.thanhvien = null;
            frmMain.ActiveForm.Hide();
            frm.ShowDialog();
        }

        private void XemChiTietTVtoolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            // Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Chi tiết thành viên";
            tab.Name = "tbXCTThanhVien";
            tab.ImageIndex = 5;

            // Tạo form và add vào tabpage tên tab
            Form frm = new frmThongTinTV();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);

            // Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbXCTThanhVien"))
            {
                tabControlMain.TabPages.Add(tab);
            }

            tabControlMain.SelectedTab = tabControlMain.TabPages["tbXCTThanhVien"];
        }

        private void DoiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new TabPage
            TabPage tab = new TabPage();
            tab.Text = "Đổi mật khẩu";
            tab.Name = "tbDoiMatKhau";
            tab.ImageIndex = 6;

            // Create the form
            Form frm = new frmDoiMatKhau();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();

            // Check and add the tab page if not already added
            if (!ExistTabPage(frmMain.tabControl, "tbDoiMatKhau"))
            {
                frmMain.tabControl.TabPages.Add(tab);
            }

            // Set the selected tab
            frmMain.tabControl.SelectedTab = frmMain.tabControl.TabPages["tbDoiMatKhau"];
        }

        private void ThoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TroGiupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmTroGiup();
            frm.ShowDialog();
        }
    }
}
