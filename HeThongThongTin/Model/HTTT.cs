using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HeThongThongTin
{
    public partial class HTTT : DbContext
    {
        public HTTT()
            : base("name=HTTT")
        {
        }

        public virtual DbSet<CanBo> CanBoes { get; set; }
        public virtual DbSet<CapDonVi> CapDonVis { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<KeHoachCongTac> KeHoachCongTacs { get; set; }
        public virtual DbSet<NhanXetKeHoach> NhanXetKeHoaches { get; set; }
        public virtual DbSet<NhanXetNhatKy> NhanXetNhatKies { get; set; }
        public virtual DbSet<NhatKyCongViec> NhatKyCongViecs { get; set; }
        public virtual DbSet<PhanCong> PhanCongs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CanBo>()
                .Property(e => e.PhienHieuDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<DonVi>()
                .Property(e => e.PhienHieuDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<HocVien>()
                .Property(e => e.PhienHieuDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<HocVien>()
                .HasMany(e => e.PhanCongs)
                .WithRequired(e => e.HocVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KeHoachCongTac>()
                .Property(e => e.PhienHieuDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<KeHoachCongTac>()
                .HasOptional(e => e.NhatKyCongViec)
                .WithRequired(e => e.KeHoachCongTac);

            modelBuilder.Entity<KeHoachCongTac>()
                .HasMany(e => e.PhanCongs)
                .WithRequired(e => e.KeHoachCongTac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);
        }
    }
}
