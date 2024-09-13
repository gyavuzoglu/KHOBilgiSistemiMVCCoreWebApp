using System.ComponentModel.DataAnnotations;

namespace KHOBilgiSistemiMVCCoreWebApp.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = ("Lütfen kullanıcı adınızı giriniz."))]
        [Display(Name ="TC Kimlik Numaranız")]
        [StringLength(11)]
        public string UserName { get; set; }

        [Required(ErrorMessage = ("Lütfen şifrenizi giriniz."))]
        [DataType(DataType.Password)]
        [Display(Name ="Şifreniz")]
        public string Password { get; set; }
    }
}
