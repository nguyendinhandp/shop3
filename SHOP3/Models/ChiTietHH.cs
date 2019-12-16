using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHOP3.Models;

namespace SHOP3.Models
{
    public class ChiTietHH
    {
        public HangHoa HH { get; set; }
        public List<HangHoa> HHCungLoai{ get; set; }
        public List<HangHoa> HHCungTH { get; set; }
    }
}
