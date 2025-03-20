using Microsoft.AspNetCore.Mvc.Rendering;
using EntityLayer.Concrete;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.OgrenciDegerlendirmeVM
{
    public class OgrenciGetirFormVM
    {
        public IEnumerable<SelectListItem> SiniflarListe { get; set; }
        public IEnumerable<SelectListItem> KisimlarListe { get; set; }
        public IEnumerable<SelectListItem> EOYiliListe { get; set; }
        public IEnumerable<SelectListItem> DonemlerListe { get; set; }
        public int Sinif { get; set; }
        public string KisimAdi { get; set; }
        public int EOYiliID { get; set; }
        public int Donem { get; set; }
        public long PerID { get; set; }
        public int BolumID { get; set; }




    }
}
