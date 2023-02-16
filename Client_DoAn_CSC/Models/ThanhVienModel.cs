using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Models
{
    public class ThanhVienModel
    {
        public class ThanhVienBase
        {

            public int Idkhachhang { get; set; }
            [Required(ErrorMessage = "Họ tên phải khác rỗng")]
            [Display(Name = "Họ tên")]
            public string HoTenKh { get; set; }
            [Required(ErrorMessage = "Email phải khác rỗng")]
            [Display(Name = "Email")]
            [DataType(DataType.EmailAddress)]
            [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Điện thoại phải khác rỗng")]
            [Display(Name = "Điện thoại")]
            public string Sdt { get; set; }
            [Required(ErrorMessage = "Đia chỉ phải khác rỗng")]
            [Display(Name = "Địa chỉ")]
            public string DiaChi { get; set; }
            [Required(ErrorMessage = "Mật khẩu phải khác rỗng")]
            [Display(Name = "Mật khẩu")]
            public string Password { get; set; }
            [Display(Name = "Thành Phố")]
            public string ThanhPho { get; set; }

            public string ThongTin { get; set; }

            public string DsIddonhang { get; set; }

            public bool Kichhoat { get; set; }
            [Display(Name = "Ngày sinh")]
            [DataType(DataType.Date)]
            public DateTime Ngaysinh { get; set; }
            [Display(Name = "Ngày tạo")]
            [DataType(DataType.Date)]
            public DateTime Ngaytao { get; set; }
        }
        public class Input
        {
            public class DangNhap
            {
                public string Email { get; set; }
                public string MatKhau { get; set; }
            }
            public class DangKyThanhVien : ThanhVienBase { }

            public class ThongTinTHanhVien
            {
                public int Id { get; set; }
            }

            public class ThayDoiMatKhau
            {
                public int Id { get; set; }
                public string Email { get; set; }
                public string MatKhauMoi { get; set; }
                public string MatKhauCu { get; set; }
            }
            public class KichHoatTaiKhoan
            {
                public string Email { get; set; }
            }
        }
        public class Output
        {
            public class ThongTinThanhVien : ThanhVienBase
            {
                [Required(ErrorMessage = "Xác nhận mật khẩu phải khác rỗng")]
                [Display(Name = "Xác nhận mật khẩu")]
                [Compare("MatKhau" , ErrorMessage = "Xác nhận mật khẩu lại mật khẩu không đúng")]
                [DataType(DataType.Password)]
                public string XacNhanMatKhau { get; set; }
            }
            public class DangNhap : ThanhVienBase
            {
                public string AccessToken { get; set; }
                public string ThongBao { get; set; }
            }
        }
    }
}
