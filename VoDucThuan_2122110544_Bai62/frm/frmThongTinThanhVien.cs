using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buoi06_02.models;

namespace Buoi06_02.frm
{
    public partial class frmThongTinThanhVien : Form
    {
        public frmThongTinThanhVien()
        {
            InitializeComponent();
        }

        private void frmThongTinThanhVien_Load(object sender, EventArgs e)
        {
            ThanhVien thanhVien = frmMain.thanhvien;
            txtTenDangNhap.Text = thanhVien.TenDangNhap;
            txtMatKhau.Text = thanhVien.MatKhau;
            txtHoTen.Text = thanhVien.HoTen;
            txtEmail.Text = thanhVien.Email;
            mtxtDienThoai.Text = thanhVien.DienThoai;
            cbbQuyen.Text = thanhVien.Quyen;
            txtMatKhau.PasswordChar = '*';
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
        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage tabThanhVien = frmMain.tabControl.TabPages["tbXCTThanhVien"];

            // Nếu tab tồn tại, thực hiện xóa
            if (tabThanhVien != null)
            {
                frmMain.tabControl.TabPages.Remove(tabThanhVien);
            }
            else
            {
                MessageBox.Show("Tab không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            // Remove the existing tab page
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbXCTThanhVien"]);

            // Create a new TabPage
            TabPage tab = new TabPage();
            tab.Text = "Đổi mật khẩu";
            tab.Name = "tbDoiMatKhau";
            tab.ImageIndex = 3;

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
    }
}
