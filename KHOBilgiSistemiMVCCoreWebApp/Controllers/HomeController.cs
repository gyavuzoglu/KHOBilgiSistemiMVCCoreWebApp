using EntityLayer.Concrete;
using KHOBilgiSistemiMVCCoreWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Diagnostics;

namespace KHOBilgiSistemiMVCCoreWebApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        private readonly SignInManager<AppUserTbl> _signInManager;
        private readonly UserManager<AppUserTbl> _userManager;
        private readonly RoleManager<AppRolesTbl> _roleManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(SignInManager<AppUserTbl> signInManager, UserManager<AppUserTbl> userManager, RoleManager<AppRolesTbl> roleManager, ILogger<HomeController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }



        public IActionResult Index()
        {
            ViewBag.rolelist = new SelectList(_roleManager.Roles.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            ViewBag.rolelist = new SelectList(_roleManager.Roles.ToList(), "Id", "Name");

            if (ModelState.IsValid)
            {
                AppUserTbl user=await _userManager.FindByNameAsync(p.UserName);
                if (user != null)
                {
                    var role = await _roleManager.FindByIdAsync(p.RoleID);
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        await _signInManager.SignOutAsync();
                        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, p.Password, false, true);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Birimler"); //Sonra deðiþtirilecek

                        }
                    }
                    else
                    {
                        ViewBag.Rolhatasi = "Bu rol ile giriþ yetkisine sahip deðilsiniz.";
                    }
                }
                else
                {
                    ModelState.AddModelError("NotUser", "Böyle bir kullanýcý bulunmamaktadýr.");
                    ModelState.AddModelError("NotUser2", "E-posta veya þifre yanlýþ.");
                }
            }
            return View();
            
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
