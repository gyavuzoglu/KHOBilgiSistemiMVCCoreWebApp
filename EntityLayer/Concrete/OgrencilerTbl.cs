using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class OgrencilerTbl
    {
        [Key]
        public long OgrenciTC { get; set; }
        public int YakaNo { get; set; }
        public int Tabur { get; set; }
        public int Boluk { get; set; }
        
        [StringLength(5)]
        public string? KisimAdi { get; set; }
        public int Sinif { get; set; }
        public int AskeriSinifID { get; set; }
        
        [StringLength(100)]
        public string? Adi { get; set; }

        [StringLength(100)]
        public string? Soyadi { get; set; }

        public int BolumID { get;set; }
        public int UyrukID { get;set;}

        [StringLength(5)]
        public string? Cinsiyeti { get; set; }
        public bool Ayrildi { get; set; }
        public DateTime AyrilmaTarihi { get; set; }
        public bool Mezun { get; set; }
        public DateTime MezuniyetTarihi { get; set; }

        [StringLength(150)]
        public string? EPosta { get; set; }

        [StringLength(150)]
        public string? FotografAdresi { get; set; }

    }
}
