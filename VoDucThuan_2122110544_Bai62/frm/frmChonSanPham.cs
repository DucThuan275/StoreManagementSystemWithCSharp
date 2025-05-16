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

namespace Buoi06_02.frm
{
    public partial class frmChonSanPham : Form
    {
        public delegate void ChonSanPhamEventHandler(string maSP, string tenSP, string donVT, decimal donGia, int soLuong, decimal thanhTien);
        public event ChonSanPhamEventHandler OnChonSanPham;
        SanPhamDAO spDAO = new SanPhamDAO();
        private string AddOrEdit = "";
        public frmChonSanPham()
        {
            InitializeComponent();
        }

        private void frmChonSanPham_Load(object sender, EventArgs e)
        {
            dgvDSSanPham.AutoGenerateColumns = false;
            LoadSanPham();
        }

        private void LoadSanPham()
        {
            dgvDSSanPham.DataSource = spDAO.GetListWithTenLoai();
            txtTongSP.Text = spDAO.getCount().ToString();
            nudSoLuong.ValueChanged += new EventHandler(nudSoLuong_ValueChanged);
        }

        private void dgvDSSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vtChon = e.RowIndex;
            if (vtChon >= 0 && vtChon < dgvDSSanPham.Rows.Count)
            {
                // Lấy dữ liệu từ các cột trong DataGridView và hiển thị lên các điều khiển
                txtMaSP.Text = dgvDSSanPham.Rows[vtChon].Cells["MaSP"].Value.ToString();
                txtTenSP.Text = dgvDSSanPham.Rows[vtChon].Cells["TenSP"].Value.ToString();
                txtDonGia.Text = dgvDSSanPham.Rows[vtChon].Cells["GiaBan"].Value.ToString();
                cbbDonVT.Text = dgvDSSanPham.Rows[vtChon].Cells["DonVT"].Value.ToString();
                nudSoLuong.Value = 1;
                // Tính lại thành tiền khi chọn sản phẩm
                CalculateThanhTien();
            }
        }

        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            // Tính lại thành tiền khi số lượng thay đổi
            CalculateThanhTien();
        }

        private void CalculateThanhTien()
        {
            decimal donGia = 0;
            int soLuong = (int)nudSoLuong.Value;

            // Kiểm tra xem giá mua có hợp lệ không
            if (decimal.TryParse(txtDonGia.Text, out donGia))
            {
                decimal thanhTien = donGia * soLuong;
                txtThanhTien.Text = thanhTien.ToString();
            }
            else
            {
                MessageBox.Show("Giá mua không hợp lệ", "Lỗi");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtDonGia.Clear();
            cbbDonVT.SelectedItem = -1;
            nudSoLuong.Value = 1;
            txtThanhTien.Clear();
        }

        private void btnChonSanPham_Click(object sender, EventArgs e)
        {
            int vtChon = dgvDSSanPham.CurrentRow.Index;
            if (vtChon >= 0 && vtChon < dgvDSSanPham.Rows.Count)
            {
                string maSP = dgvDSSanPham.Rows[vtChon].Cells["MaSP"].Value.ToString();
                string tenSP = dgvDSSanPham.Rows[vtChon].Cells["TenSP"].Value.ToString();
                string donVT = dgvDSSanPham.Rows[vtChon].Cells["DonVT"].Value.ToString();
                decimal donGia = Convert.ToDecimal(dgvDSSanPham.Rows[vtChon].Cells["GiaBan"].Value);
                int soLuong = (int)nudSoLuong.Value;
                decimal thanhTien = donGia * soLuong;

                // Gọi sự kiện và truyền dữ liệu
                OnChonSanPham?.Invoke(maSP, tenSP, donVT, donGia, soLuong, thanhTien);

                this.Close();
            }
        }

    }
}
