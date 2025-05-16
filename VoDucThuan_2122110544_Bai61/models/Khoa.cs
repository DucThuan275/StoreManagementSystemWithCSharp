namespace Buoi06_01.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Khoa")]
    public partial class Khoa
    {
        public Khoa()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        [Key]
        public int MaKhoa { get; set; }

        public int MaTV { get; set; }

        [Required]
        [StringLength(200)]
        public string TenKhoa { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
