using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Common
{
    public class DataAPI
    {
        public class SanPham
        {
            public static string DanhSachSanPham = "/api/SanPham/DanhSachSanPham";
            public static string DanhSachSanPhamThuongHieu = "/api/SanPham/SanPhamTheoThuongHieu";
        }

        public class ThanhVien
        {
            public static string DangNhap = "/api/ThanhVien/DangNhap";
            public static string DangKy = "/api/ThanhVien/DangKyThanhVien";
            public static string KichHoatTaiKhoan = "/api/ThanhVien/KichHoatTaiKhoan";
            public static string DoiMatKhau = "/api/ThanhVien/DoiMatKhau";

        }
    }
}
