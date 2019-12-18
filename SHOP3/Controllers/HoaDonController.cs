using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SHOP3.Common;
using SHOP3.Models;

namespace SHOP3.Controllers
{
    [Route("HoaDon")]
    public class HoaDonController : Controller
    {
        public HoaDonController()
        {
            if (_context == null) _context = new MyDbContext();
        }
        private static MyDbContext _context { get; set; }

        [HttpGet]
        [Route("Detail")]
        [Auth]
        public IEnumerable<dynamic> Detail(int maHD)
        {
            var hoaDon = _context
                .ChiTietHoaDon
                .Where(x => x.MaHD.Equals(maHD))
                .Join(
                    _context.HangHoas,
                    hd => hd.MaHH,
                    hh => hh.MaHh,
                    (hd, hh) => new ChiTietHoaDon
                    {
                        Gia = hd.Gia,
                        MaHD = hd.MaHD,
                        MaHH = hd.MaHH,
                        HangHoa = hh,
                        SoLuong = hd.SoLuong
                    }
                )
                .ToList();
            return hoaDon;
        }

        [HttpGet]
        [Route("XacNhan")]
        [Auth]
        public async Task<IActionResult> XacNhan(int? MaHD, int? MaKH)
        {
            if(MaHD != null && MaKH != null)
            {
                var hd = new HoaDon
                {
                    MaHD = MaHD.Value,
                    XacNhan = true,
                    MaKhachHang = MaKH.Value
                };
                _context.HoaDon.Update(hd);
                await _context.SaveChangesAsync();
            }
            return Redirect("/HoaDon/Index");
        }

        [HttpGet]
        [Route("Xoa")]
        [Auth]
        public async Task<IActionResult> Xoa(int? MaHD)
        {
            if(MaHD != null)
            {
                var hd = new HoaDon
                {
                    MaHD = MaHD.Value,
                    XacNhan = false,
                    MaKhachHang = -1
                };
                _context.HoaDon.Update(hd);
                await _context.SaveChangesAsync();
            }
            return Redirect("/HoaDon/Index");
        }


        [HttpGet]
        [Route("Index")]
        [Auth]
        public async Task<IActionResult> Index()
        {
            var hoaDon = _context.HoaDon.Join(
                _context.ThanhViens,
                hd => hd.MaKhachHang,
                tv => tv.MaTv,
                (hd, tv) => new HoaDon
                {
                    ThanhVien = tv,
                    MaHD = hd.MaHD,
                    MaKhachHang = hd.MaKhachHang,
                    NgayTao = hd.NgayTao,
                    XacNhan = hd.XacNhan
                }
                ).ToList();
            foreach (var item in hoaDon)
            {
                item.ChiTietHoaDon = _context.ChiTietHoaDon.Where(x => x.MaHD == item.MaHD).ToList();
            }
            this.ViewBag.HoaDon = hoaDon;
            return View();
        }
    }
}