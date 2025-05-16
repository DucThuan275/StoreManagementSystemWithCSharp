using System;
using System.Windows.Forms;
using Buoi06_01.DAO;
using Buoi06_01.models;

namespace Buoi06_01.frm
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            txtUsername.Focus();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = MaHoa.ToMD5(txtPassword.Text.Trim()); // Sửa lại mã hóa

            //string password = txtPassword.Text.Trim(); // Sửa lại mã hóa
            ThanhVienDAO thanhvienDAO = new ThanhVienDAO();
            ThanhVien tv = thanhvienDAO.getRow(username);
            if (tv == null)
            {
                lblThongBao.Text = "Tài khoản không tồn tại!";
            }
            else
            {
                if (tv.MatKhau == password)
                {
                    frmMain.thanhvien = tv;
                    this.Close();
                }
                else
                {
                    lblThongBao.Text = "Mật khẩu không chính xác!";
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
