using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buoi06_01.models;

namespace Buoi06_01.DAO
{
    internal class KhoaDAO
    {
        private readonly QLSVDbContext db = new QLSVDbContext();

        public Khoa GetRowByMaKhoa(int maKhoa)
        {
            return db.Khoas.FirstOrDefault(k => k.MaKhoa == maKhoa);
        }

        public List<object> getList()
        {
            return db.Khoas.Select(k => new
            {
                k.MaKhoa,
                k.TenKhoa,
                k.Email,
                k.GhiChu
            }).ToList<object>();
        }


        public int getCount()
        {
            return db.Khoas.Count();
        }

        public string insert(Khoa khoa)
        {
            try
            {
                db.Khoas.Add(khoa);
                db.SaveChanges();
                return "Thêm thành công!";
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm: " + ex.Message;
            }
        }

        public string update(Khoa khoa)
        {
            try
            {
                var existingKhoa = db.Khoas.Find(khoa.MaKhoa);
                if (existingKhoa != null)
                {
                    // Log before updating
                    Console.WriteLine($"Updating Khoa: {khoa.TenKhoa}");

                    existingKhoa.TenKhoa = khoa.TenKhoa;
                    existingKhoa.Email = khoa.Email;
                    existingKhoa.GhiChu = khoa.GhiChu;
                    db.Entry(existingKhoa).State = EntityState.Modified;
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
                    return "Không tìm thấy khoa.";
                }
            }
            catch (Exception ex)
            {
                return "Lỗi khi cập nhật: " + ex.Message;
            }
        }

        public string delete(int maKhoa)
        {
            try
            {
                // Tìm khoa dựa trên MaKhoa kiểu int
                var khoa = db.Khoas.SingleOrDefault(k => k.MaKhoa == maKhoa);

                if (khoa == null)
                {
                    return $"Không tìm thấy khoa với mã '{maKhoa}'.";
                }

                // Xóa khoa khỏi cơ sở dữ liệu
                db.Khoas.Remove(khoa);
                db.SaveChanges();

                return "Xóa thành công!";
            }
            catch (Exception ex)
            {
                return $"Đã xảy ra lỗi khi xóa: {ex.Message}";
            }
        }


    }
}
