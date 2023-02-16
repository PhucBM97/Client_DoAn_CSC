using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Common
{
    public class ConstantValues
    {
        public class SanPham
        {
            public const string DSSPLH = "api/SanPham/DanhSachSanPhamTheoLoaiHang";
            public const string DSSPTH = "api/SanPham/DanhSachSanPhamTheoThuongHieu";
            public const string ThongTinSP = "api/SanPham/ThongTinSP";
            public const string SPKM = "api/SanPham/DanhSachSanPhamCoKhuyenMai";
            public const string SanPhamMoi = "api/SanPham/SanPhamMoi";
            public const string SanPhamHot = "api/SanPham/SanPhamHot";
            public const string ThemSP = "api/SanPham/ThemSPMoi";
            public const string CapnhatSP = "api/SanPham/CapNhatSP";
            public const string XoaSP = "api/SanPham/XoaSP";
        }
        public class LoaiHang
        {
            public const string DSLH = "api/Loaihang/DanhSachLoaiHang";
            public const string TTLH = "api/Loaihang/ThongTinLoaiHang";
            public const string ThongTinSP = "api/SanPham/ThongTinSP";
        }
        public class Chucnang
        {
            public const string TTCN = "api/Chucnang/ThongTinChucNang";
            

        }
        public class Donhang
        {
            public const string MuaDH = "api/Donhang/MuaDonHang";
            public const string DSSPTH = "api/Donhang/DanhSachDonHangTheoKhachHang";
            public const string TTDH = "api/Donhang/ThongTinDonHang";
            public const string ThemDH = "api/Donhang/ThemDonHangMoi";
            public const string CapnhatDH = "api/Donhang/CapNhatDonHang";
            public const string XoaDH = "api/Donhang/XoaDonhang";
        }
        public class Hinh
        {
            public const string DanhSachHinh = "api/Hinh/DanhSachHinh";
            public const string ThemHinh = "api/Hinh/ThemHinh";
            public const string TTHinh = "api/Hinh/ThongTinHinh";
            public const string CapnhatHinh = "api/Hinh/CapNhatHinh";
            public const string XoaHinh = "api/Hinh/XoaHinh";
        }
        public class KhachHang
        {
            public const string DangNhap = "api/KhachHang/DangNhap";
            public const string AnDanh = "api/KhachHang/DangNhapAnDanh";
            public const string DangXuat = "api/KhachHang/DangXuat";
            public const string DangKy = "api/KhachHang/DangKyKhachHang";
            public const string ThemKhachHang = "api/KhachHang/ThemKhachHang";
            public const string ThayDoiMK = "api/KhachHang/ThayDoiMatKhau";
            public const string ThongTinKH = "api/KhahHang/ThongTinKhachHang";
            public const string KichHoat = "api/KhahHang/KichHoatTaiKhoan";
        }
        public class User
        {
            public const string DangNhap = "api/User/DangNhap";
            public const string DSNV = "api/User/DanhSachNhanVien";
            public const string DangXuat = "api/User/DangXuat";
            
            public const string ThemNhanVien = "api/User/ThemNhanVien";
            public const string ThayDoiMK = "api/User/ThayDoiMatKhau";
            public const string ThongTinUser = "api/User/ThongTinUser";
            public const string KichHoat = "api/User/KichHoatTaiKhoan";
        }
        public class KhuyenMai
        {
            public const string KMLH = "api/Khuyenmai/DanhSachKhuyenMaiTheoLoaiHang";
            public const string TTKM = "api/Khuyenmai/ThongTinKhuyenMai";
            public const string DSKM = "api/Khuyenmai/DanhSachKhuyenMaiDangCo";
            public const string ThemKM = "api/Khuyenmai/ThemKhuyenMai";
            public const string CapnhatKM= "api/Khuyenmai/CapNhatKhuyenMai";
            public const string XoaKM = "api/Khuyenmai/XoaKhuyenMai";
        }
        public class ThuongHieu
        {
            public const string DSTH = "api/Thuonghieu/DanhSachThuongHieu";
            
        }
    }
}
