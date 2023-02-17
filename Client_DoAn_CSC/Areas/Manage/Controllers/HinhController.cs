using Client_DoAn_CSC.Areas.Manage.Models.Authorization;
using Client_DoAn_CSC.Common;
using Client_DoAn_CSC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Areas.Manage.Controllers
{
    public class HinhController : Controller
    {
        [Area("Manage")]
        [Authorize("Quantri")]
        public class SlideBannerController : Controller
        {
            private readonly IWebHostEnvironment _hostingEnvironment;
            public SlideBannerController(IWebHostEnvironment environment)
            {
                _hostingEnvironment = environment;
            }
            public IActionResult Index()
            {
                var input = new HinhModel.Input.DocDanhSachHinh { QuanTri = true };
                var dsBanner = Utilities.SendDataRequest<List<HinhModel.Output.ThongTinHinh>>(ConstantValues.Hinh.DanhSachHinh, input);
                return View(dsBanner);
            }
            public IActionResult ThemSlideBanner(string ten, IFormFile hinh, string lienket, bool kichhoat)
            {
                HinhModel.HinhBase Hinh = new();
                if (hinh != null)
                {
                    var filename = hinh.FileName;
                    var filepath = Path.Combine(_hostingEnvironment.WebRootPath, "images\\slides\\banner", filename);
                    var imagepath = "/images/slides/banner/" + filename;
                    var banner = new HinhModel.Output.ThongTinHinh
                    {
                        Carousel = imagepath,
                        Thumbnails = filename,

                    };
                    var tb = Utilities.SendDataRequest<ThongBaoModel>(ConstantValues.Hinh.ThemHinh, banner);
                    if (tb.Maso > 0)
                    {
                        ViewData["ThongBao"] = tb.Noidung;
                        Utilities.PropertyCopier<HinhModel.Output.ThongTinHinh, HinhModel.HinhBase>.Copy(banner, Hinh);
                    }
                    else
                    {
                        hinh.CopyTo(new FileStream(filepath, FileMode.Create));
                        return RedirectToAction("Index");
                    }

                }
                return View(Hinh);
            }

            public IActionResult CapNhatSlideBanner(int id)
            {
                if (id > 0)
                {
                    var input = new HinhModel.Input.DocThongTinHinh { Id = id };
                    var banner = Utilities.SendDataRequest<HinhModel.Output.ThongTinHinh>(ConstantValues.Hinh.TTHinh, input);
                    if (banner != null && banner.HinhId > 0)
                    {
                        return View(banner);
                    }
                }
                return RedirectToAction("Index");
            }
            [HttpPost]
            public IActionResult CapNhatSlideBanner(IFormFile hinh, string ten, int id, string lienket, bool kichhoat)
            {
                var input = new HinhModel.Input.DocThongTinHinh { Id = id };
                var banner = Utilities.SendDataRequest<HinhModel.Output.ThongTinHinh>(ConstantValues.Hinh.TTHinh, input);
                HinhModel.HinhBase slideBanner = new();
                if (banner != null && banner.HinhId > 0)
                {
                    banner.Thumbnails = ten;
                    banner.KichHoat = kichhoat;
                    banner.Carousel = lienket == null ? "" : lienket;

                    var filepath = "";
                    if (hinh != null)
                    {
                        var filename = hinh.FileName;
                        filepath = Path.Combine(_hostingEnvironment.WebRootPath, "images\\slides\\banner", filename);
                        var imagepath = "/images/slides/banner/" + filename;
                        banner.Carousel = imagepath;
                    }

                    var tb = Utilities.SendDataRequest<ThongBaoModel>(ConstantValues.Hinh.CapnhatHinh, banner);

                    if (tb.Maso > 0)
                    {
                        ViewData["ThongBao"] = tb.Noidung;
                        Utilities.PropertyCopier<HinhModel.Output.ThongTinHinh, HinhModel.HinhBase>.Copy(banner, slideBanner);
                    }
                    else
                    {
                        if (filepath != "") hinh.CopyTo(new FileStream(filepath, FileMode.Create));
                        return RedirectToAction("Index");
                    }
                }
                return View(slideBanner);
            }

            public IActionResult XoaSlideBanner(int id)
            {
                if (id > 0)
                {
                    var input = new HinhModel.Input.XoaHinh { Id = id };
                    var tb = Utilities.SendDataRequest<ThongBaoModel>(ConstantValues.Hinh.XoaHinh, input);
                    if (tb.Maso > 0)
                    {
                        ViewData["ThongBao"] = tb.Noidung;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(tb.Noidung))
                        {
                            var filepath = _hostingEnvironment.WebRootPath + tb.Noidung.Replace("/", "\\");
                            if (filepath != "") System.IO.File.Delete(filepath);
                        }
                    }
                }
                return RedirectToAction("Index");
            }
        }
    }
}
