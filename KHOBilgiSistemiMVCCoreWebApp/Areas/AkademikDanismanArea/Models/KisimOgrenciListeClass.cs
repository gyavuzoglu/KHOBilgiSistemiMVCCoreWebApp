using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models
{
    public class KisimOgrenciListeClass
    {
        //public List<OgrencilerTbl> OgrencilerListe { get; set; }
        public long? OgrenciID { get; set; }
        public int? YakaNo { get; set; }
        public string? Adi{ get; set; }
        public string? Soyadi{ get; set; }
        public string? FotografAdresi{ get; set; }
        public int Sinif { get; set; }
        public int EOYiliID { get; set; }
        public int Donem { get; set; }
        public string? KisimAdi { get; set; }
        public long PerID { get; set; }
        public int OgrToplamDegAdedi { get; set; }
        public int OgrOgretmeninDegAdedi { get; set; }




    }
}
