using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHOP3.Models;
using SHOP3.Paypal;

namespace SHOP3.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private MyDbContext _context;

        public CartController()
        {
            _context = new MyDbContext();
        }
        // GET: Cart
        [Route("index")]
        public ActionResult Index()
        {
            if (Models.SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart") == null)
            {
                return View("trong");
            }
            else
            {
                var cart = Models.SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");

                ViewBag.cart = cart;
                
                ViewBag.total = cart.Sum(item => item.DonGia * item.SoLuong);

            }
            PayPalConfig payPalConfig = PayPalService.GetPayPalConfig();
            ViewBag.payPalConfig = payPalConfig;

            return View();
        }
        // mua
        [HttpGet("{id},{s}")]
        [Route("buy/{id}")]
        public IActionResult Buy(int id, int s)
        {
            if (Models.SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<Item>();

                HangHoa hh = _context.HangHoas.Find(id);
                Item newItem = new Item()
                {
                    MaHh = hh.MaHh, // MaHh = id,
                    TenHh = hh.TenHh,
                    SoLuong = 1,
                    Hinh = hh.Hinh,
                    DonGia = hh.Price,
                    Size = s,

                };

                cart.Add(newItem);

                Models.SessionExtensions.Set(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cart = Models.SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
                int index = Exists(cart, id, s);
                if (index == -1)
                {
                    HangHoa hh = _context.HangHoas.Find(id);
                    Item newItem = new Item()
                    {
                        MaHh = hh.MaHh, // MaHh = id,
                        TenHh = hh.TenHh,
                        SoLuong = 1,
                        Hinh = hh.Hinh,
                        DonGia = hh.Price,
                        Size = s,

                    };

                    cart.Add(newItem);
                }
                else
                {
                    cart[index].SoLuong += 1;

                }
                Models.SessionExtensions.Set(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        private int Exists(List<Item> cart, int id, int s)
        {

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].MaHh == id && cart[i].Size == s)
                {
                    return i;
                }
            }
            return -1;
        }
        [HttpGet("{id},{s}")]
        [Route("remove/{id}")]
        public IActionResult Remove(int id, int s)
        {
            List<Item> cart = Models.SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
            int index = Exists(cart, id, s);
            cart.RemoveAt(index);
            Models.SessionExtensions.Set(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

       
        [HttpGet("{id},{s},{sl}")]
        [Route("Update/{id}")]
        public IActionResult Update(int id, int s, int sl)
        {
                var cart = Models.SessionExtensions.Get<List<Item>>(HttpContext.Session, "cart");
                int index = Exists(cart, id, s);
                if (index != -1)
                {
                    cart[index].SoLuong = sl;
                }
                Models.SessionExtensions.Set(HttpContext.Session, "cart", cart);
           
            return RedirectToAction("Index");
        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}