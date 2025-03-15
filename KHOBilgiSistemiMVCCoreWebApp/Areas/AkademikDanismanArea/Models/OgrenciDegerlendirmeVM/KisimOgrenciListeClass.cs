using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.OgrenciDegerlendirmeVM
{
    public class KisimOgrenciListeClass
    {
        public List<OgrenciListeDegSayilariIleVM> OgrenciListe { get; set; }
        public int Sinif { get; set; }
        public int EOYiliID { get; set; }
        public string? EOYili { get; set; }
        public int Donem { get; set; }
        public string? DonemAdi { get; set; }
        public string? KisimAdi { get; set; }
        public long PerID { get; set; }
 
        public string RoleName { get; set; }
        public string UserName { get; set; }
       

    }
}
