namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models
{
    public class OgrenciDegerlendirmeleriListelemeSartlari
    {
        public long PerID { get; set; }
        public int EOYiliID { get; set; }
        public int Donem { get; set; }
        public long OgrenciID { get; set; }
        public int Sinif { get; set; }
        public string? KisimAdi { get; set; }
        public string? OgrAdi { get; set; }
        public string? OgrSoyadi { get; set; }
        public int? YakaNo { get; set; }
        public string? FotografAdresi { get; set; }

    }
}
