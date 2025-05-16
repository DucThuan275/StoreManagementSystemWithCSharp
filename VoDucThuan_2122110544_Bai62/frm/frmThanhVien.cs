using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buoi06_02.models;
using System.Windows.Forms;
using Buoi06_02.DAO;
using static Buoi06_02.frm.frmDangNhap;
using System.Text.RegularExpressions;

namespace Buoi06_02.frm
{
    public partial class frmThanhVien : Form
    {
        ThanhVienDAO tvDAO = new ThanhVienDAO();
        private string AddOrEdit = "";
        public frmThanhVien()
        {
            InitializeComponent();
        }

        private void frmThanhVien_Load(object sender, EventArgs e)
        {
            // Danh sách quyền
            var quyenList = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("admin", "Admin"),
                new KeyValuePair<string, string>("customer", "Customer")
            };

            // Gán danh sách vào ComboBox
            cbbQuyen.DataSource = quyenList;
            cbbQuyen.DisplayMember = "Value";
            cbbQuyen.ValueMember = "Key";
            cbbQuyen.SelectedIndex = 0;

            dgvDSThanhVien.AutoGenerateColumns = false;
            // Tải danh sách thành viên
            loadThanhVien();
            // Khóa/bật các điều khiển
            OnOffControl(false);
        }

        private void ResetForm()
        {
            txtTenDN.Clear();
            txtTenTV.Clear();
            txtEmail.Clear();
            mtxtDienThoai.Clear();
            txtMaTV.Clear();
            cbbQuyen.SelectedIndex = -1;
        }
        private void OnOffControl(bool status)
        {
            txtMaTV.Enabled = status;
            txtTenDN.Enabled = status;
            txtTenTV.Enabled = status;
            txtEmail.Enabled = status;
            mtxtDienThoai.Enabled = status;
            btnLuu.Enabled = status;
            btnSua.Enabled = status;
            btnXoa.Enabled = status;
        }

        private void loadThanhVien()
        {
            dgvDSThanhVien.DataSource = tvDAO.getList();
            txtTongTV.Text = tvDAO.getCount().ToString();
        }

