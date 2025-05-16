using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Buoi06_02.models;

namespace Buoi06_02.DAO
{
    internal class DonHangChiTietDAO
    {
        private QLBHDbContext context; // Đảm bảo MyDbContext là DbContext của bạn

        public DonHangChiTietDAO()
        {
            context = new QLBHDbContext();  // Khởi tạo đối tượng DbContext
        }

        // Thêm mới chi tiết đơn hàng
        public string AddDonHangChiTiet(DonHangChiTiet donHangChiTiet)
        {
            try
            {
                // Kiểm tra dữ liệu chi tiết đơn hàng trước khi thêm vào cơ sở dữ liệu
                if (string.IsNullOrEmpty(donHangChiTiet.MaSP) || donHangChiTiet.DonGia <= 0 || donHangChiTiet.SoLuong <= 0)
                {
                    return "Thông tin chi tiết đơn hàng không hợp lệ. Mã sản phẩm, đơn giá và số lượng phải hợp lệ.";
                }

                // Thêm chi tiết vào bảng DonHangChiTiet
                context.DonHangChiTiets.Add(donHangChiTiet);
                context.SaveChanges();

                return "Thêm chi tiết đơn hàng thành công!";
            }
            catch (Exception ex)
            {
                // Ghi log lỗi và trả về thông báo lỗi
                Console.WriteLine($"Lỗi khi thêm chi tiết đơn hàng: {ex.Message}");
                return $"Lỗi khi thêm chi tiết đơn hàng: {ex.Message}";
            }
        }



        // Lấy danh sách chi tiết đơn hàng theo MaDH
        public List<DonHangChiTiet> GetDonHangChiTietByMaDH(string maDH)
        {
            try
            {
                var donHangChiTietList = context.DonHangChiTiets
                    .Where(d => d.MaDH == maDH)
                    .Include(d => d.SanPham) // Nạp thông tin sản phẩm
                    .ToList();

                return donHangChiTietList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách chi tiết đơn hàng: {ex.Message}");
                return null;
            }
        }

    }
}
