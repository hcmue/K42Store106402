using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K42Store106402.Models
{
    public class HangHoaViewModel
    {
        public int MaHH { get; set; }
        public string TenHH { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public double GiamGia { get; set; }
        public double GiaBan => DonGia * (1 - GiamGia);
        public bool DangKhuyenMai => GiamGia > 0;
    }
}
