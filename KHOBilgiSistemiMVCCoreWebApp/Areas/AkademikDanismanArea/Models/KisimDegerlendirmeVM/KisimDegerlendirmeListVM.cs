namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.KisimDegerlendirmeVM
{
    public class KisimDegerlendirmeListVM
    {
        public long KisimDegerlendirmeID { get; set; }
        public long PerID { get; set; }
        public int EOYiliID { get; set; }
        public int Donem { get; set; }
        public string? KisimAdi { get; set; }
        public int BolumID { get; set; }
        public string? BolumAdiKisa { get; set; }
        public string? BolumAdi { get; set; }
        public DateTime TarihSaat { get; set; }
        public string? KisimDegerlendirme { get; set; }

    }
}
