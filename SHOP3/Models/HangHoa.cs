using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SHOP3.Helper;
using SHOP3.Models;

namespace SHOP3.Models
{
    public class HangHoa
    {
        [Key]
        public int MaHh { get; set; }

        public string TenHh { get; set; }

        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }

        public int MaTH { get; set; }
        [ForeignKey("MaTH")]
        public ThuongHieu ThuongHieu { get; set; }

        public string Hinh { get; set; }

        public double DonGia { get; set; }

        public string MoTa { get; set; }
        public double GiamGia { get; set; }
        public double Price => DonGia * (1 - GiamGia);

        public string Url
        {
            get
            {
                return Helper.FriendlyUrlHelper.GetFriendlyTitle(TenHh);
            }
        }
        public string TenHhTk
        {
            get
            {
                return Helper.FriendlyUrlHelper.Change(TenHh);
            }
        }
        public string image
        {
            get
            {
                string imagelink = "http://www.shop3.somee.com/images/" + Hinh;
                return imagelink;
            }
        }

    }
}
