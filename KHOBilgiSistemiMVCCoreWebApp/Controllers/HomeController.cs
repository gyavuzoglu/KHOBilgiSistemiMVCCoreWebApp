using EntityLayer.Concrete;
using KHOBilgiSistemiMVCCoreWebApp.Models;
using KHOBilgiSistemiMVCCoreWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

                AppUserTbl user = await _userManager.FindByNameAsync(p.UserName);
                if (user != null)
                {
                    if (user.UserName == p.UserName)
                    {
                        
                        var pk=_userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, p.Password);
                        if (pk==PasswordVerificationResult.Success)
                        {
                            var role = await _roleManager.FindByIdAsync(p.RoleID);
                            if (await _userManager.IsInRoleAsync(user, role.Name))
                            {
                                await _signInManager.SignOutAsync();
                                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, p.Password, false, true);
                                if (result.Succeeded)
                                {

                                    HttpContext.Session.SetString("PerTC", p.UserName);
                                    HttpContext.Session.SetString("UserName", user.Adi + " " + user.Soyadi);
                                    HttpContext.Session.SetString("RoleName", role.Name);
                                    if (p.RoleID=="1")  //Öðrenci rolü ise
                                    {
                                        return RedirectToAction("Index", "Ogrenci");
                                    }
                                    if (p.RoleID == "15")  //Yonetici rolü ise
                                    {
                                        return RedirectToAction("Index", "Yonetici");
                                    }
                                    if (p.RoleID == "7")  //Akademik Danýþman rolü ise
                                    {
                                        return RedirectToAction("Index", "AkademikDanisman");
                                    }
                                    if (p.RoleID == "18")  //Yoklama Kayýt rolü ise
                                    {
                                        return RedirectToAction("Index", "YoklamaKayit");
                                    }

                                    //Profile göre Menüsü ve Ýlk Ekraný gelecek
                                }
                            }
                            else
                            {

                                ModelState.AddModelError("", "Bu rol ile giriþ yetkisine sahip deðilsiniz.");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Þifrenizi yanlýþ girdiniz.");
                        }
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Böyle bir kullanýcý bulunmamaktadýr.");
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
