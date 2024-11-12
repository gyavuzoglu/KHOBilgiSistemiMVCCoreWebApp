using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Controllers
{
    [Authorize(Roles = "Yönetici")]
    public class YoneticiController : Controller
    {
        private readonly SignInManager<AppUserTbl> _signInManager;

        public YoneticiController(SignInManager<AppUserTbl> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName=RoleName;
            ViewBag.UserName = UserName;
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
