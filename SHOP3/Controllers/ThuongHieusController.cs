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
    public class ThuongHieusController : Controller
    {
        private readonly MyDbContext _context;

        public ThuongHieusController(MyDbContext context)
        {
            _context = context;
        }
        // GET: ThuongHieus
        public IActionResult Index()
        {
            var t = _context.ThuongHieus.ToList();
            return View(t);
        }

        // GET: ThuongHieus/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ThuongHieus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThuongHieus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTH,TenTH")] ThuongHieu thuongHieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuongHieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thuongHieu);
        }

        private bool ThuongHieuExists(int id)
        {
            return _context.ThuongHieus.Any(e => e.MaTH == id);
        } 

        // GET: ThuongHieus/Edit/5
        public IActionResult Edit(int id)
        {
            ThuongHieu thuongHieu = _context.ThuongHieus.Where(p => p.MaTH == id).First();

            return View(thuongHieu);
        }

        // POST: ThuongHieus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTH,TenTH")] ThuongHieu thuongHieu)
        {
            if (id != thuongHieu.MaTH)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(thuongHieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuongHieuExists(thuongHieu.MaTH))
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
         

            return View(thuongHieu);
        }

        // GET: ThuongHieus/Delete/5
        [HttpGet]
        public async Task<ActionResult<ThuongHieu>> Delete(int id)
        {
            var thuongHieu = await _context.ThuongHieus.FindAsync(id);
            if (thuongHieu == null)
            {
                return NotFound();
            }

            _context.ThuongHieus.Remove(thuongHieu);
            await _context.SaveChangesAsync();

            return thuongHieu;
        }
        
       
    }
}