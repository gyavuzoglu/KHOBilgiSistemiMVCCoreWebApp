using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models
{
    public class DegerlendirmeGirisClass
    {
        public long PerID { get; set; }
        public long OgrenciId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int Sinif { get; set; }
        public string KisimAdi { get; set; }
        public int EOYiliID { get; set; }
        public string EOYili { get; set; }
        public int Donem { get; set; }
        public string Fotograf { get; set; }
        public int DegTurID { get; set; }
        public string Degerlendirme { get; set; }
        public IEnumerable<SelectListItem> OgrenciDegerlendirmeTurleriListe { get; set; }
        public List<OgrenciDegerlendirmeleriTbl> OgrenciDegerlendirmeleriListe { get; set; }
        public OgrenciDegerlendirmeleriTbl OgrenciDegerlendirmeleriTbl { get; set; }


    }
}
