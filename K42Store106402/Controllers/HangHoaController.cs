using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using K42Store106402.Models;
using Microsoft.AspNetCore.Mvc;

namespace K42Store106402.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly MyeStoreContext db;
        public HangHoaController(MyeStoreContext context)
        {
            db = context;
        }
        public IActionResult Index(int? maloai, string mancc)
        {
            List<HangHoa> dsHangHoas = new List<HangHoa>();
            if (maloai.HasValue)
            {
                dsHangHoas = db.HangHoa.Where(p => p.MaLoai == maloai)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(mancc))
            {
                dsHangHoas = db.HangHoa.Where(p => p.MaNcc == mancc)
                    .ToList();
            }
            return View(dsHangHoas.Select(p => new HangHoaViewModel
            {
                MaHH = p.MaHh, TenHH = p.TenHh, Hinh = p.Hinh,
                DonGia = p.DonGia.Value, GiamGia = p.GiamGia
            }));
        }

        public IActionResult ThongKe()
        {
            var data = db.ChiTietHd
                .GroupBy(p => p.MaHhNavigation.MaLoaiNavigation)
                .Select(p => new ThongKeViewModel
                {
                    TenLoai = p.Key.TenLoai,
                    DoanhThu = p.Sum(q => q.SoLuong * q.DonGia * (1 - q.GiamGia)),
                    GiaCaoNhat = p.Max(q => q.DonGia),
                    GiaThapNhat = p.Min(q => q.DonGia),
                    GiaTrungBinh = p.Average(q => q.DonGia),
                    SoHangHoa = p.Sum(q => q.SoLuong)
                });
            return View(data);
        }
    }
}