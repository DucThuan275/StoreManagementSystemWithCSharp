using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buoi06_02.frm;
using Buoi06_02.models;

namespace Buoi06_02
{
    public partial class frmMain : Form
    {
        public static ThanhVien thanhvien = null;

        public static TabControl tabControl = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (thanhvien == null)
            {
                // Hiển thị form đăng nhập
                Form frm = new frmDangNhap();
                frm.ShowDialog();

                // Kiểm tra nếu đăng nhập thành công
                if (thanhvien != null)
                {
                    toolStripStatusLabelTenDangNhap.Text = "Welcome " + thanhvien.HoTen;

                    // Thêm tab frmWelcome vào tabControl khi đăng nhập thành công
                    AddWelcomeTab();
                }
                else
                {
                    MessageBox.Show("Login failed or cancelled.");
                    Application.Exit();
                }
            }
            else
            {
                // Nếu đã có người dùng đăng nhập, hiển thị tên
                toolStripStatusLabelTenDangNhap.Text = "Welcome " + thanhvien.HoTen;

                // Thêm tab frmWelcome vào tabControl
                AddWelcomeTab();
            }

            tabControlMain.ImageList = LoadImageList();
            tabControl = tabControlMain;
        }

        // Phương thức thêm tab frmWelcome vào tabControl
        private void AddWelcomeTab()
        {
            TabPage tab = new TabPage();
            tab.Text = "Chào mừng";
            tab.Name = "tbWelcome";
            tab.ImageIndex = 7;

            // Tạo form và add vào tabpage tên tab
            Form frm = new frmWelcome();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);

            // Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbWelcome"))
            {
                tabControlMain.TabPages.Add(tab);
            }

            tabControlMain.SelectedTab = tabControlMain.TabPages["tbWelcome"];
        }

        private ImageList LoadImageList()
        {
            ImageList iconsList = new ImageList();
            iconsList.TransparentColor = Color.Blue;
            iconsList.ColorDepth = ColorDepth.Depth32Bit;
            iconsList.ImageSize = new Size(25, 25);
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\sanpham.png")); // 0
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\loaisanpham.png")); // 1
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\donhang.png")); // 2
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\thanhvien.png")); // 3
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\trogiup.png")); // 4
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\profile.png")); // 5
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\reset-password.png")); // 6
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\welcome.png")); // 6
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

        private void QuanLySanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Sản phẩm";
            tab.Name = "tbSanPham";
            tab.ImageIndex = 0;

            // Tạo form và add vào tabpage tên tab
            Form frm = new frmSanPham();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);

            // Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbSanPham"))
            {
                tabControlMain.TabPages.Add(tab);
            }

            tabControlMain.SelectedTab = tabControlMain.TabPages["tbSanPham"];
        }

        private void QuanLyLoaiSanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Loại sản phẩm";
            tab.Name = "tbLoaiSanPham";
            tab.ImageIndex = 1;

            // Tạo form và add vào tabpage tên tab
            Form frm = new frmLoaiSanPham();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);

            // Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbLoaiSanPham"))
            {
                tabControlMain.TabPages.Add(tab);
            }

            tabControlMain.SelectedTab = tabControlMain.TabPages["tbLoaiSanPham"];
        }

        private void QuanLyDonHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Đơn hàng";
            tab.Name = "tbDonHang";
            tab.ImageIndex = 2;

            // Tạo form và add vào tabpage tên tab
            Form frm = new frmDonHang();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);

            // Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbDonHang"))
            {
                tabControlMain.TabPages.Add(tab);
            }

            tabControlMain.SelectedTab = tabControlMain.TabPages["tbDonHang"];
        }

        private void QuanLyThanhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Thành Viên";
            tab.Name = "tbThanhVien";
            tab.ImageIndex = 3;

            // Tạo form và add vào tabpage tên tab
            Form frm = new frmThanhVien();
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

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmMain();
            frmMain.thanhvien = null;
            frmMain.ActiveForm.Hide();
            frm.ShowDialog();
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

        private void XemCTTVtoolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            // Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Chi tiết thành viên";
            tab.Name = "tbXCTThanhVien";
            tab.ImageIndex = 5;

            // Tạo form và add vào tabpage tên tab
            Form frm = new frmThongTinThanhVien();
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

        private void TroGiupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmTroGiup();
            frm.ShowDialog();
        }
    }
}
