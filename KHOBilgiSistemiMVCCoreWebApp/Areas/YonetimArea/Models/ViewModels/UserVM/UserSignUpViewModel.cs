using System.ComponentModel.DataAnnotations;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.YonetimArea.Models.ViewModels.UserVM
{
    public class UserSignUpViewModel
    {
        [Required(ErrorMessage = "Lütfen Adı giriniz.")]
        [Display(Name = "Adı")]
        public string? Adi { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadı giriniz.")]
        [Display(Name = "Soyadı")]
        public string? Soyadi { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adı olarak TC Numaranızı giriniz.")]
        [Display(Name = "TC Kimlik Numarası")]
        [StringLength(11)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre giriniz.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi tekrar giriniz.")]
        [DataType(DataType.Password)]
        [Display(Name = "Tekrar Şifre")]
        [Compare("Password", ErrorMessage = "Girdiğiniz şifreler birbiriyle uyuşmuyor.")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen E-mail Adresi giriniz.")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

    }
}
