using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using KHOBilgiSistemiMVCCoreWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KHOBilgiSistemiMVCCoreWebApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUserTbl> _signInManager;
      
         
        public LoginController(SignInManager<AppUserTbl> signInManager)
        {
            _signInManager = signInManager;

        }
              

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, false, true);
                //sondaki true kullanıcı 5 defa yanlış giriş yaparsa bir süre engellemek için
                

                if (result.Succeeded)
                {
                   
                    return RedirectToAction("Index", "Home");
                }
                
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Login");
        }
    }
}
