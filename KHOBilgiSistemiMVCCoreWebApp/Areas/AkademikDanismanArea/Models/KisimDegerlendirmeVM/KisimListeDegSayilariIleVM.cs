namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.KisimDegerlendirmeVM
{
    public class KisimListeDegSayilariIleVM
    {
        public string? KisimAdi { get; set; }
        public int? BolumID { get; set; }
        public string? BolumAdi { get; set; }
        public string? BolumAdiKisa { get; set; }
        public int? EOYiliID { get; set; }
        public string? EOYili { get; set; }
        public int? Donem { get; set; }
        public int KisimToplamDegAdedi { get; set; }
        public int KisimOgretmeninDegAdedi { get; set; }
    }
}
