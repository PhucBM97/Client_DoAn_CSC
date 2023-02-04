using Client_DoAn_CSC.Common;
using Client_DoAn_CSC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Controllers
{
    public class ThanhVienController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangNhap(string username, string password, bool remember = false)
        {
            var input = new ThanhVienModel.Input.DangNhap
            {
                Email = username,
                MatKhau = password
            };
            var thanhvien = Utilities.SendDataRequest<ThanhVienModel.Output.DangNhap>(DataAPI.ThanhVien.DangNhap, input);
            return RedirectToAction("Index", "Home");
        }
        //
        public IActionResult DangKy()
        {
            ThanhVienModel.Output.ThongTinThanhVien thanhVien = new();
            return View(thanhVien);
        }
        [HttpPost]
        public IActionResult DangKy(ThanhVienModel.Output.ThongTinThanhVien thanhvien)
        {
            if(DateTime.Today.Year - thanhvien.NgaySinh.Year < 13)
            {
                ViewData["ThongBaoDangKy"] = "Dưới 13 tuổi không thể đăng ký";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var input = new ThanhVienModel.Input.DangKyThanhVien();
                    Utilities.PropertyCopier<ThanhVienModel.Output.ThongTinThanhVien, ThanhVienModel.Input.DangKyThanhVien>.Copy(thanhvien, input);

                    var tb = Utilities.SendDataRequest<ThongBaoModel>(DataAPI.ThanhVien.DangKy, input);

                    if (tb.Maso == 0)
                    {
                        thanhvien.Id = int.Parse(tb.Noidung);
                        TempData["EmailDangKy"] = thanhvien.Email;
                        var code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(thanhvien.Email));
                        //tạo link xác nhận
                        var callbackUrl = Url.ActionLink("ConfirmEmail", "ThanhVien",
                                                                new { area = "", code = code }, Request.Scheme);

                        // nd mail
                        var message = @"<div> Cám ơn bạn đã đăng ký thành viên <br>
                                        để hoàn tất đăng ký bạn vui lòng
                                        </div>";
                        Utilities.SendMail("Xác nhận đăng ký thành viên", message, thanhvien.Email);
                        return RedirectToAction("RegisterSucess", "ThanhVien");
                    }
                    else
                    {
                        ViewData["ThongBaoDangKy"] = tb.Noidung;
                    }
                }
            }
            return View(thanhvien);

        }
        [HttpPost]
        public IActionResult ConfirmPassword(string code)
        {
            var email = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var input = new ThanhVienModel.Input.KichHoatTaiKhoan
            {
                Email = email
            };
            var tb = Utilities.SendDataRequest<ThongBaoModel>(DataAPI.ThanhVien.KichHoatTaiKhoan, input);
            if (tb.Maso == 0 )
            {
                ViewData["ThongBaoKichHoat"] = "Thành công";
            }
            else
            {
                ViewData["ThongBaoKichHoat"] = "Thất bại";  
            }
            return View();
        }
        //
        public IActionResult DoiMatKhau()
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["ThongBaoLogin"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ThanhVienModel.Input.ThayDoiMatKhau model = new();
                return View(model);
            }
        }
        //[HttpPost]
        //public IActionResult DoiMatKhau()
        //{

        //}

    }
}
