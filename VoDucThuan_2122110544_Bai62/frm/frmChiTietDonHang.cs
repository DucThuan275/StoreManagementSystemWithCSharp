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
    public partial class frmChiTietDonHang : Form
    {
        public frmChiTietDonHang()
        {
            InitializeComponent();
        }
        private void frmChiTietDonHang_Load(object sender, EventArgs e)
        {

        }
        public void LoadChiTietDonHang(List<DonHangChiTiet> chiTietDonHangs)
        {
            dgvChiTietDonHang.DataSource = null;

            if (chiTietDonHangs != null && chiTietDonHangs.Count > 0)
            {
                SetupDataGridView();

                // Chuyển danh sách `DonHangChiTiet` thành danh sách dữ liệu có `TenSP`
                var data = chiTietDonHangs.Select(dh => new
                {
                    dh.MaSP,
                    TenSP = dh.SanPham != null ? dh.SanPham.TenSP : "Không xác định", // Lấy tên sản phẩm từ SanPham
                    dh.DonVT,
                    dh.DonGia,
                    dh.SoLuong,
                    ThanhTien = dh.SoLuong * dh.DonGia
                }).ToList();

                dgvChiTietDonHang.DataSource = data;

                // Hiển thị tổng số bản ghi vào textbox
                txtTongCTDH.Text = data.Count.ToString();
            }
            else
            {
                MessageBox.Show("Không có chi tiết đơn hàng để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void SetupDataGridView()
        {
            dgvChiTietDonHang.AutoGenerateColumns = false;
            dgvChiTietDonHang.Columns.Clear();

            dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "MaSP",            // Tên cột (dùng để truy cập cột)
                HeaderText = "Mã sản phẩm", // Tiêu đề hiển thị trong header
                DataPropertyName = "MaSP", // Tên thuộc tính trong đối tượng DonHangChiTiet
                Width = 100               // Độ rộng của cột
            });

            dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TenSP",
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "TenSP", // Tên thuộc tính trong đối tượng DonHangChiTiet
                Width = 100
            });

            dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DonVT",
                HeaderText = "Đơn vị tính",
                DataPropertyName = "DonVT", // Tên thuộc tính trong đối tượng DonHangChiTiet
                Width = 100
            });

            dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DonGia",
                HeaderText = "Đơn giá",
                DataPropertyName = "DonGia", // Tên thuộc tính trong đối tượng DonHangChiTiet
                Width = 100
            });

            dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "SoLuong",
                HeaderText = "Số lượng",
                DataPropertyName = "SoLuong", // Tên thuộc tính trong đối tượng DonHangChiTiet
                Width = 100
            });

            dgvChiTietDonHang.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ThanhTien",
                HeaderText = "Thành tiền",
                DataPropertyName = "ThanhTien", // Tên thuộc tính trong đối tượng DonHangChiTiet
                Width = 100
            });
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
