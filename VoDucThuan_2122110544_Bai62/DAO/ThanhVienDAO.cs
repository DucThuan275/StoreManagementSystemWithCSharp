using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Buoi06_02.models;

namespace Buoi06_02.DAO
{
    internal class ThanhVienDAO
    {
        private readonly QLBHDbContext _context;

        public ThanhVienDAO()
        {
            _context = new QLBHDbContext();
        }
        public string getPassword(string tenDangNhap)
        {
            return db.ThanhViens
                     .Where(tv => tv.TenDangNhap == tenDangNhap)
                     .Select(tv => tv.MatKhau)
                     .FirstOrDefault();
        }
        public ThanhVien getRow(string tenDangNhap)
        {
            return _context.ThanhViens.SingleOrDefault(tv => tv.TenDangNhap == tenDangNhap);
        }
        public ThanhVien getRowMatv(int matv)
        {
            return db.ThanhViens.FirstOrDefault(tv => tv.MaTV == matv);
        }


        QLBHDbContext db = new QLBHDbContext();
            public List<ThanhVien> getList()
            {
                List<ThanhVien> list = db.ThanhViens.ToList();
                return list;
            }
        public int getCount()
        {
            return db.ThanhViens.Count();
        }
        public string insert(ThanhVien tv)
        {
            try
            {
                db.ThanhViens.Add(tv);
                db.SaveChanges();
                return "Thêm thành công!";
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm: " + ex.Message;
            }
        }

        public string update(ThanhVien tv)
        {
            try
            {
                var existingThanhVien = db.ThanhViens.Find(tv.MaTV);
                if (existingThanhVien != null)
                {
                    // Log before updating
                    Console.WriteLine($"Updating password for {tv.TenDangNhap}");

                    existingThanhVien.MatKhau = tv.MatKhau; // Update the password
                    db.Entry(existingThanhVien).State = EntityState.Modified;
                    int result = db.SaveChanges();

                    // Log the result
                    if (result > 0)
                    {
                        return "Cập nhật thành công!";
                    }
                    else
                    {
                        return "Không có thay đổi nào.";
                    }
                }
                else
                {
                    return "Không tìm thấy người dùng.";
                }
            }
            catch (Exception ex)
            {
                return "Lỗi khi cập nhật: " + ex.Message;
            }
        }


        public string delete(int matv)
        {
            try
            {
                ThanhVien tv = db.ThanhViens.FirstOrDefault(t => t.MaTV == matv);

                if (tv != null)
                {
                    db.ThanhViens.Remove(tv);
                    db.SaveChanges();
                    return "Xóa thành công!";
                }
                else
                {
                    return "Không tìm thấy thành viên với mã " + matv;
                }
            }
            catch (Exception ex)
            {
                return "Lỗi khi xóa: " + ex.Message;
            }
        }
    }
}
