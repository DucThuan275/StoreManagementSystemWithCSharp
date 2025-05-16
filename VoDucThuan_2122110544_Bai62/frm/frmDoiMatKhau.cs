using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buoi06_02.DAO;
using Buoi06_02.models;
using static Buoi06_02.frm.frmDangNhap;

namespace Buoi06_02.frm
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMatKhauCu.PasswordChar = '*';
            txtMatKhauMoi.PasswordChar = '*';
            txtXacNhanMatKhau.PasswordChar = '*';
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage tabThanhVien = frmMain.tabControl.TabPages["tbDoiMatKhau"];

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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Currently logged-in member
                ThanhVien thanhvien = frmMain.thanhvien;
                string matkhaucu = MaHoa.ToMD5(txtMatKhauCu.Text.Trim());
                if (!thanhvien.MatKhau.Equals(matkhaucu))
                {
                    throw new Exception("Mật khẩu cũ không chính xác");
                }

                if (!txtMatKhauMoi.Text.Trim().Equals(txtXacNhanMatKhau.Text.Trim()))
                {
                    throw new Exception("Mật khẩu mới không khớp");
                }

                string matkhaumoi = MaHoa.ToMD5(txtMatKhauMoi.Text.Trim());
                thanhvien.MatKhau = matkhaumoi; // Update the password
                ThanhVienDAO tvDAO = new ThanhVienDAO();
                tvDAO.update(thanhvien);
                MessageBox.Show("Cập nhật thành công");

                frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbDoiMatKhau"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
    }
}
