using Microsoft.AspNetCore.Mvc.Rendering;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.KisimDegerlendirmeVM
{
    public class KisimGetirFormVM
    {
        public IEnumerable<SelectListItem> SiniflarListe { get; set; }
        public IEnumerable<SelectListItem> EOYiliListe { get; set; }
        public IEnumerable<SelectListItem> DonemlerListe { get; set; }
        public int Sinif { get; set; }
        public int EOYiliID { get; set; }
        public int Donem { get; set; }
        public string KisimAdi { get; set; }
        public long PerID { get; set; }
        
    }
}
