using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Buoi06_02.models;

namespace Buoi06_02.DAO
{
    internal class SanPhamDAO
    {
        private QLBHDbContext db;

        public SanPhamDAO()
        {
            db = new QLBHDbContext(); // Khởi tạo DbContext
        }

        // Lấy danh sách sản phẩm
        public List<SanPham> getList()
        {
            return db.SanPhams.ToList();
        }
        public List<dynamic> GetListWithTenLoai()
        {
            // Lấy danh sách sản phẩm kèm theo tên loại sản phẩm
            var result = db.SanPhams
                           .Include(sp => sp.LoaiSP) // Đảm bảo rằng thông tin từ LoaiSP được tải cùng
                           .Select(sp => new
                           {
                               MaSP = sp.MaSP,
                               TenSP = sp.TenSP,
                               DonVT = sp.DonVT,
                               GiaMua = sp.GiaMua,
                               GiaBan = sp.GiaBan,
                               MaLoai = sp.MaLoai,
                               TenLoai = sp.LoaiSP.TenLoai // Lấy tên loại từ bảng LoaiSP
                           })
                           .ToList<dynamic>(); // Ép kiểu thành List<dynamic>

            return result;
        }

        public int getCount()
        {
            return db.SanPhams.Count();
        }
        public SanPham getById(string maSP)
        {
            try
            {
                return db.SanPhams.FirstOrDefault(sp => sp.MaSP == maSP);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy sản phẩm theo mã: {ex.Message}");
                return null;
            }
        }

        // Thêm sản phẩm mới
        public bool insert(SanPham sp)
        {
            try
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm sản phẩm: {ex.Message}");
                return false;
            }
        }

        // Cập nhật sản phẩm
        public bool update(SanPham sp)
        {
            try
            {
                var existingSp = db.SanPhams.Find(sp.MaSP);
                if (existingSp != null)
                {
                    existingSp.TenSP = sp.TenSP;
                    existingSp.DonVT = sp.DonVT;
                    existingSp.GiaMua = sp.GiaMua;
                    existingSp.GiaBan = sp.GiaBan;
                    existingSp.MaLoai = sp.MaLoai;
                    existingSp.MaTV = sp.MaTV;

                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật sản phẩm: {ex.Message}");
                return false;
            }
        }

        // Xóa sản phẩm
        public string delete(string maSP)
        {
            try
            {
                // Tìm sinh viên có MaSV là kiểu string
                SanPham sanpham = db.SanPhams.FirstOrDefault(sv => sv.MaSP == maSP);

                if (sanpham != null)
                {
                    db.SanPhams.Remove(sanpham);  // Xóa sinh viên khỏi DbContext
                    db.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu
                    return "Xóa thành công!";
                }
                else
                {
                    return "Không tìm thấy sản phẩm với mã " + maSP;
                }
            }
            catch (Exception ex)
            {
                return "Lỗi khi xóa: " + ex.Message;
            }
        }

        // Tìm sản phẩm theo mã
        public SanPham FindById(string maSP)
        {
            return db.SanPhams.Find(maSP);
        }
        public SanPham FindByMaLoai(string maLoai)
        {
            return db.SanPhams.Find(maLoai);
        }
    }
}
