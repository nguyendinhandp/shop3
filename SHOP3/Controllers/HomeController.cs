using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SHOP3.Models;

namespace SHOP3.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext context;
        public HomeController()
        {
            context = new MyDbContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("thong-tin-cua-hang")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
        [Route("lien-he")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
        [HttpPost]
        [Route("ket-qua-tim-kiem")]
        public IActionResult SearchSP()
        {

            string key = Request.Form["keysearch"];
            key = Helper.FriendlyUrlHelper.Change(key);
            var sp = from s in context.HangHoas
                     join l in context.Loais
                     on s.MaLoai equals l.MaLoai
                     join t in context.ThuongHieus
                     on s.MaTH equals t.MaTH
                     where s.TenHhTk.Contains(key) || l.TenLoaiTk.Contains(key) || t.TenTHTk.Contains(key)
                     select new HangHoa
                     {
                         MaHh = s.MaHh,
                         TenHh = s.TenHh,
                         MaLoai = s.MaLoai,
                         DonGia = s.DonGia,
                         Hinh = s.Hinh,
                         MoTa = s.MoTa,
                         GiamGia = s.GiamGia,
                         MaTH = s.MaTH
                     };

            return View(sp);


        }
    }
}
