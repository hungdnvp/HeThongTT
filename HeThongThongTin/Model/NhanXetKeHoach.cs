namespace HeThongThongTin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanXetKeHoach")]
    public partial class NhanXetKeHoach
    {
        [Key]
        public int MaNXKH { get; set; }

        public int? MaKH { get; set; }

        public int? MaCB { get; set; }

        public string NhanXet { get; set; }

        public virtual CanBo CanBo { get; set; }

        public virtual KeHoachCongTac KeHoachCongTac { get; set; }
    }
}
