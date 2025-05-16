using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buoi06_02.models;

namespace Buoi06_02.DAO
{
    internal class LoaiSanPhamDAO
    {
        private readonly QLBHDbContext _context; // Giả định bạn có DbContext tên là MyDbContext

        public LoaiSanPhamDAO()
        {
            _context = new QLBHDbContext(); // Khởi tạo DbContext
        }

        // Lấy danh sách tất cả các Loại Sản Phẩm
        public List<LoaiSP> getList()
        {
            return _context.LoaiSPs.ToList();
        }
        public int getCount()
        {
            return _context.LoaiSPs.Count();
        }
        // Lấy thông tin Loại Sản Phẩm theo mã
        public LoaiSP GetById(int id)
        {
            return _context.LoaiSPs.FirstOrDefault(x => x.MaLoai == id);
        }

        // Thêm mới Loại Sản Phẩm
        public bool insert(LoaiSP loaiSP)
        {
            try
            {
                _context.LoaiSPs.Add(loaiSP);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        // Cập nhật thông tin Loại Sản Phẩm
        public bool update(LoaiSP loaiSP)
        {
            try
            {
                var existingLoaiSP = GetById(loaiSP.MaLoai);
                if (existingLoaiSP != null)
                {
                    existingLoaiSP.TenLoai = loaiSP.TenLoai;
                    existingLoaiSP.ChiTiet = loaiSP.ChiTiet;
                    existingLoaiSP.MaTV = loaiSP.MaTV;

                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        // Xóa Loại Sản Phẩm
        public bool delete(int id)
        {
            try
            {
                var loaiSP = GetById(id);
                if (loaiSP != null)
                {
                    _context.LoaiSPs.Remove(loaiSP);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
