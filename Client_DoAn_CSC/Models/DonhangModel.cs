using Client_DoAn_CSC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.DTO
{
    public class DonhangModel
    {
        public  class DonhangBase
        {
            [ScaffoldColumn(false)]
            public int Id { get; set; }

            [Required(ErrorMessage ="UserId không được để trống")]
            [Display(Name ="Danh sách Id Khách hàng")]
            public int UserId { get; set; }
            
            public bool TinhTrangDonHang { get; set; }
            [Required(ErrorMessage = "Phần trăm giảm giá không nhỏ hon 0")]
            [RegularExpression("([0-9]+)", ErrorMessage ="Phần trăm giảm phải là số nguyên")]
            [Range(1,int.MaxValue,ErrorMessage ="Phần trăm giảm giá >0")]
            public double GiamGia { get; set; }
            [Required(ErrorMessage = "Phí ship không được nhỏ hơn 0")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Giá là số nguyên")]
            
            [Range(1, int.MaxValue, ErrorMessage = "Phí ship không được nhỏ hơn 0")]
            public double PhiShip { get; set; }
            
            public double TongTien { get; set; }
            [Display(Name ="Mã giảm giá")]
            
            public string MaGiamGia { get; set; }
            [Display(Name = "Tên người nhận")]
            [Required(ErrorMessage = "Tên phải khác rỗng")]
            public string Ten { get; set; }
            [Display(Name = "Số điện thoại")]
            [Required(ErrorMessage = "SDT phải khác rỗng")]
            public string SoDienThoai { get; set; }
            [Display(Name = "Số điện thoại")]
            public string Email { get; set; }
            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "Địa chỉ phải khác rỗng")]
            public string DiaChi { get; set; }
            [Display(Name = "Ngày Tạo")]
            [DataType(DataType.Date)]
            public DateTime NgayTao { get; set; }
            
            public DateTime NgayCapNhat { get; set; }
            [Display(Name = "Nội dung")]
            public string NoiDung { get; set; }
                      
        }
        public class Input 
        {
            public class ThongTinDonHang : DonhangBase { }
            public class DocThongTinDonHang
            {
                public int Id { get; set; }
            }

            public class TimThongTinDonHang
            {
                public string KhachHangId { get; set; }
                public int PageSize { get; set; }
                public int CurrentPage { get; set; }
            }
            public class DocDanhSachDonHangTheoKh
            {
                public int KhachHangId { get; set; }
                public int PageSize { get; set; }
                public int CurrentPage { get; set; }
            }
            public class MuaDonHang
            {
                public List<ThongTinDonHang> DanhSachDonHang { get; set; }
                public MuaDonHang()
                {
                    DanhSachDonHang = new();
                }
            }
            public class ThemDonHang : DonhangBase
            {
                public List<ThuongHieuModel.ThuongHieuBase> DanhSachThuongHieu { get; set; }
                public List<LoaihangModel.LoaiHangBase> DanhSachLoaiHang { get; set; }
                public ThanhVienModel.ThanhVienBase KhachHang { get; set; }
                public string ThongBao { get; set; }
                public ThemDonHang()
                {
                    DanhSachLoaiHang = new List<LoaihangModel.LoaiHangBase>();
                    DanhSachThuongHieu = new List<ThuongHieuModel.ThuongHieuBase>();
                    KhachHang = new ThanhVienModel.ThanhVienBase();
                }
            }

            public class XoaDonHang
            {
                public int Id { get; set; }
            }
        }
        public class Output
        {
            public class ThongTinDonHang : DonhangBase
            {
                public List<SanPhamModel.SanPhamBase> DanhSachsanpham { get; set; }
                public ThanhVienModel.ThanhVienBase Khachhang { get; set; }
                public ThongTinDonHang()
                {
                    DanhSachsanpham = new List<SanPhamModel.SanPhamBase>();
                    Khachhang = new ThanhVienModel.ThanhVienBase();
                }


            }

            public class DonHangTheoKhachHang
            {
                public ThanhVienModel.ThanhVienBase KhachHangDangOnl { get; set; }
                public List<ThanhVienModel.ThanhVienBase> DanhSachKhacHang { get; set; }
                public List<DonhangBase> DanhSachDonHang { get; set; }
                public int CurrentPage { get; set; }
                public int PageCount { get; set; }
                public DonHangTheoKhachHang()
                {
                    KhachHangDangOnl = new ThanhVienModel.ThanhVienBase();
                    DanhSachDonHang = new List<DonhangModel.DonhangBase>();
                    DanhSachKhacHang = new List<ThanhVienModel.ThanhVienBase>();

                }
            }
            public class DonHangTheoNgay
            {


                public List<DonhangBase> DanhSachDonHang { get; set; }
                public DateTime NgayDonHang { get; set; }

                public int CurrentPage { get; set; }
                public int PageCount { get; set; }
                public DonHangTheoNgay()
                {
                    DanhSachDonHang = new List<DonhangBase>();


                }
            }
            public class ThemDonHang : DonhangBase
            {

                public List<SanPhamModel.SanPhamBase> DanhSachSanPham { get; set; }

                public ThanhVienModel.ThanhVienBase KhachHang { get; set; }
                public string ThongBao { get; set; }
                public ThemDonHang()
                {
                    DanhSachSanPham = new List<SanPhamModel.SanPhamBase>();
                    KhachHang = new ThanhVienModel.ThanhVienBase();
                }
            }
            public class CapNhatDon : DonhangBase
            {

                public List<SanPhamModel.SanPhamBase> DanhSachSanPham { get; set; }

                public ThanhVienModel.ThanhVienBase KhachHang { get; set; }
                public string ThongBao { get; set; }
                public CapNhatDon()
                {
                    DanhSachSanPham = new List<SanPhamModel.SanPhamBase>();
                    KhachHang = new ThanhVienModel.ThanhVienBase();
                }
            }

        }
    }
}
