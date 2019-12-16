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
            var n = _context.ThuongHieus.ToList();
            return View(n);
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
        public async Task<ActionResult<ThuongHieu>> Create(ThuongHieu thuongHieu)
        {
            _context.ThuongHieus.Add(thuongHieu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThuongHieu", new { id = thuongHieu.MaTH }, thuongHieu);
        }

        private bool ThuongHieuExists(int id)
        {
            return _context.ThuongHieus.Any(e => e.MaTH == id);
        } 

        // GET: ThuongHieus/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: ThuongHieus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ThuongHieu thuongHieu)
        {
            if (id != thuongHieu.MaTH)
            {
                return BadRequest();
            }

            _context.Entry(thuongHieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuongHieuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // GET: ThuongHieus/Delete/5
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