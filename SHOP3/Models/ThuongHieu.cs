using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SHOP3.Models
{
    public class ThuongHieu
    {
        [Key]
        public int MaTH { get; set; }
        public string TenTH { get; set; }

        public string TenTHTk
        {
            get
            {
                return Helper.FriendlyUrlHelper.Change(TenTH);
            }
        }
    }
}
