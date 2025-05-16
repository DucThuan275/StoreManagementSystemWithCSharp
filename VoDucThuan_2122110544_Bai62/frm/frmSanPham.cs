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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Buoi06_02.frm
{
    public partial class frmSanPham : Form
    {
        LoaiSanPhamDAO lspDAO = new LoaiSanPhamDAO();
        SanPhamDAO spDAO = new SanPhamDAO();
        private string AddOrEdit = "";
        public frmSanPham()
        {
            InitializeComponent();
        }
        private void Frm_OnLoaiSanPhamAdded()
        {
            LoadLoaiSanPham();
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            var donVTList = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("donvi", "Đơn vị"),
                new KeyValuePair<string, string>("hop", "Hộp"),
                new KeyValuePair<string, string>("bo", "Bộ"),
                new KeyValuePair<string, string>("cai", "Cái"),
                new KeyValuePair<string, string>("goi", "Gói"),
                new KeyValuePair<string, string>("cap", "Cặp")
            };

            // Gán danh sách vào ComboBox
            cbbDonVT.DataSource = donVTList;
            cbbDonVT.DisplayMember = "Value";
            cbbDonVT.ValueMember = "Key";
            cbbDonVT.SelectedIndex = 0;

            dgvDSSanPham.AutoGenerateColumns = false;
            LoadSanPham();
            LoadLoaiSanPham();
            OnOffControl(false);
        }

        private void OnOffControl(bool status)
        {
            txtMaSP.Enabled = status;
            txtTenSP.Enabled = status;
            txtGiaMua.Enabled = status;
            txtGiaBan.Enabled = status;
            cbbDonVT.Enabled = status;
            btnLuu.Enabled = status;
            btnSua.Enabled = status;
            btnXoa.Enabled = status;
        }
       
        private void LoadLoaiSanPham()
        {
            cbbMaLoai.DataSource = lspDAO.getList();
            cbbMaLoai.DisplayMember = "TenLoai";
            cbbMaLoai.ValueMember = "MaLoai";
        }

        private void LoadSanPham()
        {
            dgvDSSanPham.DataSource = spDAO.GetListWithTenLoai();
            txtTongSP.Text = spDAO.getCount().ToString();
            dgvDSSanPham.Columns["MaLoai"].Visible = false;
        }

        private void btnThemLoaiSP_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham frm = new frmLoaiSanPham();
            frm.OnLoaiSanPhamAdded += Frm_OnLoaiSanPhamAdded;
            frm.ShowDialog();
        }
        private void ResetForm()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaMua.Clear();
            txtGiaBan.Clear();
            cbbDonVT.SelectedIndex = -1;
            cbbMaLoai.SelectedIndex = -1;
        }

        private void dgvDSSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vtChon = e.RowIndex;
            if (vtChon >= 0 && vtChon < dgvDSSanPham.Rows.Count)
            {
                btnXoa.Enabled = true;
                btnSua.Enabled = true;

                // Lấy dữ liệu từ các cột trong DataGridView và hiển thị lên các điều khiển
                txtMaSP.Text = dgvDSSanPham.Rows[vtChon].Cells["MaSP"].Value.ToString();
                txtTenSP.Text = dgvDSSanPham.Rows[vtChon].Cells["TenSP"].Value.ToString();
                txtGiaMua.Text = dgvDSSanPham.Rows[vtChon].Cells["GiaMua"].Value.ToString();
                txtGiaBan.Text = dgvDSSanPham.Rows[vtChon].Cells["GiaBan"].Value.ToString();
                cbbDonVT.Text = dgvDSSanPham.Rows[vtChon].Cells["DonVT"].Value.ToString();

                // Lấy MaKhoa từ DataGridView
                int maLoai = Convert.ToInt32(dgvDSSanPham.Rows[vtChon].Cells["MaLoai"].Value);

                // Tìm mục có MaKhoa trong ComboBox và chọn mục tương ứng
                cbbMaLoai.SelectedValue = maLoai;
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage tbSanPham = frmMain.tabControl.TabPages["tbSanPham"];

            // Nếu tab tồn tại, thực hiện xóa
            if (tbSanPham != null)
            {
                frmMain.tabControl.TabPages.Remove(tbSanPham);
            }
            else
            {
                MessageBox.Show("Tab không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void OnOffControlAdd(bool status)
        {
            txtMaSP.Enabled = status;
            txtTenSP.Enabled = status;
            txtGiaMua.Enabled = status;
            txtGiaBan.Enabled = status;
            cbbDonVT.Enabled = status;
            btnLuu.Enabled = status;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            AddOrEdit = "Add";
            OnOffControlAdd(true);
            ResetForm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            AddOrEdit = "Edit";
            OnOffControl(true);
            txtMaSP.Enabled = false;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            int maLoai = Convert.ToInt32(cbbMaLoai.SelectedValue);
            var filteredList = spDAO.GetListWithTenLoai()
                                     .Where(sv => sv.MaLoai == maLoai)
                                     .ToList();
            dgvDSSanPham.DataSource = filteredList;
            txtTongSP.Text = filteredList.Count.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị MaSV từ TextBox (kiểu string)
                string maSP = txtMaSP.Text.Trim();

                // Kiểm tra xem maSV có rỗng hay không
                if (string.IsNullOrEmpty(maSP))
                {
                    MessageBox.Show("Mã sản phẩm không hợp lệ!", "Thông báo");
                    return;
                }

                // Gọi phương thức delete để xóa sinh viên
                string result = spDAO.delete(maSP);
                LoadSanPham();  // Tải lại danh sách sinh viên sau khi xóa
                MessageBox.Show(result, "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường dữ liệu bắt buộc
                if (string.IsNullOrWhiteSpace(txtTenSP.Text) || string.IsNullOrWhiteSpace(cbbDonVT.Text) || string.IsNullOrWhiteSpace(txtGiaBan.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse giá mua và giá bán
                decimal? giaMua = null;
                if (!string.IsNullOrWhiteSpace(txtGiaMua.Text))
                {
                    giaMua = decimal.Parse(txtGiaMua.Text);
                }

                decimal giaBan = decimal.Parse(txtGiaBan.Text);

                // Kiểm tra chế độ Add hoặc Edit
                if (AddOrEdit == "Add")
                {
                    SanPham newSanPham = new SanPham
                    {
                        MaSP = txtMaSP.Text.Trim(),
                        TenSP = txtTenSP.Text.Trim(),
                        DonVT = cbbDonVT.Text.Trim(),
                        GiaMua = giaMua,
                        GiaBan = giaBan,
                        MaLoai = int.Parse(cbbMaLoai.SelectedValue.ToString()), // Giả sử combobox chứa danh sách loại sản phẩm
                        MaTV = 1 // Giá trị giả định cho MaTV, thay bằng giá trị phù hợp
                    };

                    if (spDAO.insert(newSanPham))
                    {
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                        LoadSanPham();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (AddOrEdit == "Edit")
                {
                    // Tìm sản phẩm theo mã để cập nhật
                    var existingSanPham = spDAO.getById(txtMaSP.Text.Trim());
                    if (existingSanPham != null)
                    {
                        existingSanPham.TenSP = txtTenSP.Text.Trim();
                        existingSanPham.DonVT = cbbDonVT.Text.Trim();
                        existingSanPham.GiaMua = giaMua;
                        existingSanPham.GiaBan = giaBan;
                        existingSanPham.MaLoai = int.Parse(cbbMaLoai.SelectedValue.ToString());

                        if (spDAO.update(existingSanPham))
                        {
                            MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetForm();
                            LoadSanPham();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật sản phẩm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Tắt chế độ chỉnh sửa
                OnOffControl(false);
                AddOrEdit = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số cho giá mua và giá bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            AddOrEdit = "";
            OnOffControl(false);
            ResetForm();
            LoadSanPham();
        }

    }
}
