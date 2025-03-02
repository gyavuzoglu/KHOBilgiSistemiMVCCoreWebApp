using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Controllers
{
    [Authorize(Roles = "Akademik Danışman")]
    public class AkademikDanismanController : Controller
    {
        private readonly SignInManager<AppUserTbl> _signInManager;

        public AkademikDanismanController(SignInManager<AppUserTbl> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");

            ViewBag.RoleName = RoleName;
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
