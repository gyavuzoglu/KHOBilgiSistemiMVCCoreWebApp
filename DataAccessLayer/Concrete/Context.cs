using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUserTbl, AppRolesTbl,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-1T546DD\\SQLEXPRESS;database=KHOBilSisDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
         
        }
        public DbSet<AskeriSiniflarTbl> AskeriSiniflarTbl { get; set; }
        public DbSet<BolumTbl> BolumlerTbl { get; set; }
        public DbSet<BirimlerTbl> BirimlerTbl { get; set; }
        public DbSet<DerslerTbl> DerslerTbl { get; set; }
        public DbSet<EOYiliTbl> EOYiliTbl { get; set; }
        public DbSet<GorevlerTbl> GorevlerTbl { get; set; }
        public DbSet<KisimlarTbl> KisimlarTbl { get; set; }
        public DbSet<OgrenciBilgileriTbl> OgrenciBilgileriTbl { get; set; }
        public DbSet<OgrencilerTbl> OgrencilerTbl { get; set; }
        public DbSet<PersonelTbl> PersonelTbl { get; set; }
        public DbSet<RutbeTbl> RutbeTbl { get; set; }
        public DbSet<UnvanTbl> UnvanTbl { get; set; }
        public DbSet<UyrukTbl> UyrukTbl { get; set; }
        public DbSet<SiniflarTbl> SiniflarTbl { get; set; }
        public DbSet<DonemlerTbl> DonemlerTbl { get; set; }
        public DbSet<AkademikDanismanlarTbl> AkademikDanismanlarTbl { get; set; }
        public DbSet<OgrenciDegerlendirmeleriTbl> OgrenciDegerlendirmeleriTbl { get; set; }
        public DbSet<OgrenciDegerlendirmeTurleriTbl> OgrenciDegerlendirmeTurleriTbl { get; set; }
        public DbSet<KisimDegerlendirmeleriTbl> KisimDegerlendirmeleriTbl { get; set; }
       





    }
}
