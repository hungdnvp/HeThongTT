namespace HeThongThongTin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KeHoachCongTac")]
    public partial class KeHoachCongTac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KeHoachCongTac()
        {
            NhanXetKeHoaches = new HashSet<NhanXetKeHoach>();
            PhanCongs = new HashSet<PhanCong>();
        }

        [Key]
        public int MaKH { get; set; }

        public string NoiDungKH { get; set; }

        [StringLength(200)]
        public string DiaDiem { get; set; }

        public int? MaTrucBan { get; set; }

        public int? MaChiHuy { get; set; }

        [StringLength(50)]
        public string PhienHieuDonVi { get; set; }

        [StringLength(200)]
        public string TPThucHien { get; set; }

        public int? PheDuyet { get; set; }

        public int? HoanThanh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGian { get; set; }

        [StringLength(200)]
        public string TrangThai { get; set; }

        public virtual DonVi DonVi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanXetKeHoach> NhanXetKeHoaches { get; set; }

        public virtual NhatKyCongViec NhatKyCongViec { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanCong> PhanCongs { get; set; }
    }
}
