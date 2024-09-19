using System.ComponentModel.DataAnnotations;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.YonetimArea.Models.ViewModels.UserVM
{

    public class RoleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Rol Adı")]
        [Required(ErrorMessage = "Lütfen rol adını giriniz.")]
        public string? Name { get; set; }

    }
}
