using System.ComponentModel.DataAnnotations;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.YonetimArea.Models.ViewModels.PersonelVM
{
    public class PersonelCreateVM
    {
        [StringLength(50)]
        public string? Adi { get; set; }

        [StringLength(50)]
        public string? Soyadi { get; set; }
        public string? BirimAdi { get; set; }
    }
}
