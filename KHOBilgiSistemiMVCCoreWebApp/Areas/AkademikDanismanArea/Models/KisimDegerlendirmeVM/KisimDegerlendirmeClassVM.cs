using Microsoft.AspNetCore.Mvc.Rendering;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.KisimDegerlendirmeVM
{
    public class KisimDegerlendirmeClassVM
    {
        public long PerID { get; set; }
        public int EOYiliID { get; set; }
        public string? EOYili { get; set; }
        public int Donem { get; set; }
        public int Sinif { get; set; }
        public string? KisimAdi { get; set; }
        public int BolumID { get; set; }
        public string? BolumAdiKisa { get; set; }
        public string? BolumAdi { get; set; }

        public long KisimDegId { get; set; }
        public DateTime TarihSaat { get; set; }
        public string? KisimDegerlendirme { get; set; }
               
    }
}
