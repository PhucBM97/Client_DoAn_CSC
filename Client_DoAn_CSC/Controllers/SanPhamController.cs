using Client_DoAn_CSC.Common;
using Client_DoAn_CSC.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult DSSP()
        {
            var sanphams = Utilities.SendDataRequest<List<SanPhamModel.Output.ThongTinSanPham>>(DataAPI.SanPham.DanhSachSanPham);
            return View(sanphams);
        }

        public IActionResult DSSPThuongHieu()
        {
                var sanphamthuonghieu = Utilities.SendDataRequest<SanPhamModel.Output.SanPhamThuongHieu>(DataAPI.SanPham.DanhSachSanPhamThuongHieu);
                return View(sanphamthuonghieu);

            
            
        }
    }
}
