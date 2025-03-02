using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models
{
    public class KisimOgrenciListeClass
    {
        public List<OgrencilerTbl> OgrencilerListe { get; set; }
        public int SelectedSinif { get; set; }
        public int SelectedEOYili { get; set; }
        public int SelectedDonem { get; set; }
        public string SelectedKisimAdi { get; set; }
        public long PerID { get; set; }
    }
}
