using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buoi06_02.models;

namespace Buoi06_02.DAO
{
    internal class DonHangDAO
    {
        private QLBHDbContext db = new QLBHDbContext();

        // Lấy danh sách đơn hàng
        public List<DonHang> GetList()
        {
            return db.DonHangs.ToList();
        }
        public int getCount()
        {
            return db.DonHangs.Count();
        }
        // Thêm một đơn hàng mới
        public string add(DonHang donHang)
        {
            try
            {
                // Kiểm tra dữ liệu trước khi thêm vào cơ sở dữ liệu
                if (string.IsNullOrEmpty(donHang.MaDH) || string.IsNullOrEmpty(donHang.KieuDH))
                {
                    return "Mã đơn hàng hoặc kiểu đơn hàng không được bỏ trống";
                }

                // Thêm đơn hàng vào cơ sở dữ liệu
                db.DonHangs.Add(donHang);
                db.SaveChanges();

                return "Thêm đơn hàng thành công"; // Trả về thông báo thành công
            }
            catch (Exception ex)
            {
                // Ghi log lỗi và trả về thông báo lỗi
                Console.WriteLine($"Lỗi khi thêm đơn hàng: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                    MessageBox.Show($"Inner Exception: {ex.InnerException.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return "Lỗi khi thêm đơn hàng: " + ex.Message;
            }
        }


        // Phương thức cập nhật đơn hàng
        public string Update(DonHang donHang)
        {
            try
            {
                // Tìm đơn hàng trong cơ sở dữ liệu bằng MaDH
                var existingDonHang = db.DonHangs.Find(donHang.MaDH);

                if (existingDonHang != null)
                {
                    // Cập nhật các trường dữ liệu
                    existingDonHang.MaTV = donHang.MaTV;
                    existingDonHang.NgayDat = donHang.NgayDat;
                    existingDonHang.NgayGiao = donHang.NgayGiao;
                    existingDonHang.KieuDH = donHang.KieuDH;
                    existingDonHang.GhiChu = donHang.GhiChu;

                    // Lưu lại thay đổi
                    db.SaveChanges();
                    return "Cập nhật đơn hàng thành công"; // Trả về thông báo thành công
                }

                // Trường hợp không tìm thấy đơn hàng
                return "Đơn hàng không tồn tại";
            }
            catch (Exception ex)
            {
                // Ghi log lỗi và trả về thông báo lỗi
                Console.WriteLine($"Lỗi khi cập nhật đơn hàng: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }

                return "Lỗi khi cập nhật đơn hàng: " + ex.Message;
            }
        }

        // Xóa một đơn hàng
        public string delete(string maDH)
        {
            try
            {
                // Kiểm tra xem có tồn tại các chi tiết đơn hàng liên quan đến DonHang này không
                var donHangChiTietExists = db.DonHangChiTiets.Any(dht => dht.MaDH == maDH);

                if (donHangChiTietExists)
                {
                    return "Không thể xóa đơn hàng vì có chi tiết đơn hàng liên quan.";
                }

                // Tìm đơn hàng với MaDH
                DonHang donHang = db.DonHangs.FirstOrDefault(dh => dh.MaDH == maDH);

                if (donHang != null)
                {
                    db.DonHangs.Remove(donHang);  // Xóa đơn hàng khỏi DbContext
                    db.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu
                    return "Xóa đơn hàng thành công!";
                }
                else
                {
                    return "Không tìm thấy đơn hàng với mã " + maDH;
                }
            }
            catch (Exception ex)
            {
                return "Lỗi khi xóa: " + ex.Message;
            }
        }


        // Lấy đơn hàng theo mã đơn hàng
        public DonHang GetById(string maDH)
        {
            return db.DonHangs.Find(maDH);
        }

        // Lấy danh sách đơn hàng theo mã thành viên (ví dụ: lọc đơn hàng theo khách hàng)
        public List<DonHang> GetByThanhVien(int maTV)
        {
            return db.DonHangs.Where(dh => dh.MaTV == maTV).ToList();
        }

        // Đếm tổng số đơn hàng
        public int GetCount()
        {
            return db.DonHangs.Count();
        }
    }
}
