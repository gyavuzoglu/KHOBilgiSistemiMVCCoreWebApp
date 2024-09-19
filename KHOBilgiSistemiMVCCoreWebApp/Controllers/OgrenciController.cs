using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Controllers
{
    [Authorize(Roles = "Öğrenci")]
    public class OgrenciController : Controller
    {
        private readonly SignInManager<AppUserTbl> _signInManager;

        public OgrenciController(SignInManager<AppUserTbl> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            ViewBag.RoleName = "Öğrenci";
            ViewBag.UserName = TempData["UserName"];
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
