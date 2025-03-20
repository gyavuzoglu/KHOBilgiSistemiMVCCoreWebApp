namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.OgrenciDegerlendirmeVM
{
    public class TumOgcDegListelemeVM
    {
        public long PerID { get; set; }

        public int EOYiliID { get; set; }
        public string? EOYili { get; set; }
        public int Donem { get; set; }
        public string? DonemAdi { get; set; }
        
        public List<TumOgcDegListeFormVM>? TumOgrenciDegListe { get; set; }


    }
}
