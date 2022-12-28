namespace HeThongThongTin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CanBo")]
    public partial class CanBo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CanBo()
        {
            KeHoachCongTacs = new HashSet<KeHoachCongTac>();
            NhanXetKeHoaches = new HashSet<NhanXetKeHoach>();
            NhanXetNhatKies = new HashSet<NhanXetNhatKy>();
        }

        [Key]
        public int MaCB { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string CapBac { get; set; }

        [StringLength(50)]
        public string ChucVu { get; set; }

        [StringLength(50)]
        public string PhienHieuDonVi { get; set; }

        public int? MaTK { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KeHoachCongTac> KeHoachCongTacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanXetKeHoach> NhanXetKeHoaches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanXetNhatKy> NhanXetNhatKies { get; set; }

        public virtual DonVi DonVi { get; set; }
    }
}
