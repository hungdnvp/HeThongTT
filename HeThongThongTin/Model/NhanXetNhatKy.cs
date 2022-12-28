namespace HeThongThongTin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanXetNhatKy")]
    public partial class NhanXetNhatKy
    {
        [Key]
        public int MaNXNK { get; set; }

        public int? MaNK { get; set; }

        public int? MaCB { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGian { get; set; }

        public string NhanXet { get; set; }

        public virtual CanBo CanBo { get; set; }

        public virtual NhatKyCongViec NhatKyCongViec { get; set; }
    }
}
