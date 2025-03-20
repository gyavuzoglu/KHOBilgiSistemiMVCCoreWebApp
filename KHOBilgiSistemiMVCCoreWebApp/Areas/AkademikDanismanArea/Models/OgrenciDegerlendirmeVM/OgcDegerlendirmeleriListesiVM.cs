using EntityLayer.Concrete;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.OgrenciDegerlendirmeVM
{
    public class OgcDegerlendirmeleriListesiVM
    {
        public int EOYiliID { get; set; }
        public string? EOYili { get; set; }
        public int Donem { get; set; }
        public string? DonemAdi { get; set; }
        public string? KisimAdi { get; set; }
        public int Sinif { get; set; }


        public long PerID { get; set; }
        public long OgrenciID { get; set; }
        public int BolumID { get; set; }
        public string? BolumAdi { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public int? YakaNo { get; set; }
        public string? FotografAdresi { get; set; }
        
        public List<OgcDegerlendirmeListVM>? OgrenciDegListe { get; set; }

    }
}
