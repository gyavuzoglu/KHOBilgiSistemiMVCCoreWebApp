using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KHOBilgiSistemiMVCCoreWebApp.Controllers
{
    public class KullanicilarController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserTbl p)
        {
            Context c = new Context();
            UsersManager usersm = new UsersManager(new EfUserRepository());
            var deneme=usersm.GetByID(1);
            var datavalue=c.UserTbl.FirstOrDefault(x=>x.UserTC==p.UserTC && x.Password==p.Password);
            if (datavalue != null)
            {
                var claims = new List<Claim> 
                //Claim oturum açan kullanıcı hakkında rollerin dışında kullanıcı hakkında bilgi tutmamızı ve bu bilgilere göre yetkilendirme yapmamızı sağlayan yapılardır.
                {
                    new Claim(ClaimTypes.Name,p.UserTC)
                };
                var useridentity=new ClaimsIdentity(claims,"a"); //a ne işe yarıyor?
                ClaimsPrincipal principal=new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Birimler");
            }
            else { 
                return View(); 
            }

        }
    }
}
