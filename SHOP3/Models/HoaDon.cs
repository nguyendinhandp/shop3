using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP3.Models
{
    
    public class HoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHD { get; set; }

        public int MaKhachHang { get; set; }
        
        public ThanhVien ThanhVien { get; set; }

        public DateTime NgayTao { get; set; }

        public bool XacNhan { get; set; }

        public ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }
       

    }
}
