namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.KisimDegerlendirmeVM
{
    public class KisimDegUpdateClassVM
    {
        public long PerID { get; set; }
        public string? KisimAdi { get; set; }
        public DateTime TarihSaat { get; set; }
        public string? KisimDegerlendirme { get; set; }
        public int EOYiliID { get; set; }
        public int Donem { get; set; }
        public int BolumID { get; set; }
        public string? BolumAdi { get; set; }
    }
}
