namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.OgrenciDegerlendirmeVM
{
    public class TumOgcDegListeFormVM
    {
        public long OgrenciID { get; set; }
        public int Sinif { get; set; }
        public string? KisimAdi { get; set; }
        public int? YakaNo { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public int? BolumID { get; set; }
        public string? BolumAdiKisa { get; set; }
        public string? FotografAdresi { get; set; }

        public long DegerlendirmeID { get; set; }
        public int DegTurID { get; set; }
        public string? TurAdi { get; set; }
        public DateTime TarihSaat { get; set; }
        public string? Degerlendirme { get; set; }
    }
}
