namespace Buoi06_02.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSP")]
    public partial class LoaiSP
    {
        public LoaiSP()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        public int MaLoai { get; set; }

        public int MaTV { get; set; }

        [StringLength(255)]
        public string TenLoai { get; set; }

        [StringLength(255)]
        public string ChiTiet { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
