using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buoi06_02.DAO;
using Buoi06_02.models;

namespace Buoi06_02.frm
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public static class MaHoa
        {
            public static string ToSHA256(string str)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(str);
                    byte[] hashBytes = sha256.ComputeHash(inputBytes);
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                }
            }

            public static string ToMD5(string str)
            {
                MD5 mh = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(str);
                byte[] hash = mh.ComputeHash(inputBytes);
                StringBuilder chuoiMaHoa = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    chuoiMaHoa.Append(hash[i].ToString("X2"));
                }
                return chuoiMaHoa.ToString();
            }
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {

            txtMatKhau.PasswordChar = '*';
            txtTaiKhoan.Focus();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text.Trim();
            string password = MaHoa.ToMD5(txtMatKhau.Text.Trim()); // Sửa lại mã hóa

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

        private void cbShowPassWork_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassWork.Checked)
            {
                txtMatKhau.PasswordChar = '\0'; // Hiển thị mật khẩu
            }
            else
            {
                txtMatKhau.PasswordChar = '*'; // Ẩn mật khẩu
            }
        }
    }
}
