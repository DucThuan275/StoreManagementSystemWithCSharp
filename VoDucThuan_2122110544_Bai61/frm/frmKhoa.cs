using System;
using System.Windows.Forms;
using Buoi06_01.DAO;
using Buoi06_01.models;

namespace Buoi06_01.frm
{
    public partial class frmKhoa : Form
    {
        KhoaDAO kDAO = new KhoaDAO();
        private string AddOrEdit = "";
        public event Action OnKhoaAdded;
        public frmKhoa()
        {
            InitializeComponent();
        }

        private void frmKhoa_Load(object sender, EventArgs e)
        {
            dgvDSKhoa.AutoGenerateColumns = false;
            loadKhoa();
            OnOffControl(false);
        }

        private void OnOffControl(bool status)
        {
            txtMaKhoa.Enabled = status;
            txtTenKhoa.Enabled = status;
            txtGhiChu.Enabled = status;
            txtEmail.Enabled = status;
            btnLuu.Enabled = status;
            btnSua.Enabled = status;
            btnXoa.Enabled = status;
        }

        private void loadKhoa()
        {
            dgvDSKhoa.DataSource = kDAO.getList();
            txtTongKhoa.Text = kDAO.getCount().ToString();
        }
        private void ResetForm()
        {
            txtMaKhoa.Clear();
            txtTenKhoa.Clear();
            txtGhiChu.Clear();
            txtEmail.Clear();
        }

        private void dgvDSKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vtChon = e.RowIndex;

            if (vtChon >= 0 && vtChon < dgvDSKhoa.Rows.Count)
            {
                btnXoa.Enabled = true;
                btnSua.Enabled = true;

                // Kiểm tra nếu giá trị ô là null hoặc DBNull và xử lý cho các ô
                txtMaKhoa.Text = dgvDSKhoa.Rows[vtChon].Cells["MaKhoa"].Value != DBNull.Value && dgvDSKhoa.Rows[vtChon].Cells["MaKhoa"].Value != null
                    ? dgvDSKhoa.Rows[vtChon].Cells["MaKhoa"].Value.ToString()
                    : string.Empty;

                txtTenKhoa.Text = dgvDSKhoa.Rows[vtChon].Cells["TenKhoa"].Value != DBNull.Value && dgvDSKhoa.Rows[vtChon].Cells["TenKhoa"].Value != null
                    ? dgvDSKhoa.Rows[vtChon].Cells["TenKhoa"].Value.ToString()
                    : string.Empty;

                txtEmail.Text = dgvDSKhoa.Rows[vtChon].Cells["Email"].Value != DBNull.Value && dgvDSKhoa.Rows[vtChon].Cells["Email"].Value != null
                    ? dgvDSKhoa.Rows[vtChon].Cells["Email"].Value.ToString()
                    : string.Empty;

                txtGhiChu.Text = dgvDSKhoa.Rows[vtChon].Cells["GhiChu"].Value != DBNull.Value && dgvDSKhoa.Rows[vtChon].Cells["GhiChu"].Value != null
                    ? dgvDSKhoa.Rows[vtChon].Cells["GhiChu"].Value.ToString()
                    : string.Empty;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetForm();
            AddOrEdit = "Add";
            OnOffControl(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            AddOrEdit = "Edit";
            OnOffControl(true);
            txtMaKhoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaKhoa.Text.Trim(), out int makhoa))
            {
                try
                {
                    kDAO.delete(makhoa);
                    loadKhoa();
                    MessageBox.Show("Xóa thành công!", "Thông báo");
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage tabKhoa = frmMain.tabControl.TabPages["tbKhoa"];

            // Nếu tab tồn tại, thực hiện xóa
            if (tabKhoa != null)
            {
                frmMain.tabControl.TabPages.Remove(tabKhoa);
            }
            else
            {
                MessageBox.Show("Tab không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string tenkhoa = txtTenKhoa.Text.Trim(); // Tên khoa
                string email = txtEmail.Text.Trim();     // Email
                string ghichu = txtGhiChu.Text.Trim();   // Ghi chú

                if (string.IsNullOrEmpty(tenkhoa))
                {
                    MessageBox.Show("Tên khoa không được để trống.", "Thông báo");
                    return;
                }

                if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ.", "Thông báo");
                    return;
                }

                // Khi thêm mới, không cần kiểm tra Mã Khoa vì sẽ tự động sinh ra
                int maTV = 1;  // Giả sử MaTV là cứng, bạn có thể điều chỉnh theo nhu cầu

                switch (AddOrEdit)
                {
                    case "Add":
                        {
                            // Không cần gán MaKhoa vì nó là tự động tăng
                            Khoa khoa = new Khoa
                            {
                                TenKhoa = tenkhoa,
                                Email = email,
                                GhiChu = ghichu,
                                MaTV = maTV        // Gán cứng MaTV = 1
                            };

                            // Thêm mới bản ghi
                            kDAO.insert(khoa);
                            dgvDSKhoa.DataSource = kDAO.getList();  // Cập nhật lại danh sách khoa
                            OnKhoaAdded?.Invoke();
                            MessageBox.Show("Thêm thành công!", "Thông báo");
                            break;
                        }

                    case "Edit":
                        {
                            // Trường hợp chỉnh sửa, bạn vẫn cần kiểm tra MaKhoa
                            if (string.IsNullOrEmpty(txtMaKhoa.Text.Trim()) || !int.TryParse(txtMaKhoa.Text.Trim(), out int makhoa))
                            {
                                MessageBox.Show("Mã khoa không hợp lệ.", "Thông báo");
                                return;
                            }

                            Khoa khoa = kDAO.GetRowByMaKhoa(makhoa);  // Lấy đối tượng Khoa theo MaKhoa
                            if (khoa != null)
                            {
                                khoa.TenKhoa = tenkhoa;
                                khoa.Email = email;
                                khoa.GhiChu = ghichu;
                                khoa.MaTV = maTV;  // Gán cứng MaTV = 1

                                // Cập nhật bản ghi
                                kDAO.update(khoa);
                                dgvDSKhoa.DataSource = kDAO.getList();  // Cập nhật lại danh sách khoa
                                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy Mã Khoa", "Thông báo");
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
    }
}