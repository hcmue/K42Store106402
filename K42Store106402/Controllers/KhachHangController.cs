using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using K42Store106402.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace K42Store106402.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly MyeStoreContext db;
        public KhachHangController(MyeStoreContext context)
        {
            db = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                KhachHang kh = db.KhachHang.SingleOrDefault(p => p.MaKh == model.MaKH && p.MatKhau == model.MatKhau);
                if (kh == null)
                {
                    ModelState.AddModelError("Loi", "Không có khách hàng này.");
                    return View();
                }
                //ghi session
                //HttpContext.Session.SetString("MaKH", kh.MaKh);
                HttpContext.Session.Set("MaKH", kh);
                //chuyển tới trang HangHoa (--> MyProfile)
                return RedirectToAction("Index", "HangHoa");
            }
            return View();
        }

        public IActionResult Logout()
        {
            //xóa session
            HttpContext.Session.Remove("MaKH");
            return RedirectToAction("Login", "KhachHang");
        }
    }
}