namespace HeThongThongTin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonVi")]
    public partial class DonVi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonVi()
        {
            HocViens = new HashSet<HocVien>();
            KeHoachCongTacs = new HashSet<KeHoachCongTac>();
        }

        [Key]
        [StringLength(50)]
        public string PhienHieuDonVi { get; set; }

        [StringLength(50)]
        public string TenDonVi { get; set; }

        public int? MaCap { get; set; }

        public virtual CapDonVi CapDonVi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocVien> HocViens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KeHoachCongTac> KeHoachCongTacs { get; set; }
    }
}
