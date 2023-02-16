
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Client_DoAn_CSC.Common;
using Client_DoAn_CSC.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            LoginModel model = new();
            return View(model);
        }

        public IActionResult DangNhap(string username, string password, bool remember = false, string returnUrl = null)
        {
            if (username == null) username = "";
            if (password == null) password = "";

           
            var input = new UserModel.Input.ThongTinDangNhap { TenDangNhap = username, Matkhau = password };
            var nhanvien = Utilities.SendDataRequest<UserModel.Output.ThongTinThanhVien>(ConstantValues.User.DangNhap, input);
            HttpContext.Session.Remove("ThanhVien");
            if (nhanvien != null)
            {
                if (nhanvien.Id > 0)
                {
                    bool logined = LoginUser(nhanvien, remember).Result;
                    if (logined)
                        HttpContext.Session.Set<UserModel.Output.ThongTinThanhVien>("NhanVien", nhanvien);
                    if (!string.IsNullOrEmpty(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                    TempData["ThongBaoLogin"] = nhanvien.ThongBao;
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            var nhanvien = HttpContext.Session.Get<UserModel.Output.ThongTinThanhVien>("NhanVien");
            var input = new UserModel.Input.ThongTinDangNhap { TenDangNhap = nhanvien.Email, Matkhau = nhanvien.Password };
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();            
            Utilities.SendDataRequest<bool>(ConstantValues.User.DangXuat, input);
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
                
        public IActionResult ChangePassword()
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["ThongBaoLogin"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ChangePasswordModel model = new();
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult ChangePassword(string matkhaucu, string matkhaumoi)
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["ThongBaoLogin"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ChangePasswordModel model = new();
                var Email = User.Claims.FirstOrDefault(x => x.Type == "Email").Value;
                var id = User.Claims.FirstOrDefault(x => x.Type == "NHANVIENID").Value;

                var input = new UserModel.Input.ThongTinThayDoiMatKhau {
                    Id = int.Parse(id),
                    UserName = Email,
                    Matkhaucu = matkhaucu,
                    Matkhaumoi = matkhaumoi
                };
                var thong_bao = Utilities.SendDataRequest<ThongBaoModel>(ConstantValues.User.ThayDoiMK, input);
                if (thong_bao.Maso== 0)
                    ViewData["ThongBao"] = $"<span style='color: #0000ff;'>{thong_bao.Noidung}</span>";
                else
                    ViewData["ThongBao"] = $"<span style='color: #ff0000;'>{thong_bao.Noidung}</span>";
                return View(model);
            }

        }
                
        private async Task<bool> LoginUser(UserModel.Output.ThongTinThanhVien nhanvien, bool remember)
        {
            try
            {
                var userClaims = new List<Claim>() {
                    new Claim("NHANVIENID", nhanvien.Id.ToString()),
                    new Claim("USERNAME", nhanvien.Email),
                    new Claim("QUYENHAN", nhanvien.QuyenHan.ToUpper()),
                    new Claim("HOTEN", nhanvien.Ten+nhanvien.TenLot),
                    new Claim("SDT", nhanvien.SoDienThoai)
                };
                var claimsIdentity = new ClaimsIdentity(userClaims,
                                            CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(claimsIdentity);
                var properties = new AuthenticationProperties { IsPersistent = remember };
                await HttpContext.SignInAsync(principal, properties);

                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }
    }
}
