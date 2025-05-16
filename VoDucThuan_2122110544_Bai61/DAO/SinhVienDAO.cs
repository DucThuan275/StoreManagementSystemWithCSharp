using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buoi06_01.models;

namespace Buoi06_01.DAO
{
    internal class SinhVienDAO
    {
        private readonly QLSVDbContext db = new QLSVDbContext();

        public SinhVien GetRowByMaSV(string maSV)
        {
            return db.SinhViens.FirstOrDefault(sv => sv.MaSV == maSV);
        }

        public List<dynamic> getListWithTenKhoa()
        {
            var result = db.SinhViens
                            .Include(sv => sv.Khoa)  // Đảm bảo rằng dữ liệu từ Khoa được tải cùng
                            .Select(sv => new
                            {
                                MaSV = sv.MaSV,
                                HoTen = sv.HoTen,
                                DienThoai = sv.DienThoai,
                                Email = sv.Email,
                                DiemTB = sv.DiemTB,
                                MaKhoa = sv.MaKhoa,
                                TenKhoa = sv.Khoa.TenKhoa  // Lấy tên khoa từ bảng Khoa
                            })
                            .ToList<dynamic>();  // Ép kiểu thành List<dynamic>

            return result;
        }


        public int getCount()
        {
            return db.SinhViens.Count();
        }

        public string insert(SinhVien sinhVien)
        {
            try
            {
                // Kiểm tra sự tồn tại của sinh viên theo Mã Sinh Viên
                var existingSinhVien = db.SinhViens.FirstOrDefault(sv => sv.MaSV == sinhVien.MaSV);

                if (existingSinhVien != null)
                {
                    // Trả về thông báo nếu Mã Sinh Viên đã tồn tại
                    return "Mã sinh viên đã tồn tại!";
                }

                // Thêm sinh viên vào cơ sở dữ liệu
                db.SinhViens.Add(sinhVien);
                db.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu

                // Trả về thông báo thành công
                return "Thêm sinh viên thành công!";
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về thông báo chi tiết
                return "Lỗi khi thêm sinh viên: " + ex.Message;
            }
        }


        public string update(SinhVien sinhVien)
        {
            try
            {
                var existingSinhVien = db.SinhViens.Find(sinhVien.MaSV);
                if (existingSinhVien != null)
                {
                    // Log before updating
                    Console.WriteLine($"Updating SinhVien: {sinhVien.HoTen}");

                    existingSinhVien.HoTen = sinhVien.HoTen;
                    existingSinhVien.DienThoai = sinhVien.DienThoai;
                    existingSinhVien.Email = sinhVien.Email;
                    existingSinhVien.DiemTB = sinhVien.DiemTB;
                    existingSinhVien.MaKhoa = sinhVien.MaKhoa;

                    db.Entry(existingSinhVien).State = EntityState.Modified;
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
                    return "Không tìm thấy sinh viên.";
                }
            }
            catch (Exception ex)
            {
                return "Lỗi khi cập nhật: " + ex.Message;
            }
        }

        public string delete(string maSV)
        {
            try
            {
                // Tìm sinh viên có MaSV là kiểu string
                SinhVien sinhVien = db.SinhViens.FirstOrDefault(sv => sv.MaSV == maSV);

                if (sinhVien != null)
                {
                    db.SinhViens.Remove(sinhVien);  // Xóa sinh viên khỏi DbContext
                    db.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu
                    return "Xóa thành công!";
                }
                else
                {
                    return "Không tìm thấy sinh viên với mã " + maSV;
                }
            }
            catch (Exception ex)
            {
                return "Lỗi khi xóa: " + ex.Message;
            }
        }

    }
}
