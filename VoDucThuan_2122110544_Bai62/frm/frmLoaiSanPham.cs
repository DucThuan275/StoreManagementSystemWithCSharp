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
    public partial class frmLoaiSanPham : Form
    {
        LoaiSanPhamDAO lspDAO = new LoaiSanPhamDAO();
        private string AddOrEdit = "";

        public event Action OnLoaiSanPhamAdded;
        public frmLoaiSanPham()
        {
            InitializeComponent();
        }

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            dgvDSLoaiSanPham.AutoGenerateColumns = false;
            loadLoaiSanPham();
            OnOffControl(false);
        }
        private void ResetForm()
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtChiTiet.Clear();
        }
        private void OnOffControl(bool status)
        {
            txtMaLoai.Enabled = status;
            txtTenLoai.Enabled = status;
            txtChiTiet.Enabled = status;
            btnLuu.Enabled = status;
            btnSua.Enabled = status;
            btnXoa.Enabled = status;
        }

        private void loadLoaiSanPham()
        {
            dgvDSLoaiSanPham.DataSource = lspDAO.getList();
            txtTongLoaiSP.Text = lspDAO.getCount().ToString();
        }

        private void dgvDSLoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vtChon = e.RowIndex;
            if (vtChon >= 0 && vtChon < dgvDSLoaiSanPham.Rows.Count)
            {
                btnXoa.Enabled = true;
                btnSua.Enabled = true;

                // Lấy dữ liệu từ các cột trong DataGridView và hiển thị lên các điều khiển
                txtMaLoai.Text = dgvDSLoaiSanPham.Rows[vtChon].Cells["MaLoai"].Value.ToString();
                txtTenLoai.Text = dgvDSLoaiSanPham.Rows[vtChon].Cells["TenLoai"].Value.ToString();
                txtChiTiet.Text = dgvDSLoaiSanPham.Rows[vtChon].Cells["ChiTiet"].Value.ToString();
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetForm();
            AddOrEdit = "Add";
            btnLuu.Enabled = true;
            txtMaLoai.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            AddOrEdit = "Edit";
            OnOffControl(true);
            txtMaLoai.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaLoai.Text.Trim(), out int masp))
            {
                try
                {
                    lspDAO.delete(masp);
                    loadLoaiSanPham();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
            else
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ", "Lỗi");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage tbLoaiSanPham = frmMain.tabControl.TabPages["tbLoaiSanPham"];

            // Nếu tab tồn tại, thực hiện xóa
            if (tbLoaiSanPham != null)
            {
                frmMain.tabControl.TabPages.Remove(tbLoaiSanPham);
            }
            else
            {
                MessageBox.Show("Tab không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị của biến AddOrEdit để xác định thao tác
            if (string.IsNullOrEmpty(AddOrEdit))
            {
                MessageBox.Show("Vui lòng chọn Thêm hoặc Sửa trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ form
            string tenLoai = txtTenLoai.Text.Trim();
            string chiTiet = txtChiTiet.Text.Trim();
            int maTV = 1;
            if (string.IsNullOrEmpty(tenLoai))
            {
                MessageBox.Show("Tên loại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (AddOrEdit == "Add")
                {
                    // Thêm mới loại sản phẩm
                    LoaiSP loaiSP = new LoaiSP
                    {
                        TenLoai = tenLoai,
                        ChiTiet = chiTiet,
                        MaTV = maTV
                    };

                    bool result = lspDAO.insert(loaiSP);
                    if (result)
                    {
                        MessageBox.Show("Thêm mới loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OnLoaiSanPhamAdded?.Invoke();
                        loadLoaiSanPham();
                        ResetForm();
                        OnOffControl(false);
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (AddOrEdit == "Edit")
                {
                    // Cập nhật loại sản phẩm
                    if (int.TryParse(txtMaLoai.Text.Trim(), out int maLoai))
                    {
                        LoaiSP loaiSP = new LoaiSP
                        {
                            MaLoai = maLoai,
                            TenLoai = tenLoai,
                            ChiTiet = chiTiet,
                            MaTV = maTV
                        };

                        bool result = lspDAO.update(loaiSP);
                        if (result)
                        {
                            MessageBox.Show("Cập nhật loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadLoaiSanPham();
                            ResetForm();
                            OnOffControl(false);
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã loại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            AddOrEdit = "";
            OnOffControl(false);
            ResetForm();
            loadLoaiSanPham();
        }
    }
}
