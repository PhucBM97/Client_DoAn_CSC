﻿using Client_DoAn_CSC.Common;
using Client_DoAn_CSC.Models;
using Microsoft.AspNetCore.Mvc;
using QLRapChieuPhim.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SPDangHot()
        {
            if (HttpContext.Session.Get<ThanhVienModel.Output.ThongTinThanhVien>("ThanhVien") == null)
                return RedirectToAction("Index", "Home");
            var model = Utilities.SendDataRequest<List<SanPhamModel.Output.ThongTinSanPham>>(ConstantValues.SanPham.SanPhamHot);
            ViewData["loaihang"] = "SPDangHot";
            return View("DSSP", model);
        }
        public IActionResult SPMoi()
        {
            if (HttpContext.Session.Get<ThanhVienModel.Output.ThongTinThanhVien>("ThanhVien") == null)
                return RedirectToAction("Index", "Home");
            var model = Utilities.SendDataRequest<List<SanPhamModel.Output.ThongTinSanPham>>(ConstantValues.SanPham.SanPhamMoi);
            ViewData["loaihang"] = "SPMoi";
            return View("DSSP", model);
        }
        public IActionResult TTSP(int id)
        {
            //if (HttpContext.Session.Get<ThanhVienModel.Output.ThongTinThanhVien>("ThanhVien") == null)
            //    return RedirectToAction("Index", "Home");

            if (id > 0)
            {
                SanPhamModel.Input.DocThongTinSanPham input = new() { ID = id };
                var thongtinSP = Utilities.SendDataRequest<SanPhamModel.Output.ThongTinSanPham>(ConstantValues.SanPham.ThongTinSP, input);
                return View(thongtinSP);

            }
            RedirectToAction("DSSP");
            return View();
        }

        public IActionResult DatHang(int id, string ngaydat)
        {
            if (HttpContext.Session.Get<ThanhVienModel.Output.ThongTinThanhVien>("ThanhVien") == null)
                return RedirectToAction("Index", "Home");

            //Lay thong tin SP
            var input_SP = new SanPhamModel.Input.DocThongTinSanPham { ID = id };
            var SP = Utilities.SendDataRequest<SanPhamModel.Output.ThongTinSanPham>(ConstantValues.SanPham.ThongTinSP, input_SP);
            if (SP == null || string.IsNullOrEmpty(SP.SanphamTen)) return RedirectToAction("Index", "Home");
            ViewData["SanPham"] = SP;
            return View(SP);
        }

        
    }
}
