namespace Buoi06_02.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHangChiTiet")]
    public partial class DonHangChiTiet
    {
        [Key]
        public int MaCTDH { get; set; }

        [Required]
        [StringLength(20)]
        public string MaDH { get; set; }

        [Required]
        [StringLength(20)]
        public string MaSP { get; set; }

        [Required]
        [StringLength(20)]
        public string DonVT { get; set; }

        public decimal DonGia { get; set; }

        public int SoLuong { get; set; }

        public decimal ThanhTien { get; set; }
        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
