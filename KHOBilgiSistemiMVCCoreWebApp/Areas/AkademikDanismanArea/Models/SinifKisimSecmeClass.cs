using Microsoft.AspNetCore.Mvc.Rendering;
using EntityLayer.Concrete;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models
{
    public class SinifKisimSecmeClass
    {
        public IEnumerable<SelectListItem> SiniflarTbl { get; set; }
        public IEnumerable<SelectListItem> KisimlarTbl { get; set; }
        public int Sinif { get; set; }
        public string KisimAdi { get; set; }
        public string EOYiliID { get; set; }
        public string Donem { get; set; }

    }
}
