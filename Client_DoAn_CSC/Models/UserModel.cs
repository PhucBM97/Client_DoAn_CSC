using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Models
{
    public class UserModel
    {
        public class UserBase
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Họ tên phải khác rỗng")]
            [Display(Name = "Họ tên")]
            public string Ten { get; set; }
            [Required(ErrorMessage = "Họ tên phải khác rỗng")]
            [Display(Name = "Họ tên")]
            public string TenLot { get; set; }
            [Required(ErrorMessage = "Điện thoại phải khác rỗng")]
            [Display(Name = "Điện thoại")]
            public string SoDienThoai { get; set; }
            [Required(ErrorMessage = "Email phải khác rỗng")]
            [Display(Name = "Email")]
            [DataType(DataType.EmailAddress)]
            [EmailAddress(ErrorMessage = " Email không đúng định dạng")]
            public string Email { get; set; }
            [Required(ErrorMessage = " Mật khẩu phải khác rỗng")]
            [Display(Name = "Mật khẩu")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public DateTime NgayTao { get; set; }
            [Display(Name = "Thông Tin")]
            public string ThongTin { get; set; }
            [Required(ErrorMessage = "Điạ chỉ  phải khác rỗng")]
            [Display(Name = "Đia chỉ")]
            public string Diachi { get; set; }
            public string ThanhPho { get; set; }
            public bool KichHoat { get; set; }
            [Display(Name = "Quyền hạn")]
            public string QuyenHan { get; set; }
            public int DoanhThu { get; set; }

        }
        public class Input
        {
            public class ThongTinThanhVienMoi : UserBase { }
            public class ThongTinThanhVien
            {
                public int Id { get; set; }
            }
            public class ThongTinThayDoiMatKhau
            {
                public int Id { get; set; }
                public string UserName { get; set; }
                public string Matkhaucu { get; set; }
                public string Matkhaumoi { get; set; }
            }
            public class ThongTinDangNhap
            {
                public string TenDangNhap { get; set; }
                public string Matkhau { get; set; }

            }
            public class KichHoatTaiKhoan
            {
                public string Email { get; set; }
            }
            public class DanhSachNhanVien
            {
                public bool QuanTri { get; set; }
            }
        }
        public class Output
        {
            public class ThongTinThanhVien :UserBase
            {
                public string AccesToken { get; set; }
                public string ThongBao { get; set; }
            }
        }

    }
}
