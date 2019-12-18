using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP3.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int MaHD { get; set; }
        [Key]
        public int MaHH { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }

        [ForeignKey("MaHD")]
        public HoaDon HoaDon { get; set; }
        [ForeignKey("MaHH")]
        public HangHoa HangHoa { get; set; }
    }
}
