using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using K42Store106402.Models;
using Microsoft.AspNetCore.Mvc;

namespace K42Store106402.Controllers
{
    public class AjaxController : Controller
    {
        private MyeStoreContext db;
        public AjaxController(MyeStoreContext ctx)
        {
            db = ctx;
        }
        public IActionResult ServerTime()
        {
            return Content(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string keyword = "")
        {
            keyword = keyword.ToLower();
            var data = db.HangHoa.Where(p => p.TenHh.ToLower().Contains(keyword))
                .Select(p => new HangHoaViewModel
                {
                    MaHH = p.MaHh, TenHH = p.TenHh, Hinh = p.Hinh,
                    DonGia = p.DonGia.Value, GiamGia = p.GiamGia
                }).ToList();
            return PartialView(data);
        }

        public IActionResult Json()
        {
            return View();
        }

        public IActionResult JsonSearch(string keyword)
        {
            var data = db.HangHoa.Where(p => p.TenHh.Contains(keyword))
                .Select(p => new {TenHh = p.TenHh, GiaBan = p.DonGia.Value * (1 - p.GiamGia)});
            return Json(data);
        }

        public IActionResult CallApi()
        {
            return View();
        }
    }
}