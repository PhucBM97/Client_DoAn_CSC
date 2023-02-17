using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Models
{
    public class HinhModel
    {
        public class HinhBase
        {

            public int HinhId { get; set; }
            [Display(Name = "Tên Banner")]
            [Required(ErrorMessage="Tên phải khác rỗng")]
            public string Thumbnails { get; set; }
            [Display(Name ="Đường dẫn file hình")]
            public string Carousel { get; set; }
            [Display(Name ="Kích hoạt")]
            public bool KichHoat { get; set; }
            
        }
        public class Input
        {
            public class ThongTinHinh: HinhBase { }
            public class DocDanhSachHinh
            {
                public bool QuanTri { get; set; }
            }
            public class DocThongTinHinh
            {
                public int Id { get; set; }
            }
            public class XoaHinh
            {
                public int Id { get; set; }
            }

        }
        public class Output
        {
            public class ThongTinHinh : HinhBase { }
        }
    }
}
