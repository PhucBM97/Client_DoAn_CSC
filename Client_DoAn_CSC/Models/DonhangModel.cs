using Client_DoAn_CSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CSC_API.DTO
{
    public class DonhangModel
    {
        public  class DonhangBase
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public short TinhTrangDonHang { get; set; }
            public double GiamGia { get; set; }
            public double PhiShip { get; set; }
            public double TongTien { get; set; }
            public string MaGiamGia { get; set; }
            public string Ten { get; set; }
            public string SoDienThoai { get; set; }
            public string Email { get; set; }
            public string DiaChi { get; set; }
            public DateTime NgayTao { get; set; }
            public DateTime NgayCapNhat { get; set; }
            public string NoiDung { get; set; }
                      
        }
        public class Input 
        {
            public class ThongTinDonHang : DonhangBase { }
            public class DocThongTinDonHang
            {
                public int Id { get; set; }
            }
            public class DocDanhSachDonHangTheoUser
            {
                public int UserId { get; set; }
            }
            public class MuaDonHang
            {
                public List<ThongTinDonHang> DanhSachDonHang { get; set; }
                public MuaDonHang()
                {
                    DanhSachDonHang = new();
                }
            }
        }
        public class Output
        {
            public class ThongTinDonHang:DonhangBase
            {
                public SanPhamModel.SanPhamBase SanPham { get; set; }
                public UserModel.UserBase User { get; set; }
                public ThongTinDonHang()
                {
                    SanPham = new();
                    User = new();
                }
            }

        }
    }
}
