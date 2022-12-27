namespace HeThongThongTin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhatKyCongViec")]
    public partial class NhatKyCongViec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhatKyCongViec()
        {
            NhanXetNhatKies = new HashSet<NhanXetNhatKy>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNK { get; set; }

        public int? HoanThanh { get; set; }

        public string TrangThai { get; set; }

        public virtual KeHoachCongTac KeHoachCongTac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanXetNhatKy> NhanXetNhatKies { get; set; }
    }
}
