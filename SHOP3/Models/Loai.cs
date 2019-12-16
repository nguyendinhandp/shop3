using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SHOP3.Helper;
namespace SHOP3.Models
{
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }

        public string TenLoai { get; set; }

        public string TenLoaiTk
        {
            get
            {
                return Helper.FriendlyUrlHelper.Change(TenLoai);
            }
        }
    }
}
