﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SHOP3.Models;

namespace SHOP3.Controllers
{
    public class ThanhViensController : Controller
    {
        private MyDbContext _context;

        public ThanhViensController()
        {
            _context = new MyDbContext();
        }
        // GET: ThanhViens
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("MaTv") == null) return RedirectToAction("Login", "ThanhViens");

            var tv = _context.ThanhViens.ToList();
            return View(tv);
        }

        // GET: ThanhViens/Details/5
        public IActionResult Details(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var thanhVien = _context.ThanhViens.SingleOrDefault(m => m.MaTv == id);
            if (thanhVien == null) return NotFound();

            return View(thanhVien);
        }

        // GET: ThanhViens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThanhViens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ThanhVien>> Create([Bind("MaTv,TenTv,GioiTinh,NgaySinh,DiaChi,DienThoai,Email,LoaiTv,TaiKhoan,MatKhau")] ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                thanhVien.LoaiTv = 2;
                _context.Add(thanhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login), "ThanhViens");
            }

            return View(thanhVien);
        }

        // GET: ThanhViens/Edit/5
        public IActionResult Edit(int id)
        {
            ThanhVien tv = _context.ThanhViens.Where(p => p.MaTv == id).First();

            return View(tv);
        }

        // POST: ThanhViens/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTv,TenTv,GioiTinh,NgaySinh,DiaChi,LoaiTv,DienThoai,Email,TaiKhoan,MatKhau")] ThanhVien thanhVien)
        {
            if (id != thanhVien.MaTv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thanhVien);
                    await _context.SaveChangesAsync();
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThanhVienExists(thanhVien.MaTv))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }

            return View(thanhVien);
        }
        private bool ThanhVienExists(int id)
        {
            return _context.ThanhViens.Any(e => e.MaTv == id);
        }

        // GET: ThanhViens/Delete/5
        [HttpGet]
        public async Task<ActionResult<ThanhVien>> Delete(int id)
        {
            var thanhVien = await _context.ThanhViens.FindAsync(id);
            if (thanhVien == null)
            {
                return NotFound();
            }

            _context.ThanhViens.Remove(thanhVien);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "ThanhViens");
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(ThanhVien Model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            ThanhVien tv = (from ThanhVien in _context.ThanhViens
                        where ThanhVien.TaiKhoan == Model.TaiKhoan && ThanhVien.MatKhau == Model.MatKhau
                        select new ThanhVien
                        {
                            TenTv = ThanhVien.TenTv,
                            MaTv = ThanhVien.MaTv,
                            TaiKhoan = ThanhVien.TaiKhoan,
                            MatKhau = ThanhVien.MatKhau,
                            LoaiTv = ThanhVien.LoaiTv
                        }).SingleOrDefault();
            if (tv == null)
            {
                ModelState.AddModelError("", "Sai Tài khoản hoặc Mật khẩu");
                return View();
            }
            else
            {
                HttpContext.Session.SetInt32("MaTv", tv.MaTv);
                HttpContext.Session.SetString("TaiKhoan", tv.TaiKhoan);
                HttpContext.Session.SetString("MatKhau", tv.MatKhau);
                HttpContext.Session.SetInt32("LoaiTv", tv.LoaiTv);
                HttpContext.Session.SetString("TenTv", tv.TenTv);
            }
            return RedirectToAction("Details", "ThanhViens", new { id = tv.MaTv });

        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("MaTv");
            HttpContext.Session.Remove("TaiKhoan");
            HttpContext.Session.Remove("MatKhau");
            HttpContext.Session.Remove("LoaiTv");
            HttpContext.Session.Remove("TenTv");
            return RedirectToAction("Index", "Home");
        }

      
        public IActionResult Admin()
        {
            List<ThanhVien> Dstv = new List<ThanhVien>();
            Dstv = _context.ThanhViens.Where(h => h.LoaiTv == 1).ToList();
            return View(Dstv.Select(h => new ThanhVien
            {
                TenTv = h.TenTv,
                MaTv = h.MaTv,
                GioiTinh = h.GioiTinh,
                NgaySinh = h.NgaySinh,
                DiaChi = h.DiaChi,
                DienThoai = h.DienThoai,
                Email = h.Email,

                LoaiTv = h.LoaiTv,
                TaiKhoan = h.TaiKhoan,
                MatKhau = h.MatKhau
            }));
        }

        public IActionResult TKAdmin()
        {
            return View();
        }

        public IActionResult TKKhachHang()
        {
            return View();
        }
    }
}