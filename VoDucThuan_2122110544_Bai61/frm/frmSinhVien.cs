using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buoi06_01.DAO;
using Buoi06_01.models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Buoi06_01.frm
{
    public partial class frmSinhVien : Form
    {

        KhoaDAO kDAO = new KhoaDAO();
        SinhVienDAO svDAO = new SinhVienDAO();
        private string AddOrEdit = "";
        public frmSinhVien()
        {
            InitializeComponent();
        }
        private void Frm_OnKhoaAdded()
        {
            loadKhao();
        }
        private void btnThemKhoa_Click(object sender, EventArgs e)
        {
            frmKhoa frm = new frmKhoa();
            frm.OnKhoaAdded += Frm_OnKhoaAdded;
            frm.ShowDialog();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {

            dgvDSSinhVien.AutoGenerateColumns = false;
            loadSinhVien();
            loadKhao();
            OnOffControl(false);
        }
        private void ResetForm()
        {
            mtxtDienThoai.Clear();
            mtxtMaSV.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            mtxtDienThoai.Clear();
            txtDiemTB.Clear();
            cbbKhoa.SelectedIndex = -1;
        }
        private void OnOffControl(bool status)
        {
            mtxtMaSV.Enabled = status;
            txtHoTen.Enabled = status;
            mtxtDienThoai.Enabled = status;
            txtEmail.Enabled = status;
            txtDiemTB.Enabled = status;
            btnLuu.Enabled = status;
            btnSua.Enabled = status;
            btnXoa.Enabled = status;
        }

        private void loadKhao()
        {
            cbbKhoa.DataSource = kDAO.getList();
            cbbKhoa.DisplayMember = "TenKhoa";
            cbbKhoa.ValueMember = "MaKhoa";
        }

        private void loadSinhVien()
        {
            dgvDSSinhVien.DataSource = svDAO.getListWithTenKhoa();
            txtTongSV.Text = svDAO.getCount().ToString();
        }

        private void dgvDSSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vtChon = e.RowIndex;
            if (vtChon >= 0 && vtChon < dgvDSSinhVien.Rows.Count)
            {
                btnXoa.Enabled = true;
                btnSua.Enabled = true;

                // Lấy dữ liệu từ các cột trong DataGridView và hiển thị lên các điều khiển
                mtxtMaSV.Text = dgvDSSinhVien.Rows[vtChon].Cells["MaSV"].Value.ToString();
                txtHoTen.Text = dgvDSSinhVien.Rows[vtChon].Cells["HoTen"].Value.ToString();
                txtDiemTB.Text = dgvDSSinhVien.Rows[vtChon].Cells["DiemTB"].Value.ToString();
                mtxtDienThoai.Text = dgvDSSinhVien.Rows[vtChon].Cells["DienThoai"].Value.ToString();
                txtEmail.Text = dgvDSSinhVien.Rows[vtChon].Cells["Email"].Value.ToString();

                cbbKhoa.Text = dgvDSSinhVien.Rows[vtChon].Cells["TenKhoa"].Value.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage tabSinhVien = frmMain.tabControl.TabPages["tbSinhVien"];

            // Nếu tab tồn tại, thực hiện xóa
            if (tabSinhVien != null)
            {
                frmMain.tabControl.TabPages.Remove(tabSinhVien);
            }
            else
            {
                MessageBox.Show("Tab không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            AddOrEdit = "Add";
            OnOffControl(true);
            ResetForm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            AddOrEdit = "Edit";
            OnOffControl(true);
            mtxtMaSV.Enabled = false;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            int maKhoa = Convert.ToInt32(cbbKhoa.SelectedValue);
            var filteredList = svDAO.getListWithTenKhoa()
                                     .Where(sv => sv.MaKhoa == maKhoa)
                                     .ToList();
            dgvDSSinhVien.DataSource = filteredList;
            txtTongSV.Text = filteredList.Count.ToString();
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
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Get user input
                string masv = mtxtMaSV.Text.Trim();
                string hoten = txtHoTen.Text.Trim();
                string email = txtEmail.Text.Trim();
                string dienthoai = mtxtDienThoai.Text.Trim();
                string diemTB = txtDiemTB.Text.Trim();
                int makhoa = Convert.ToInt32(cbbKhoa.SelectedValue);  // Lấy MaKhoa từ ComboBox

                // Kiểm tra các điều kiện đầu vào
                if (string.IsNullOrEmpty(masv))
                {
                    MessageBox.Show("Mã sinh viên không được để trống.", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(hoten))
                {
                    MessageBox.Show("Họ tên không được để trống hoặc chỉ chứa khoảng trắng.", "Thông báo");
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

                if (string.IsNullOrEmpty(diemTB) || !double.TryParse(diemTB, out double diem) || diem < 0 || diem > 10)
                {
                    MessageBox.Show("Điểm trung bình phải là một số hợp lệ và nằm trong khoảng từ 0 đến 10.", "Thông báo");
                    return;
                }

                int matv = 1;
                // Xử lý thêm hoặc sửa dữ liệu
                switch (AddOrEdit)
                {
                    case "Add":
                        {
                            SinhVien sv = new SinhVien();
                            sv.MaSV = masv;
                            sv.HoTen = hoten;
                            sv.Email = email;
                            sv.DienThoai = dienthoai;
                            sv.DiemTB = Convert.ToDouble(diemTB);  // Chuyển đổi điểm trung bình thành kiểu double
                            sv.MaKhoa = makhoa;
                            sv.MaTV = matv;
                            // Thêm mới sinh viên vào cơ sở dữ liệu
                            string result = svDAO.insert(sv);
                            if (result == "Thêm sinh viên thành công!")
                            {
                                txtTongSV.Text = svDAO.getCount().ToString();  // Cập nhật tổng số sinh viên
                                dgvDSSinhVien.DataSource = svDAO.getListWithTenKhoa();  // Cập nhật DataGridView
                                MessageBox.Show(result, "Thông báo");
                            }
                            else
                            {
                                MessageBox.Show(result, "Thông báo");
                            }

                            break;
                        }

                    case "Edit":
                        {
                            // Parse masv vào kiểu chuỗi trước khi tìm kiếm
                            if (!string.IsNullOrEmpty(masv))
                            {
                                SinhVien sv = svDAO.GetRowByMaSV(masv);  // Lấy sinh viên dựa trên Mã Sinh Viên
                                if (sv != null)
                                {
                                    sv.HoTen = hoten;
                                    sv.Email = email;
                                    sv.DienThoai = dienthoai;
                                    sv.DiemTB = Convert.ToDouble(diemTB);
                                    sv.MaKhoa = makhoa;

                                    // Cập nhật thông tin sinh viên
                                    svDAO.update(sv);
                                    dgvDSSinhVien.DataSource = svDAO.getListWithTenKhoa();   // Cập nhật DataGridView
                                    MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo");
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy sinh viên với mã " + masv, "Thông báo");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Mã sinh viên không hợp lệ", "Thông báo");
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
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị MaSV từ TextBox (kiểu string)
                string maSV = mtxtMaSV.Text.Trim();

                // Kiểm tra xem maSV có rỗng hay không
                if (string.IsNullOrEmpty(maSV))
                {
                    MessageBox.Show("Mã sinh viên không hợp lệ!", "Thông báo");
                    return;
                }

                // Gọi phương thức delete để xóa sinh viên
                string result = svDAO.delete(maSV);
                loadSinhVien();  // Tải lại danh sách sinh viên sau khi xóa
                MessageBox.Show(result, "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

    }
}
