using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Models
{
    public class ThuongHieuModel
    {
        public class ThuongHieuBase
        {
            public int ThuonghieuId { get; set; }
            public string Thuonghieuten { get; set; }
        }
        public class Input { }
        public class Output
        {
            public class ThongTinThuongHieu : ThuongHieuBase
            {

            }
        }
    }
}
