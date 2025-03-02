namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models
{
    public class OgcDegerlendirmeKayitClass
    {

        public long PerID { get; set; }
        public int EOYiliID { get; set; }
        public int Donem { get; set; }
        public long OgrenciID { get; set; }
        public int DegTurID { get; set; }
        public DateTime TarihSaat { get; set; }
        public string? Degerlendirme { get; set; }
        public int Sinif { get; set; }
        public string KisimAdi { get; set; }
        
        
    }
}
