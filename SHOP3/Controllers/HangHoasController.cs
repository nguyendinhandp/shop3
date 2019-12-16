using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using SHOP3.Models;

namespace SHOP3.Controllers
{
    public class HangHoasController : Controller
    {
        private readonly MyDbContext _context;

        public HangHoasController(MyDbContext context)
        {
            _context = context;
        }
        // GET: HangHoas
        public IActionResult Index()
        {
            var hh = _context.HangHoas.ToList();

            return View(hh);
        }

        

        // GET: HangHoas/Create
        public IActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "TenLoai");
            ViewData["MaTH"] = new SelectList(_context.ThuongHieus, "MaTH", "TenTH");

            return View();
        }

        // POST: HangHoas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHh,TenHh,MaLoai,DonGia,Hinh,MoTa,GiamGia,MaTH")] HangHoa hangHoa, IFormFile[] myfile)
        {
            if (ModelState.IsValid)
            {
                string arr = "";

                if (myfile != null)
                {
                    foreach (var item in myfile)
                    {
                        string url = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", item.FileName);
                        using (var f = new FileStream(url, FileMode.Create))
                        {
                            item.CopyTo(f);
                        }
                        arr += item.FileName;
                    }
                    hangHoa.Hinh = arr;
                }
                _context.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "MaLoai", hangHoa.MaLoai);
            ViewData["MaTH"] = new SelectList(_context.ThuongHieus, "MaTH", "TenTH", hangHoa.MaTH);
            return View(hangHoa);
        }

        // GET: HangHoas/Edit/5
        public IActionResult Edit(int id)
        {
            HangHoa hh = _context.HangHoas.Where(p => p.MaHh == id).First();

            ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "MaLoai", hh.MaLoai);
            ViewData["MaTH"] = new SelectList(_context.ThuongHieus, "MaTH", "TenTH", hh.MaTH);

            return View(hh);
        }

        // POST: HangHoas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHh,TenHh,MaLoai,DonGia,Hinh,MoTa,GiamGia,MaTH")] HangHoa hangHoa, IFormFile[] myfile)
        {
            if (id != hangHoa.MaHh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string arr = "";

                    if (myfile != null)
                    {
                        foreach (var item in myfile)
                        {
                            string url = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", item.FileName);
                            using (var f = new FileStream(url, FileMode.Create))
                            {
                                item.CopyTo(f);
                            }
                            arr += item.FileName;
                        }
                        hangHoa.Hinh = arr;
                    }
                    _context.Update(hangHoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangHoaExists(hangHoa.MaHh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "MaLoai", hangHoa.MaLoai);
            ViewData["MaTH"] = new SelectList(_context.ThuongHieus, "MaTH", "TenTH", hangHoa.MaTH);

            return View(hangHoa);
        }
        private bool HangHoaExists(int id)
        {
            return _context.HangHoas.Any(e => e.MaHh == id);
        }

        [HttpGet]
        public async Task<ActionResult<HangHoa>> Delete(int id)
        {
            var hangHoa = await _context.HangHoas.FindAsync(id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            _context.HangHoas.Remove(hangHoa);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "HangHoas");
        }

        // GET: HangHoas/Details/5
        [Route("{id}")]
        public IActionResult Details(string id)
        {

            ChiTietHH model = new ChiTietHH();
            List<HangHoa> dshhcl = new List<HangHoa>();
            List<HangHoa> dshhcth = new List<HangHoa>();
            HangHoa hh = new HangHoa();

            if (id != null)
            {
                hh = _context.HangHoas.SingleOrDefault(p => p.Url == id);

            }
            else
            {
                hh = _context.HangHoas.SingleOrDefault(p => p.MaHh == HttpContext.Session.Get<int>("MaHh"));

            }
            dshhcl = _context.HangHoas.Where(p => p.MaLoai == hh.MaLoai).ToList();
            dshhcth = _context.HangHoas.Where(p => p.MaTH == hh.MaTH).ToList();

            model.HH = hh;
            model.HHCungTH = dshhcth;
            model.HHCungLoai = dshhcl;
            

            return View(model);
        }

        [Route("giay-da")]
        public IActionResult ShowGiayDa()
        {

            return View();
        }
        [Route("giay-the-thao")]
        public IActionResult ShowGiayTheThao()
        {

            return View();
        }
        [Route("giay-da-bong")]
        public IActionResult ShowGiayDaBong()
        {

            return View();

        }
        

    }
}