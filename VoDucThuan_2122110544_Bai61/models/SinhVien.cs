namespace Buoi06_01.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [Key]
        [StringLength(10)]
        public string MaSV { get; set; }

        public int MaTV { get; set; }

        [Required]
        [StringLength(200)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(12)]
        public string DienThoai { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        public double DiemTB { get; set; }

        public int MaKhoa { get; set; }
        public virtual Khoa Khoa { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}
