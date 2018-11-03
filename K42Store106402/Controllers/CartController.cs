using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using K42Store106402.Models;
using Microsoft.AspNetCore.Mvc;

namespace K42Store106402.Controllers
{
    public class CartController : Controller
    {
        private readonly MyeStoreContext db;
        public CartController(MyeStoreContext ctx)
        {
            db = ctx;
        }

        public List<CartItem> Carts
        {
            get
            {
                List<CartItem> myCart = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (myCart == default(List<CartItem>))
                {
                    myCart = new List<CartItem>();
                }

                return myCart;
            }
        }
        public IActionResult Index()
        {
            return View(Carts);
        }

        public IActionResult AddToCart(int mahh)
        {
            List<CartItem> gioHang = Carts;
            //tìm xem có chưa
            CartItem item = gioHang.SingleOrDefault(p => p.MaHh == mahh);
            if (item != null) //có rồi
            {
                item.SoLuong++;
            }
            else
            {
                HangHoa hh = db.HangHoa.SingleOrDefault(p => p.MaHh == mahh);
                item = new CartItem
                {
                    MaHh = hh.MaHh, TenHh = hh.TenHh, Hinh = hh.Hinh,
                    SoLuong = 1, GiaBan = hh.DonGia.Value * (1 - hh.GiamGia)
                };
                gioHang.Add(item);
            }
            //lưu session
            HttpContext.Session.Set("GioHang", gioHang);
            return RedirectToAction("Index");
        }
    }
}