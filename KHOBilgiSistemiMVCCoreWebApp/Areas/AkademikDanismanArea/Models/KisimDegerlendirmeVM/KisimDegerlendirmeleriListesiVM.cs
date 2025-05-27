using KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.KisimDegerlendirmeVM;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.KisimDegerlendirmeVM
{
    public class KisimDegerlendirmeleriListesiVM
    {
        public int EOYiliID { get; set; }
        public string? EOYili { get; set; }
        public int Donem { get; set; }
        public string? DonemAdi { get; set; }
        public int? Sinif { get; set; }
        public string? KisimAdi { get; set; }


        public long PerID { get; set; }
        public int BolumID { get; set; }
        public string? BolumAdi { get; set; }
        public List<KisimDegerlendirmeListVM>? KisimDegListe { get; set; }
    }
}
