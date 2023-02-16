using Client_DoAn_CSC.Common;
using Client_DoAn_CSC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Areas.Manage.Controllers
{
    public class KhuyenmaiController : Controller
    {
        public IActionResult Index()
        {
            var dsSuatChieu = Utilities.SendDataRequest<List<KhuyenMaiModel.Output.ThongTinKhuyenMai>>(ConstantValues.KhuyenMai.DSKM);
            return View(dsSuatChieu);
        }

        public IActionResult DanhSachKhuyenMai()
        {
            var dsSuatChieu = Utilities.SendDataRequest<List<KhuyenMaiModel.Output.ThongTinKhuyenMai>>(ConstantValues.KhuyenMai.DSKM);
            return View(dsSuatChieu);
        }

        public IActionResult ThemKhuyenMai()
        {
            KhuyenMaiModel.Output.ThemKhuyenMai model = new();
            return View(model);
        }

        [HttpPost]
        public IActionResult ThemKhuyenMai(IFormCollection form)
        {
            KhuyenMaiModel.Output.ThemKhuyenMai model = new KhuyenMaiModel.Output.ThemKhuyenMai();
            try
            {
                if (string.IsNullOrEmpty(form["Loaihang"]))
                    model.ThongBao = "<p>- Phải xác định loại hàng</p>";
                if (string.IsNullOrEmpty(form["GioBatDau"]))
                    model.ThongBao += "<p>- Giờ bắt đầu phải khác rỗng</p>";
                if (string.IsNullOrEmpty(form["GiamGia"]))
                    model.ThongBao += "<p>- Giờ bắt đầu phải khác rỗng</p>";
                else
                {
                    var batdau = form["GioBatDau"].ToString().Split(':');
                    if (batdau.Length != 2 || !batdau[0].All(char.IsDigit) || !batdau[1].All(char.IsDigit))
                        model.ThongBao += "<p>- Giờ bắt đầu không hợp lệ</p>";
                    else if (int.Parse(batdau[0]) < 8 || int.Parse(batdau[0]) > 24 || int.Parse(batdau[1]) < 0 || int.Parse(batdau[1]) > 59)
                        model.ThongBao += "<p>- Giờ bắt đầu không hợp lệ</p>";
                }
                if (string.IsNullOrEmpty(model.ThongBao))
                {
                    var khuyenmaiMoi = new KhuyenMaiModel.Output.ThemKhuyenMai
                    {
                        LoaiHangId = int.Parse(form["Loaihang"].ToString()),
                        NgayBatDau = DateTime.Parse(form["GioBatDau"].ToString()),
                        NgayKetThuc = DateTime.Parse(form["GioBatDau"].ToString()),
                        PhanTramGiam = int.Parse(form["GiamGia"].ToString()),
                        QuaTangKem = form["Qua"].ToString(),
                        VoucherTangKem = form["Voucher"].ToString()
                    };
                    var tb = Utilities.SendDataRequest<ThongBaoModel>(ConstantValues.KhuyenMai.ThemKM, khuyenmaiMoi);
                    if (tb.Maso== 0) return RedirectToAction("Index");
                    model.ThongBao = tb.Noidung;
                }
            }
            catch (Exception ex)
            {
                model.ThongBao = "Có lỗi xảy ra: " + ex.Message;
            }
            return View(model);
        }

        public IActionResult CapNhatKhuyenMai(int id)
        {
            if (id > 0)
            {
                var input = new KhuyenMaiModel.Input.DocThongTinKhuyenMai{ Id = id };
                var khuyenMai= Utilities.SendDataRequest<KhuyenMaiModel.Output.CapNhatKhuyenMai>(ConstantValues.KhuyenMai.TTKM, input);
                if (khuyenMai != null && khuyenMai.Id > 0)
                {
                    return View(khuyenMai);
                }
            }
            RedirectToAction("DanhSachKhuyenMai");
            return View();
        }
        [HttpPost]
        public IActionResult CapNhatSuatChieu(IFormCollection form)
        {
            KhuyenMaiModel.Output.CapNhatKhuyenMai model = new();
            try
            {
                if (string.IsNullOrEmpty(form["Loaihang"]))
                    model.ThongBao = "<p>- Phải xác định loại hàng</p>";
                if (string.IsNullOrEmpty(form["GioBatDau"]))
                    model.ThongBao += "<p>- Giờ bắt đầu phải khác rỗng</p>";
                if (string.IsNullOrEmpty(form["GiamGia"]))
                    model.ThongBao += "<p>- Giờ bắt đầu phải khác rỗng</p>";
                else
                {
                    var batdau = form["GioBatDau"].ToString().Split(':');
                    if (batdau.Length != 2 || !batdau[0].All(char.IsDigit) || !batdau[1].All(char.IsDigit))
                        model.ThongBao += "<p>- Giờ bắt đầu không hợp lệ</p>";
                    else if (int.Parse(batdau[0]) < 8 || int.Parse(batdau[0]) > 24 || int.Parse(batdau[1]) < 0 || int.Parse(batdau[1]) > 59)
                        model.ThongBao += "<p>- Giờ bắt đầu không hợp lệ</p>";
                }
                if (string.IsNullOrEmpty(model.ThongBao))
                {
                    var suatChieuCapNhat = new KhuyenMaiModel.Output.CapNhatKhuyenMai
                    {
                        Id = int.Parse(form["Id"].ToString()),
                        LoaiHangId = int.Parse(form["Loaihang"].ToString()),
                        NgayBatDau = DateTime.Parse(form["GioBatDau"].ToString()),
                        NgayKetThuc = DateTime.Parse(form["GioBatDau"].ToString()),
                        PhanTramGiam = int.Parse(form["GiamGia"].ToString()),
                        QuaTangKem = form["Qua"].ToString(),
                        VoucherTangKem = form["Voucher"].ToString()
                    };
                    var tb = Utilities.SendDataRequest<ThongBaoModel>(ConstantValues.KhuyenMai.CapnhatKM, suatChieuCapNhat);
                    model.ThongBao = tb.Noidung;
                }
            }
            catch (Exception ex)
            {
                model.ThongBao = "Có lỗi xảy ra: " + ex.Message;
            }

            model.Id = int.Parse(form["Id"].ToString());

            model.NgayBatDau = DateTime.Parse(form["NgayBatDau"].ToString());

            model.NgayKetThuc = DateTime.Parse(form["GioBatDau"].ToString());
            model.PhanTramGiam = int.Parse(form["GiamGia"].ToString());
            model.QuaTangKem = form["Qua"].ToString();
            return View(model);
        }
        public IActionResult XoaKhuyenMai(int id)
        {
            if (id > 0)
            {
                var input = new KhuyenMaiModel.Input.XoaKhuyenMai{ Id = id };
                var tb = Utilities.SendDataRequest<ThongBaoModel>(ConstantValues.KhuyenMai.XoaKM, input);
                if (tb.Maso > 0)
                {
                    ViewData["ThongBao"] = tb.Noidung;
                }
            }
            return RedirectToAction("Index");
        }
    }
}
