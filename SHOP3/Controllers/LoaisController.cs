using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHOP3.Models;


namespace SHOP3.Controllers
{
    public class LoaisController : Controller
    {
        private readonly MyDbContext _context;

        public LoaisController(MyDbContext context)
        {
            _context = context;
        }
        // GET: Loais
        public IActionResult Index()
        {
            var l = _context.Loais.ToList();
            return View(l);
        }

        // GET: Loais/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Loais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,TenLoai")] Loai loai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loai);
        }

        // GET: Loais/Edit/5
        public IActionResult Edit(int id)
        {
            Loai l = _context.Loais.Where(p => p.MaLoai == id).First();
            return View(l);
        }

        // POST: Loais/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLoai, TenLoai")] Loai loai)
        {
            if (id != loai.MaLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(loai);
                    await _context.SaveChangesAsync();
                    HttpContext.Session.Set("MaLoai", loai);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiExists(loai.MaLoai))
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

            return View(loai);
        }

        // GET: Loais/Delete/5
        [HttpGet]
        public async Task<ActionResult<Loai>> Delete(int id)
        {
            var loai = await _context.Loais.FindAsync(id);
            if (loai == null)
            {
                return NotFound();
            }

            _context.Loais.Remove(loai);
            await _context.SaveChangesAsync();

            return loai;
        }
        private bool LoaiExists(int id)
        {
            return _context.Loais.Any(e => e.MaLoai == id);
        }
    }
}