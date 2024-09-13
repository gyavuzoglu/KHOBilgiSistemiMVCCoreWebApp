using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using KHOBilgiSistemiMVCCoreWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KHOBilgiSistemiMVCCoreWebApp.Controllers
{
    [AllowAnonymous]
    //Bu sadece Admin olacak
    public class UserController : Controller
    {

        private readonly UserManager<AppUserTbl> _userManager;
        private readonly RoleManager<AppRolesTbl> _roleManager;
        private readonly IPasswordHasher<AppUserTbl> _passwordhasher;
        

        public UserController(UserManager<AppUserTbl> userManager, RoleManager<AppRolesTbl> roleManager, IPasswordHasher<AppUserTbl> passwordHasher)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordhasher = passwordHasher;
        }

        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserSignUpViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppUserTbl user = new AppUserTbl()
                {
                    Email = p.Email,
                    UserName = p.UserName,
                    Adi = p.Adi,
                    Soyadi = p.Soyadi
                };
                var result = await _userManager.CreateAsync(user, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> UserGet(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserUpdate(string id, UserSignUpViewModel p)
        {
            AppUserTbl user = await _userManager.FindByIdAsync(id);
          
            if (user != null)
            {
                if (!string.IsNullOrEmpty(p.Adi))
                {
                    user.Adi = p.Adi;
                }
                else
                {
                    ModelState.AddModelError("", "Adı boş olamaz.");
                }
                if (!string.IsNullOrEmpty(p.Soyadi))
                {
                    user.Soyadi = p.Soyadi;
                }
                else
                {
                    ModelState.AddModelError("", "Soyadı boş olamaz.");
                }
                if (!string.IsNullOrEmpty(p.UserName))
                {
                    user.UserName = p.UserName;
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı boş olamaz.");
                }
                if (!string.IsNullOrEmpty(p.Email))
                {
                    user.Email = p.Email;
                }
                else
                {
                    ModelState.AddModelError("", "E-Posta adresi boş olamaz.");
                }
                if (!string.IsNullOrEmpty(p.Password))
                {
                    user.PasswordHash = _passwordhasher.HashPassword(user, p.Password);
                }
                else
                {
                    ModelState.AddModelError("", "Şifre boş olamaz.");
                }
                if (!string.IsNullOrEmpty(p.Adi) && !string.IsNullOrEmpty(p.Soyadi) && !string.IsNullOrEmpty(p.UserName) && !string.IsNullOrEmpty(p.Email))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                            
                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
            }

            return RedirectToAction("Index", "User");
        }

        public async Task<IActionResult> UserDelete(string id)
        {
            AppUserTbl user = await _userManager.FindByIdAsync(id);
            IdentityResult result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);

                }
            }
            return RedirectToAction("Index", "User");
        }
        [HttpGet]
        public async Task<IActionResult> EditRolesInUsers(string id)
        {
            ViewBag.Userid = id;
           
            var user=await _userManager.FindByIdAsync(id);
            ViewBag.userAdSoyad = user.Adi + " " + user.Soyadi;
            if (user == null)
            {
                ViewBag.ErrorMessage = $"{id} nolu Kullanıcı Bulunamadı.";
                return View();
            }

            var model=new List<UserRoleViewModel>();

            var RolesList = await _roleManager.Roles.ToListAsync();

            foreach (var roles in RolesList)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    RoleID = roles.Id.ToString(),
                    RoleName = roles.Name
                };
                if(await _userManager.IsInRoleAsync(user, roles.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }
                model.Add(userRoleViewModel);
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditRolesInUsers(List<UserRoleViewModel> model,string id)
        {
            var user=await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"{id} nolu Kullanıcı Bulunamadı.";
                return View();
            }
            for (int i = 0; i < model.Count; i++)
            {
                var role=await _roleManager.FindByIdAsync(model[i].RoleID);
                IdentityResult result=null;
                if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if(!model[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else continue;
                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("Index","User");
                    }
                }
            }
            return RedirectToAction("Index", "User");
        }

    }
}

