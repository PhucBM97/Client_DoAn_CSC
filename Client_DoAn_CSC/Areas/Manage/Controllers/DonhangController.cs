using Client_DoAn_CSC.Common;
using Client_DoAn_CSC.DTO;
using Client_DoAn_CSC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DonhangController : Controller
    {

        public IActionResult Index()
        {
            var dsDonHang = Utilities.SendDataRequest<List<DonhangModel.Output.ThongTinDonHang>>(ConstantValues.Donhang.DSSPTH);

            return View();
        }
        public IActionResult ThemDonHang(DonhangModel.Input.ThongTinDonHang input)
        {
            DonhangModel.Output.ThongTinDonHang Donhang = new();
            var input_user = new Client_DoAn_CSC.Models.UserModel.Input.DanhSachNhanVien { QuanTri = true };
            var dsNV = Utilities.SendDataRequest<List<UserModel.Output.ThongTinThanhVien>>(ConstantValues.User.DSNV, input_user);
            if (input != null && !string.IsNullOrEmpty(input.Ten))
            {
                var tb = Utilities.SendDataRequest<ThongBaoModel>(ConstantValues.Donhang.ThemDH, input);
                if (tb.Maso> 0)
                {
                    ViewData["ThongBao"] = tb.Noidung;
                    Utilities.PropertyCopier<DonhangModel.Input.ThongTinDonHang, DonhangModel.Output.ThongTinDonHang>.Copy(input, Donhang);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            ViewData["DSNhanVien"] = dsNV;
            return View(Donhang);

        }
        public IActionResult CapNhatDonHang(int id)
        {
            if (id > 0)
            {
                var input = new DonhangModel.Input.DocThongTinDonHang{ Id = id };
                var donHang = Utilities.SendDataRequest<DonhangModel.Output.ThongTinDonHang>(ConstantValues.Donhang.TTDH, input);
                var input_nv = new UserModel.Input.DanhSachNhanVien { QuanTri = true };
                var dsNhanVien = Utilities.SendDataRequest<List<UserModel.Output.ThongTinThanhVien>>(ConstantValues.User.DSNV, input_nv);
                ViewData["DSNhanVien"] = dsNhanVien;
                if (donHang!= null && donHang.Id > 0)
                {
                    return View(donHang);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult CapNhatDonHang(DonhangModel.Input.ThongTinDonHang input)
        {
            DonhangModel.Output.ThongTinDonHang donHang = new();
            if (input == null || string.IsNullOrEmpty(input.Ten)) return RedirectToAction("Index");
            var tb = Utilities.SendDataRequest<ThongBaoModel>(ConstantValues.Donhang.CapnhatDH, input);
            if (tb.Maso> 0)
            {
                var input_nv = new UserModel.Input.DanhSachNhanVien { QuanTri = true };
                var dsNhanVien = Utilities.SendDataRequest<List<UserModel.Output.ThongTinThanhVien>>(ConstantValues.User.DSNV, input_nv);
                ViewData["DSNhanVien"] = dsNhanVien;
                ViewData["ThongBao"] = tb.Noidung;
                Utilities.PropertyCopier<DonhangModel.Input.ThongTinDonHang, DonhangModel.Output.ThongTinDonHang>.Copy(input, donHang);
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(donHang);
        }
        public IActionResult XoaDonHang(int id)
        {
            if (id > 0)
            {
                var input = new DonhangModel.Input.XoaDonHang{ Id = id };
                var tb = Utilities.SendDataRequest<ThongBaoModel>(ConstantValues.Donhang.XoaDH, input);
                if (tb.Maso > 0)
                {
                    ViewData["ThongBao"] = tb.Noidung;
                }
            }
            return RedirectToAction("Index");
        }
    }
}
