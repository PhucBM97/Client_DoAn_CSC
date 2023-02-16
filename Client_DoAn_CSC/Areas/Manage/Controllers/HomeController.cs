using Microsoft.AspNetCore.Mvc;
using Client_DoAn_CSC.Areas.Manage.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize("QuanTri", "NhanVien")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
