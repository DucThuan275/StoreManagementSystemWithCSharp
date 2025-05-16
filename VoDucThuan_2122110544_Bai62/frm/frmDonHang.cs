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
using Excel = Microsoft.Office.Interop.Excel;
namespace Buoi06_02.frm
{
    public partial class frmDonHang : Form
    {
        DonHangDAO dhDAO = new DonHangDAO();
        DonHangChiTietDAO dhctDAO = new DonHangChiTietDAO();
        private string AddOrEdit = "";

        public frmDonHang()
        {
            InitializeComponent();
        }

        // Trong form chính
        private void btnChonSanPham_Click(object sender, EventArgs e)
        {
            frmChonSanPham frm = new frmChonSanPham();
            frm.OnChonSanPham += Frm_OnChonSanPham;
            frm.ShowDialog();
        }

        // Xử lý sự kiện khi chọn sản phẩm
        private void Frm_OnChonSanPham(string maSP, string tenSP, string donVT, decimal donGia, int soLuong, decimal thanhTien)
        {
            lbThongTinSP.Items.Add($"Mã sản phẩm: {maSP}");
            lbThongTinSP.Items.Add($"Tên sản phẩm: {tenSP}");
            lbThongTinSP.Items.Add($"Đơn vị tính: {donVT}"); // Đảm bảo bạn thêm đúng Đơn vị tính
            lbThongTinSP.Items.Add($"Giá sản phẩm: {donGia} VNĐ");
            lbThongTinSP.Items.Add($"Số lượng: {soLuong}");
            lbThongTinSP.Items.Add($"Thành tiền: {thanhTien} VNĐ");
            lbThongTinSP.Items.Add(""); // Thêm một dòng trống để phân biệt các sản phẩm
            UpdateButtonState();
        }
        private void frmDonHang_Load(object sender, EventArgs e)
        {
            dgvDSDonHang.AutoGenerateColumns = false;

            loadDonHang();
            btnXoaOneSP.Enabled = false;
            btnXoaAllSP.Enabled = false;
            // Gọi hàm OnOffControl để thiết lập các điều khiển
            OnOffControl(false);
        }

        private void UpdateButtonState()
        {
            bool hasItems = lbThongTinSP.Items.Count > 0;
            btnXoaAllSP.Enabled = hasItems;
            btnXoaOneSP.Enabled = hasItems && lbThongTinSP.SelectedIndex != -1;
        }


        private void OnOffControl(bool status)
        {
            txtMaDH.Enabled = status;
            txtKieuDH.Enabled = status;
            txtGhiChu.Enabled = status;
            dtpNgayGiao.Enabled = status;
            btnXemChiTietDH.Enabled = status;
            btnLuu.Enabled = status;
            btnSua.Enabled = status;
            btnChonSanPham.Enabled = status;
            btnXoa.Enabled = status;
        }
        private void ResetForm()
        {
            txtMaDH.Clear();
            txtKieuDH.Clear();
            txtGhiChu.Clear();
            dtpNgayDat.Value = DateTime.Now;
            dtpNgayGiao.Value = DateTime.Now;
            lbThongTinSP.Items.Clear();
        }

        private void loadDonHang()
        {
            dgvDSDonHang.DataSource = dhDAO.GetList();
            txtTongDH.Text = dhDAO.getCount().ToString();
        }

        private void dgvDSDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vtChon = e.RowIndex;
            if (vtChon >= 0 && vtChon < dgvDSDonHang.Rows.Count)
            {
                btnXoa.Enabled = true;
                btnSua.Enabled = true;

                txtMaDH.Text = dgvDSDonHang.Rows[vtChon].Cells["MaDH"].Value.ToString();
                txtKieuDH.Text = dgvDSDonHang.Rows[vtChon].Cells["KieuDH"].Value.ToString();
                txtGhiChu.Text = dgvDSDonHang.Rows[vtChon].Cells["GhiChu"].Value.ToString();
                if (DateTime.TryParse(dgvDSDonHang.Rows[vtChon].Cells["NgayDat"].Value.ToString(), out DateTime ngayDat))
                {
                    dtpNgayDat.Value = ngayDat;
                }
                else
                {
                    dtpNgayDat.Value = DateTime.Now;
                }

                if (DateTime.TryParse(dgvDSDonHang.Rows[vtChon].Cells["NgayGiao"].Value.ToString(), out DateTime ngayGiao))
                {
                    dtpNgayGiao.Value = ngayGiao;
                }
                else
                {
                    dtpNgayGiao.Value = DateTime.Now;
                }
            }
            btnXemChiTietDH.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TabPage tbDonHang = frmMain.tabControl.TabPages["tbDonHang"];

