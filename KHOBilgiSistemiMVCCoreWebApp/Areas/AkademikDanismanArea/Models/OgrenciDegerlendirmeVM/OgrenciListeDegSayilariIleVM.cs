namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.OgrenciDegerlendirmeVM
{
    public class OgrenciListeDegSayilariIleVM
    {
        public long OgrenciID { get; set; }
        public int? YakaNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string FotografAdresi { get; set; }
        public int OgcToplamDegAdedi { get; set; }
        public int OgcOgretmeninDegAdedi { get; set; }
    }
}
