using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.OgrenciDegerlendirmeVM
{
    public class DegerlendirmeClassVM

    {
        public int EOYiliID { get; set; }
        public string? EOYili { get; set; }
        public int Donem { get; set; }
        public int Sinif { get; set; }
        public string? KisimAdi { get; set; }

        public long PerID { get; set; }
        public long OgrenciID { get; set; }
        public int BolumID { get; set; }
        public string? BolumAdiKisa { get; set; }
        public string? BolumAdi { get; set; }

        public int YakaNo { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public string? FotografAdresi { get; set; }

        public long DegId { get; set; }
        public int DegTurID { get; set; }
        public DateTime TarihSaat { get; set; }
        public string? Degerlendirme { get; set; }
        
        public IEnumerable<SelectListItem>? OgrenciDegerlendirmeTurleriListe { get; set; }


    }
}
