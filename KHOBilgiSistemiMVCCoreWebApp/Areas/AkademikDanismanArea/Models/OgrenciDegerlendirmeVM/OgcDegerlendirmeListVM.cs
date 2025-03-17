using EntityLayer.Concrete;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.OgrenciDegerlendirmeVM
{
    public class OgcDegerlendirmeListVM
    {
        public long DegerlendirmeID { get; set; }
        public long PerID { get; set; }
        public int EOYiliID { get; set; }
        public int Donem { get; set; }
        public long OgrenciID { get; set; }
        public int DegTurID { get; set; }
        public string TurAdi { get; set; }
        public DateTime TarihSaat { get; set; }
        public string Degerlendirme { get; set; }
    }
}
