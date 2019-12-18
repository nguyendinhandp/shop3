using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace SHOP3.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions options) : base(options)
        {

        }


        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<ThuongHieu> ThuongHieus { get; set; }


        public virtual DbSet<ThanhVien> ThanhViens { get; set; }
        public virtual DbSet<Loai> Loais { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("workstation id=SHOP3DB.mssql.somee.com;packet size=4096;user id=shop3_SQLLogin_1;pwd=qcmusmkztn;data source=SHOP3DB.mssql.somee.com;persist security info=False;initial catalog=SHOP3DB");
              // optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SHOP3;Integrated Security=True");
            }
        }

        internal Task SignInAsync(string authenticationScheme, ClaimsPrincipal claimsPrincipal)
        {
            throw new NotImplementedException();
        }
    }
}