        private void dgvDSThanhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vtChon = e.RowIndex;
            if (vtChon >= 0 && vtChon < dgvDSThanhVien.Rows.Count)
            {
                btnXoa.Enabled = true;
                btnSua.Enabled = true;

                // Lấy dữ liệu từ các cột trong DataGridView và hiển thị lên các điều khiển
                txtMaTV.Text = dgvDSThanhVien.Rows[vtChon].Cells["MaTV"].Value.ToString();
                txtTenDN.Text = dgvDSThanhVien.Rows[vtChon].Cells["TenDangNhap"].Value.ToString();
                txtTenTV.Text = dgvDSThanhVien.Rows[vtChon].Cells["HoTen"].Value.ToString();
                txtEmail.Text = dgvDSThanhVien.Rows[vtChon].Cells["Email"].Value.ToString();
                mtxtDienThoai.Text = dgvDSThanhVien.Rows[vtChon].Cells["DienThoai"].Value.ToString();
                cbbQuyen.Text = dgvDSThanhVien.Rows[vtChon].Cells["Quyen"].Value.ToString();
            }
        }
        private void OnOffControlAdd(bool status)
        {
            txtMaTV.Enabled = status;
            txtTenDN.Enabled = status;
            txtTenTV.Enabled = status;
            txtEmail.Enabled = status;
            mtxtDienThoai.Enabled = status;
            btnLuu.Enabled = status;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            OnOffControlAdd(true);
            ResetForm();
            AddOrEdit = "Add";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            AddOrEdit = "Edit";
            OnOffControl(true);
            txtMaTV.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaTV.Text.Trim(), out int matv))
            {
                try
                {
                    tvDAO.delete(matv);
                    loadThanhVien();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
            else
            {
                MessageBox.Show("Mã thành viên không hợp lệ", "Lỗi");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AddOrEdit))
            {
                MessageBox.Show("Vui lòng chọn Thêm hoặc Sửa trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                // Get user input
                string matv = txtMaTV.Text.Trim();
                string tendangnhap = txtTenDN.Text.Trim();
                string matkhau = tvDAO.getPassword(tendangnhap);
                string hoten = txtTenTV.Text.Trim();
                string email = txtEmail.Text.Trim();
                string dienthoai = mtxtDienThoai.Text.Trim();
                string quyen = cbbQuyen.Text.Trim();
                string matkhauadd = "12345678";
                if (string.IsNullOrEmpty(tendangnhap))
                {
                    MessageBox.Show("Tên đăng nhập không được để trống.", "Thông báo");
                    return;
                }

                string pattern = @"^(?!.*\s{2,})(?=.*[ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚÝàáâãèéêìíòóôõùúýĂăĐđĨĩŨũƠơƯưẠ-ỹ])[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚÝàáâãèéêìíòóôõùúýĂăĐđĨĩŨũƠơƯưẠ-ỹ\s]{2,50}$";
                if (!Regex.IsMatch(hoten.Trim(), pattern))
                {
                    MessageBox.Show("Họ tên không hợp lệ. Tên phải chứa ít nhất một ký tự có dấu, không chứa ký tự đặc biệt hoặc số, và không có dấu cách thừa.", "Thông báo");
                    return;
                }

                if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ.", "Thông báo");
                    return;
                }

                if (string.IsNullOrEmpty(dienthoai) || !IsValidPhoneNumber(dienthoai))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo");
                    return;
                }

                if (string.IsNullOrEmpty(quyen))
                {
                    MessageBox.Show("Quyền không được để trống.", "Thông báo");
                    return;
                }

                switch (AddOrEdit)
                {
                    case "Add":
                        {
                            ThanhVien tv = new ThanhVien();
                            tv.TenDangNhap = tendangnhap;
                            tv.MatKhau = matkhauadd;
                            tv.HoTen = hoten;
                            tv.Email = email;
                            tv.DienThoai = dienthoai;
                            tv.Quyen = quyen;

                            // Add the new record
                            tvDAO.insert(tv);
                            txtTongTV.Text = tvDAO.getCount().ToString();
                            dgvDSThanhVien.DataSource = tvDAO.getList();
                            ResetForm();
                            MessageBox.Show("Thêm thành công!", "Thông báo");
                            break;
                        }

                    case "Edit":
                        {
                            // Parse matv into an integer before querying
                            int matvInt;
                            if (int.TryParse(matv, out matvInt))
                            {
                                ThanhVien tv = tvDAO.getRowMatv(matvInt);  // Pass the parsed integer
                                if (tv != null)
                                {
                                    tv.TenDangNhap = tendangnhap;
                                    tv.MatKhau = matkhau;
                                    tv.HoTen = hoten;
                                    tv.Email = email;
                                    tv.DienThoai = dienthoai;
                                    tv.Quyen = quyen;

                                    // Update the record
                                    tvDAO.update(tv);
                                    ResetForm();
                                    dgvDSThanhVien.DataSource = tvDAO.getList();
                                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy Mã TV", "Thông báo");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Mã TV không hợp lệ", "Thông báo");
                            }
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phone)
        {
            var phoneRegex = @"^(0(91|93|94|95|97|98|90|39)\d{7}|0(59|56|58)\d{7}|0(89|90|93|070|079|077|076|078|083|084|085|081|082)\d{7}|0(86|96|97|98|032|033|034|035|036|037|038|039)\d{7})$";
            return System.Text.RegularExpressions.Regex.IsMatch(phone, phoneRegex);
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            AddOrEdit = "";
            OnOffControl(false);
            ResetForm();
            loadThanhVien();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage tabThanhVien = frmMain.tabControl.TabPages["tbThanhVien"];

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
    }
}
