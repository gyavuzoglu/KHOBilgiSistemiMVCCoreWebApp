namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.OgrenciDegerlendirmeVM
{
    public class DegListOnBilgiVM
    {
        public int Sinif { get; set; }
        public int EOYiliID { get; set; }
        public int Donem { get; set; }
        public string KisimAdi { get; set; }

        //public string DonemAdi { get; set; }
        //public string EOYili { get; set; }

        public long PerID { get; set; }
        public long OgrenciID { get; set; }

        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
