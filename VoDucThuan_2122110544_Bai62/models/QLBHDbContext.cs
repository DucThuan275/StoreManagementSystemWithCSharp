using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Buoi06_02.models
{
    public partial class QLBHDbContext : DbContext
    {
        public QLBHDbContext()
            : base("name=ChuoiKN")
        {
        }

        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        public virtual DbSet<LoaiSP> LoaiSPs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<ThanhVien> ThanhViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.DonHangChiTiets)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHangChiTiet>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHangChiTiet>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LoaiSP>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.LoaiSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaMua)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaBan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.DonHangChiTiets)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThanhVien>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.ThanhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThanhVien>()
                .HasMany(e => e.LoaiSPs)
                .WithRequired(e => e.ThanhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThanhVien>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.ThanhVien)
                .WillCascadeOnDelete(false);
        }
    }
}
