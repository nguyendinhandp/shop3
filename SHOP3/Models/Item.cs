using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP3.Models
{
    public class Item
    {
        public string Hinh { get; set; }
        public int MaHh { get; set; }
        public string TenHh { get; set; }
        public double DonGia{ get; set; }
        public int SoLuong { get; set; }
        public int Size { get; set; }
        public double ThanhTien
        {
            get
            {
                return DonGia * SoLuong;
            }
        }
        public string Url
        {
            get
            {
                return Helper.FriendlyUrlHelper.GetFriendlyTitle(TenHh);
            }
        }
    }
}