            // Nếu tab tồn tại, thực hiện xóa
            if (tbDonHang != null)
            {
                frmMain.tabControl.TabPages.Remove(tbDonHang);
            }
            else
            {
                MessageBox.Show("Tab không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void OnOffControlAdd(bool status)
        {
            txtMaDH.Enabled = status;
            txtKieuDH.Enabled = status;
            txtGhiChu.Enabled = status;
            dtpNgayGiao.Enabled = status;
            btnLuu.Enabled = status;
            btnChonSanPham.Enabled = status;
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
            txtMaDH.Enabled = false;
            btnChonSanPham.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị MaSV từ TextBox (kiểu string)
                string maDH = txtMaDH.Text.Trim();

                // Kiểm tra xem maSV có rỗng hay không
                if (string.IsNullOrEmpty(maDH))
                {
                    MessageBox.Show("Mã sản phẩm không hợp lệ!", "Thông báo");
                    return;
                }

                // Gọi phương thức delete để xóa sinh viên
                string result = dhDAO.delete(maDH);
                loadDonHang();  // Tải lại danh sách sinh viên sau khi xóa
                MessageBox.Show(result, "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime ngayDatLoc = dtpNgayDat.Value;

            var filteredData = dhDAO.GetList()
                                          .Where(dh => dh.NgayDat.Date == ngayDatLoc.Date)
                                          .ToList();
            dgvDSDonHang.DataSource = filteredData;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra chế độ Add hay Edit
                if (AddOrEdit == "Add")
                {
                    // Thêm đơn hàng
                    DonHang donHang = new DonHang()
                    {
                        MaDH = txtMaDH.Text.Trim(),
                        KieuDH = txtKieuDH.Text.Trim(),
                        GhiChu = txtGhiChu.Text.Trim(),
                        NgayDat = dtpNgayDat.Value,
                        NgayGiao = dtpNgayGiao.Value,
                        MaTV = 1 // Giả sử mã thành viên tạm thời là 1
                    };

                    // Thêm đơn hàng vào cơ sở dữ liệu
                    string result = dhDAO.add(donHang); // Giả sử có phương thức add để thêm đơn hàng
                    if (result != "Thêm đơn hàng thành công")
                    {
                        MessageBox.Show(result, "Thông báo");
                        return;
                    }

                    // Sau khi thêm đơn hàng, thêm DonHangChiTiet cho từng sản phẩm
                    foreach (var item in lbThongTinSP.Items)
                    {
                        // Chỉ xử lý các dòng bắt đầu bằng "Mã sản phẩm"
                        if (item.ToString().StartsWith("Mã sản phẩm"))
                        {
                            try
                            {
                                // Lấy thông tin chi tiết sản phẩm từ ListBox
                                string maSP = item.ToString().Split(':')[1].Trim();
                                string tenSP = lbThongTinSP.Items[lbThongTinSP.Items.IndexOf(item) + 1].ToString().Split(':')[1].Trim();
                                string donViTinh = lbThongTinSP.Items[lbThongTinSP.Items.IndexOf(item) + 2].ToString().Split(':')[1].Trim(); // Lấy Đơn vị tính
                                decimal donGia = Convert.ToDecimal(lbThongTinSP.Items[lbThongTinSP.Items.IndexOf(item) + 3].ToString().Split(':')[1].Trim().Replace(" VNĐ", ""));
                                int soLuong = Convert.ToInt32(lbThongTinSP.Items[lbThongTinSP.Items.IndexOf(item) + 4].ToString().Split(':')[1].Trim());
                                decimal thanhTien = donGia * soLuong;

                                DonHangChiTiet chiTiet = new DonHangChiTiet()
                                {
                                    MaDH = donHang.MaDH,
                                    MaSP = maSP,
                                    DonVT = donViTinh,
                                    DonGia = donGia,
                                    SoLuong = soLuong,
                                    ThanhTien = thanhTien 
                                };

                                string resultCT = dhctDAO.AddDonHangChiTiet(chiTiet);
                                if (resultCT != "Thêm chi tiết đơn hàng thành công!")
                                {
                                    MessageBox.Show(resultCT, "Thông báo");
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Lỗi khi thêm chi tiết đơn hàng: {ex.Message}", "Thông báo");
                            }
                        }
                    }

                    // Tải lại đơn hàng và reset form sau khi thêm thành công
                    loadDonHang();
                    ResetForm();
                    OnOffControl(false);
                    MessageBox.Show("Thêm đơn hàng và chi tiết thành công!", "Thông báo");
                }
                else if (AddOrEdit == "Edit")
                {
                    // Sửa đơn hàng
                    DonHang donHang = new DonHang()
                    {
                        MaDH = txtMaDH.Text.Trim(),
                        KieuDH = txtKieuDH.Text.Trim(),
                        GhiChu = txtGhiChu.Text.Trim(),
                        NgayDat = dtpNgayDat.Value,
                        NgayGiao = dtpNgayGiao.Value,
                        MaTV = 1 // Giả sử mã thành viên tạm thời là 1
                    };

                    // Cập nhật thông tin đơn hàng
                    string result = dhDAO.Update(donHang); // Giả sử có phương thức Update để sửa đơn hàng
                    if (result == "Cập nhật đơn hàng thành công")
                    {
                        loadDonHang();
                        OnOffControl(false);
                        MessageBox.Show("Cập nhật đơn hàng thành công!", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show(result, "Thông báo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        private void btnXemChiTietDH_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã đơn hàng từ TextBox (txtMaDH)
                string maDH = txtMaDH.Text.Trim();

                if (string.IsNullOrEmpty(maDH))
                {
                    MessageBox.Show("Vui lòng chọn một đơn hàng để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy chi tiết đơn hàng dựa trên mã đơn hàng (MaDH)
                var chiTietDonHangs = dhctDAO.GetDonHangChiTietByMaDH(maDH); // Giả sử bạn có phương thức này trong DonHangChiTietDAO

                if (chiTietDonHangs == null || chiTietDonHangs.Count == 0)
                {
                    MessageBox.Show("Không có chi tiết đơn hàng cho mã đơn hàng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mở form frmChiTietDonHang và truyền dữ liệu
                frmChiTietDonHang frm = new frmChiTietDonHang();
                frm.LoadChiTietDonHang(chiTietDonHangs); // Giả sử LoadChiTietDonHang là phương thức trong frmChiTietDonHang
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở chi tiết đơn hàng: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            AddOrEdit = "";
            OnOffControl(false);
            ResetForm();
            loadDonHang();
        }

        private void ExportToExcel()
        {
            try
            {
                // Create Excel Application
                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create new Workbook
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets[1];

                // Add headers
                xlWorksheet.Cells[1, 1] = "Mã ĐH";
                xlWorksheet.Cells[1, 2] = "Kiểu ĐH";
                xlWorksheet.Cells[1, 3] = "Ngày Đặt";
                xlWorksheet.Cells[1, 4] = "Ngày Giao";
                xlWorksheet.Cells[1, 5] = "Ghi Chú";

                // Format header row
                Excel.Range headerRange = xlWorksheet.Range[xlWorksheet.Cells[1, 1], xlWorksheet.Cells[1, 5]];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = Excel.XlRgbColor.rgbLightGray;
                headerRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                // Export data from DataGridView
                for (int i = 0; i < dgvDSDonHang.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvDSDonHang.Columns.Count; j++)
                    {
                        if (dgvDSDonHang.Rows[i].Cells[j].Value != null)
                        {
                            if (j == 2 || j == 3) // Date columns
                            {
                                if (DateTime.TryParse(dgvDSDonHang.Rows[i].Cells[j].Value.ToString(), out DateTime date))
                                {
                                    xlWorksheet.Cells[i + 2, j + 1] = date.ToString("dd/MM/yyyy");
                                }
                            }
                            else
                            {
                                xlWorksheet.Cells[i + 2, j + 1] = dgvDSDonHang.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                }

                // Auto-fit columns
                xlWorksheet.Columns.AutoFit();

                // Save file
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;
                saveDialog.FileName = "DanhSachDonHang_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    xlWorkbook.SaveAs(saveDialog.FileName);
                    xlWorkbook.Close();
                    xlApp.Quit();

                    // Release COM objects
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorksheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvDSDonHang.Rows.Count > 0)
            {
                ExportToExcel();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaOneSP_Click(object sender, EventArgs e)
        {
            if (lbThongTinSP.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = lbThongTinSP.SelectedIndex;
            while (selectedIndex >= 0 && !lbThongTinSP.Items[selectedIndex].ToString().StartsWith("Mã sản phẩm: "))
            {
                selectedIndex--;
            }

            if (selectedIndex >= 0)
            {
                while (selectedIndex < lbThongTinSP.Items.Count && lbThongTinSP.Items[selectedIndex].ToString() != "")
                {
                    lbThongTinSP.Items.RemoveAt(selectedIndex);
                }

                if (selectedIndex < lbThongTinSP.Items.Count && lbThongTinSP.Items[selectedIndex].ToString() == "")
                {
                    lbThongTinSP.Items.RemoveAt(selectedIndex);
                }
            }

            UpdateButtonState(); // Cập nhật trạng thái nút sau khi xóa
        }

        private void btnXoaAllSP_Click(object sender, EventArgs e)
        {
            if (lbThongTinSP.Items.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả sản phẩm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                lbThongTinSP.Items.Clear();
            }

            UpdateButtonState(); // Cập nhật trạng thái nút
        }

        private void lbThongTinSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }
    }
}
