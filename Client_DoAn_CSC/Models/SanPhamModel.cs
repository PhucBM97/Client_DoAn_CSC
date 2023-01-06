using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Models
{
    public class SanPhamModel
    {
        public class SanPhamBase
        {
            public int SanphamId { get; set; }
            public int LoaihangId { get; set; }
            public int ThuonghieuId { get; set; }
            public string SanphamMa { get; set; }
            public string SanphamTen { get; set; }
            public string SanphamMota { get; set; }
            public int? ChucnangId { get; set; }
            public int? SanphamGia { get; set; }
            public string SanphamHinh { get; set; }
            public DateTime? Ngaytao { get; set; }
            public int? BaohanhId { get; set; }
            public bool? Hot { get; set; }

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
                // cần gì thêm vô
                public ThongTinSanPham()
                {
                    ThuongHieu = new();
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
        }
    }
}
