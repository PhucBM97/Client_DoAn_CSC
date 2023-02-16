using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Models
{
    public class KhuyenMaiModel
    {
        public class KhuyenMaiBase
        {
            public int Id { get; set; }
            [Display(Name="Loại hàng")]
            public int LoaiHangId { get; set; }
            [Display(Name ="Ngày băt đầu")]
            
            public DateTime NgayBatDau { get; set; }
            public DateTime NgayKetThuc { get; set; }
            [Display(Name ="Giảm giá")]
            public double PhanTramGiam { get; set; }
            [Display(Name ="Quà tặng")]
            [Required(ErrorMessage ="Ký tự khác rỗng")]
            
            public string QuaTangKem { get; set; }
            [Display(Name = "Voucher")]
            [Required(ErrorMessage = "Ký tự khác rỗng")]
            public string VoucherTangKem { get; set; }

        }
        public class Input
        {
            public class ThongTinKhuyenMai : KhuyenMaiBase { }
            public class DocThongTinKhuyenMai
            {
                public int Id { get; set; }
            }
            public class DanhSachKhuyenMaiDangCo
            {
                public DateTime Ngaydienra { get; set; }
            }

            public class DanhSachKhuyenMaiTheoLoaiHang
            {
                public int LoaihangId { get; set; }
            }

            public class XoaKhuyenMai
            {
                public int Id { get; set; }
            }
        }
        public class Output
        {
            public class ThongTinKhuyenMai : KhuyenMaiBase { }
            
            public class ThemKhuyenMai : KhuyenMaiBase
            {
                public string ThongBao { get; set; }
            }
            public class CapNhatKhuyenMai : KhuyenMaiBase
            {
                public string ThongBao { get; set; }
            }

            
        }
    }
}
