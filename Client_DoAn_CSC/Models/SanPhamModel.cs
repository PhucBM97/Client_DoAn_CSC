using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Models
{
    public class SanPhamModel
    {
        public class SanPhamBase
        {

            [ScaffoldColumn(false)]
            public int SanphamId { get; set; }
            
            public int LoaihangId { get; set; }
            public int ThuonghieuId { get; set; }
            [Required(ErrorMessage = "Mã phải khác rỗng")]
            [MaxLength(20, ErrorMessage = "Mã Sản phẩm tối đa 20 ký tự")]
            [Display(Name = "Mã Sản phẩm")]
            public string SanphamMa { get; set; }
            [Required(ErrorMessage = "Tên Sản phẩm phải khác rỗng")]
            [MaxLength(200, ErrorMessage = "Tên Sản phẩm tối đa 200 ký tự")]
            [Display(Name = "Tên Sản phẩm")]
            public string SanphamTen { get; set; }
            [Required(ErrorMessage = "Mô tả phải khác rỗng")]
            [MaxLength(500, ErrorMessage = "Mô tả Sản phẩm tối đa 500 ký tự")]
            [Display(Name = "Mô tả Sản phẩm")]
            public string SanphamMota { get; set; }

            public int? ChucnangId { get; set; }
            [Required(ErrorMessage = "Giá phải > 0")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Giá phải là số nguyên")]
            [Range(1, int.MaxValue, ErrorMessage = "Giá > 0")]
            [Display(Name = "Giá ")]
            public int? SanphamGia { get; set; }
            [Display(Name = "Poster phim")]
            public string SanphamHinh { get; set; }
            [Display(Name = "Ngày tạo")]
                
            public DateTime? Ngaytao { get; set; }

            public DateTime NgayCapNhat { get; set; }
            [Required(ErrorMessage = "Phần trăm giảm giá không nhỏ hon 0")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Phần trăm giảm phải là số nguyên")]
            [Range(1, int.MaxValue, ErrorMessage = "Phần trăm giảm giá >0")]
            [Display(Name = "Giảm giá")]
            public double GiamGia { get; set; }
            
            [RegularExpression("([0-9]+)", ErrorMessage = "Giá phải là số nguyên")]
            [Display(Name = "Số lượng")]
            public int SoLuong { get; set; }
            [Display(Name = "Thông tin")]
            public string ThongTin { get; set; }
            public bool? TrangThai { get; set; }

            public int Gia { get; set; }
            public int? BaohanhId { get; set; }
 


        }
        public class Input
        {
            public class ThongTinSanPham : SanPhamBase
            {

            }

            public class DocThongTinSanPham
            {
                public int ID { set; get; }
            }
            public class SanPhamTheoThuongHieu
            {
                public int ThuongHieuID { get; set; }
                public int CurrentPage { get; set; }
                public int PageSize { get; set; }
            }
        }

        public class Output
        {

            public class ThongTinSanPham : SanPhamBase
            {

                public ThuongHieuModel.ThuongHieuBase ThuongHieu { get; set; }
                public KhuyenMaiModel.KhuyenMaiBase KhuyenMai { get; set; }
                public LoaihangModel.LoaiHangBase LoaiHangSP { get; set; }
                // cần gì thêm vô
                public ThongTinSanPham()
                {

                    ThuongHieu = new ThuongHieuModel.ThuongHieuBase();
                    KhuyenMai = new KhuyenMaiModel.KhuyenMaiBase();
                    LoaiHangSP = new LoaihangModel.LoaiHangBase();
                }
            }
            public class SanPhamLoaiHang
            {
                public LoaihangModel.LoaiHangBase LoaihangHienHanh { get; set; }
                public List<LoaihangModel.LoaiHangBase> DanhSachLoaiHang { get; set; }
                public List<SanPhamModel.Output.ThongTinSanPham> DanhSachSanPham { get; set; }
                public int CurrentPage { get; set; }
                public int PageCount { get; set; }
                public SanPhamLoaiHang()
                {
                    LoaihangHienHanh = new();
                    DanhSachSanPham = new();
                    DanhSachLoaiHang = new();
                }

            }

            public class SanPhamThuongHieu
            {
                public ThuongHieuModel.ThuongHieuBase ThuongHieuHienHanh { get; set; }
                public List<ThuongHieuModel.ThuongHieuBase> DanhSachThuongHieu { get; set; }
                public List<SanPhamModel.Output.ThongTinSanPham> DanhSachSanPham { get; set; }
                public int CurrentPage { get; set; }
                public int PageCount { get; set; }
                public SanPhamThuongHieu()
                {
                    ThuongHieuHienHanh = new();
                    DanhSachSanPham = new();
                    DanhSachThuongHieu = new();
                }
            }
            public class SanPhamKhuyenMai
            {
                public KhuyenMaiModel.KhuyenMaiBase KhuyenMaiHienHanh { get; set; }
                public List<KhuyenMaiModel.KhuyenMaiBase> DanhSachKhuyenMai { get; set; }
                public List<SanPhamModel.Output.ThongTinSanPham> DanhSachSanPham { get; set; }
                public int CurrentPage { get; set; }
                public int PageCount { get; set; }
                public SanPhamKhuyenMai()
                {
                    KhuyenMaiHienHanh = new();
                    DanhSachSanPham = new();
                    DanhSachKhuyenMai = new();
                }
            }

            public class ThemSPMoi : SanPhamBase
            {
                public List<ThuongHieuModel.ThuongHieuBase> DanhSachThuongHieu { get; set; }
                public ChucnangModel.ChucnangBase Chucnang { get; set; }
                public List<LoaihangModel.LoaiHangBase> DanhSachLoaiHang { get; set; }
                public string ThongBao { get; set; }
                public ThemSPMoi()
                {
                    DanhSachThuongHieu = new List<ThuongHieuModel.ThuongHieuBase>();
                    DanhSachLoaiHang = new List<LoaihangModel.LoaiHangBase>();
                    Chucnang = new ChucnangModel.ChucnangBase();
                }

            }
            public class CapNhatSanPham : SanPhamBase
            {
                public List<ThuongHieuModel.ThuongHieuBase> DanhSachThuongHieu { get; set; }
                public ChucnangModel.ChucnangBase Chucnang { get; set; }
                public List<LoaihangModel.LoaiHangBase> DanhSachLoaiHang { get; set; }
                public string ThongBao { get; set; }
                public CapNhatSanPham()
                {
                    DanhSachThuongHieu = new List<ThuongHieuModel.ThuongHieuBase>();
                    DanhSachLoaiHang = new List<LoaihangModel.LoaiHangBase>();
                    Chucnang = new ChucnangModel.ChucnangBase();
                }
            }
        }
    }
}
