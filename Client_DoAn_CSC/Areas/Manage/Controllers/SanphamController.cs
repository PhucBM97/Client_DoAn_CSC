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
    [Area("Manage")]
    public class SanphamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DanhSachSP(int thuonghieuId, int CurrentPage, int PageSize)
        {
            if (thuonghieuId == 0) thuonghieuId = 1;
            var input = new SanPhamModel.Input.SanPhamTheoThuongHieu
            {
                ThuongHieuID = thuonghieuId,
                CurrentPage = CurrentPage,
                PageSize = PageSize
            };
            SanPhamModel.Output.SanPhamThuongHieu model = new SanPhamModel.Output.SanPhamThuongHieu();
            model = Utilities.SendDataRequest<SanPhamModel.Output.SanPhamThuongHieu>(ConstantValues.SanPham.DSSPTH, input);

            return View("DSSP", model);
        }

        public IActionResult ThongTinSP(int id)
        {
            if (id > 0)
            {
                var input = new SanPhamModel.Input.DocThongTinSanPham { ID= id };
                var thongtinSP = Utilities.SendDataRequest<SanPhamModel.Output.ThongTinSanPham>(ConstantValues.SanPham.ThongTinSP, input);

                if (thongtinSP!= null && thongtinSP.SanphamId> 0)
                {
                    return View(thongtinSP);
                }
            }
            RedirectToAction("DanhSachPhim");
            return View();
        }

        public IActionResult ThemPhimMoi()
        {
            SanPhamModel.Output.ThemSPMoi model = new SanPhamModel.Output.ThemSPMoi();
            var chuoi_dich_vu = "api/Loaihang/DanhSachLoaiHang";
            var theLoais = Utilities.SendDataRequest<List<LoaihangModel.Output.ThongTinLoaiHang>>(chuoi_dich_vu);
            chuoi_dich_vu = "api/Thuonghieu/DanhSachThuongHieu";
            var xepHangPhims = Utilities.SendDataRequest<List<ThuongHieuModel.Output.ThongTinThuongHieu>>(chuoi_dich_vu);
            model.DanhSachThuongHieu= xepHangPhims.Select(x => new ThuongHieuModel.ThuongHieuBase
            {
            ThuonghieuId = x.ThuonghieuId,
            Thuonghieuten = x.Thuonghieuten
            }).ToList();
            model.DanhSachLoaiHang= theLoais.Select(x => new LoaihangModel.LoaiHangBase{ Id = x.Id, Ten = x.Ten }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult ThemSPMoi(IFormCollection form)
        {
            SanPhamModel.Output.ThemSPMoi model = new SanPhamModel.Output.ThemSPMoi();
            var chuoi_dich_vu = "";
            try
            {
                if (string.IsNullOrEmpty(form["TenSP"]))
                    model.ThongBao = "<p>- Tên Sản phẩm phải khác rỗng</p>";
                if (string.IsNullOrEmpty(form["Gia"]) || int.Parse(form["Gia"]) <= 0)
                    model.ThongBao += "<p>- Giá phải khác  > 0</p>";
                if (string.IsNullOrEmpty(model.ThongBao))
                {
                    var phimThemMoi = new SanPhamModel.Output.ThemSPMoi()
                    {
                        SanphamTen = form["TenSP"].ToString(),
                        SanphamGia = int.Parse(form["Gia"].ToString()),
                        SanphamHinh = form["Hinh"].ToString(),
                        SanphamMa = form["MaSP"].ToString(),
                        LoaihangId = int.Parse(form["LoaihangId"].ToString()),
                        ChucnangId = int.Parse(form["ChucnangId"].ToString()),
                        SoLuong = int.Parse(form["Soluong"].ToString()),
                        GiamGia = int.Parse(form["Giamgia"].ToString()),
                        Ngaytao =DateTime.Parse(form["Ngaytao"].ToString()),
                        SanphamMota = form["Mota"].ToString(),
                       
                    };
                    chuoi_dich_vu = "api/QuanTri/ThemSPMoi";
                    var tb = Utilities.SendDataRequest<ThongBaoModel>(chuoi_dich_vu, phimThemMoi);
                    model.ThongBao = "";
                }
            }
            catch (Exception ex)
            {
                model.ThongBao = "Có lỗi xảy ra: " + ex.Message;
            }
            chuoi_dich_vu = "api/Phim/DanhSachSanPhamTheoLoaiHang";
            var loaihangs = Utilities.SendDataRequest<List<LoaihangModel.Output.ThongTinLoaiHang>>(chuoi_dich_vu);
            chuoi_dich_vu = "api/Phim/DanhSachSanPhamTheoThuongHieu";
            var thuonghieus = Utilities.SendDataRequest<List<ThuongHieuModel.Output.ThongTinThuongHieu>>(chuoi_dich_vu);
            model.DanhSachThuongHieu = thuonghieus.Select(x => new ThuongHieuModel.ThuongHieuBase
            {
                ThuonghieuId = x.ThuonghieuId,
                Thuonghieuten = x.Thuonghieuten
            }).ToList();
                                   
            model.DanhSachLoaiHang = loaihangs.Select(x => new LoaihangModel.LoaiHangBase { Id = x.Id, Ten = x.Ten }).ToList();
            return View(model);
        }

        public IActionResult CapNhatSanPham(int id)
        {
            if (id > 0)
            {
                var chuoi_dich_vu = $"api/Sanpham/ThongTinSP?id={id}";
                var sanpham = Utilities.SendDataRequest<SanPhamModel.Output.ThongTinSanPham>(chuoi_dich_vu);
                chuoi_dich_vu = "api/Sanpham/DanhSachSanPhamTheoLoaiHang";
                var loaihangs= Utilities.SendDataRequest<List<LoaihangModel.Output.ThongTinLoaiHang>>(chuoi_dich_vu);
                chuoi_dich_vu = "api/Sanpham/DanhSachSanPhamTheoThuongHieu";
                var thuonghieus = Utilities.SendDataRequest<List<ThuongHieuModel.Output.ThongTinThuongHieu>>(chuoi_dich_vu);
                if (sanpham != null && sanpham.SanphamId > 0)
                {
                    SanPhamModel.Output.CapNhatSanPham thongtinSP= new();
                    Utilities.PropertyCopier<SanPhamModel.Output.ThongTinSanPham, SanPhamModel.Output.CapNhatSanPham>.Copy(sanpham, thongtinSP);

                    thongtinSP.DanhSachThuongHieu= thuonghieus.Select(x => new ThuongHieuModel.ThuongHieuBase
                    {
                        ThuonghieuId= x.ThuonghieuId,
                        Thuonghieuten = x.Thuonghieuten
                    }).ToList();

                    thongtinSP.DanhSachLoaiHang = loaihangs.Select(x => new LoaihangModel.LoaiHangBase()
                    {
                        Id = x.Id,
                        Ten = x.Ten
                    }).ToList();
                    return View(thongtinSP);
                }
            }
            RedirectToAction("DanhSachPhim");
            return View();
        }

        [HttpPost]
        public IActionResult capnhatSP(IFormCollection form)
        {
            SanPhamModel.Output.CapNhatSanPham model = new SanPhamModel.Output.CapNhatSanPham();
            var chuoi_dich_vu = "";
            try
            {
                if (string.IsNullOrEmpty(form["TenSP"]))
                    model.ThongBao = "<p>- Tên Sản phẩm phải khác rỗng</p>";
                if (string.IsNullOrEmpty(form["Gia"]) || int.Parse(form["Gia"]) <= 0)
                    model.ThongBao += "<p>- Giá phải > 0</p>";
                if (string.IsNullOrEmpty(form["LoaihangId"]))
                    model.ThongBao += "<p>- Sảm phẩm phải thuộc loại hàng </p>";
                if (string.IsNullOrEmpty(form["ThuonghieuId"]))
                    model.ThongBao += "<p>- Sảm phẩm phải thuộc thương hiệu</p>";
                if (string.IsNullOrEmpty(form["Gia"]))
                    model.ThongBao += "<p>- Sảm phẩm phải có giá </p>";
                if (string.IsNullOrEmpty(form["MaSP"]))
                    model.ThongBao += "<p>- Sảm phẩm phải có Mã </p>";
                if (string.IsNullOrEmpty(model.ThongBao))
                {
                    var spCapNhat = new SanPhamModel.Output.ThongTinSanPham
                    {
                        SanphamId = int.Parse(form["Id"].ToString()),
                        SanphamTen = form["TenSP"].ToString(),
                        SanphamMa= form["MaSP"].ToString(),
                        ChucnangId= int.Parse(form["ChucnangId"].ToString()),
                        SanphamGia= int.Parse(form["Gia"].ToString()),
                        LoaihangId = int.Parse(form["LoaihangId"].ToString()),
                        ThuonghieuId = int.Parse(form["ThonghieuId"].ToString()),
                        SanphamHinh = form["Hinh"].ToString(),
                        SoLuong =int.Parse(form["Soluong"].ToString()),
                        GiamGia = int.Parse(form["Giamgia"].ToString()),
                        Gia = int.Parse(form["Gia"].ToString()),
                        
                    };
                    chuoi_dich_vu = "api/QuanTri/CapNhatSP";
                    var tb = Common.Utilities.SendDataRequest<ThongBaoModel>(chuoi_dich_vu, spCapNhat);
                    model.ThongBao = tb.Noidung;
                }
            }
            catch (Exception ex)
            {
                model.ThongBao = "Có lỗi xảy ra: " + ex.Message;
            }

            //Gán thông tin phim cho phim cập nhật trả về view
            //...  
            model.SanphamId = int.Parse(form["Id"].ToString());
            model.SanphamTen = form["TenSP"].ToString();
            model.SanphamMa = form["MaSP"].ToString();
            model.ChucnangId = int.Parse(form["ChucnangId"].ToString());
            model.SanphamGia = int.Parse(form["Gia"].ToString());
            model.LoaihangId = int.Parse(form["LoaihangId"].ToString());
            model.ThuonghieuId = int.Parse(form["ThonghieuId"].ToString());
            model.SanphamHinh = form["Hinh"].ToString();
            model.SoLuong = int.Parse(form["Soluong"].ToString());
            model.GiamGia = int.Parse(form["Giamgia"].ToString());
            model.Gia = int.Parse(form["Gia"].ToString());
            model.NgayCapNhat = string.IsNullOrEmpty(form["NgayCapNhat"]) ? new DateTime(DateTime.Today.Year) : DateTime.Parse(form["NgayCapNhat"]);

            chuoi_dich_vu = "api/Phim/";
            var loaihangs = Common.Utilities.SendDataRequest<List<LoaihangModel.Output.ThongTinLoaiHang>>(chuoi_dich_vu);
            chuoi_dich_vu = "api/Phim/DocDanhSachXepHangPhim";
            var xepHangPhims = Common.Utilities.SendDataRequest<List<ThuongHieuModel.Output.ThongTinThuongHieu>>(chuoi_dich_vu);
            model.DanhSachThuongHieu = xepHangPhims.Select(x => new ThuongHieuModel.ThuongHieuBase
            {
                ThuonghieuId = x.ThuonghieuId,
                Thuonghieuten =x.Thuonghieuten
            }).ToList();
            model.DanhSachLoaiHang = loaihangs.Select(x => new LoaihangModel.LoaiHangBase
            {
                Ten = x.Ten,
                Id = x.Id
            }).ToList();
            return View(model);
        }
    }
}
