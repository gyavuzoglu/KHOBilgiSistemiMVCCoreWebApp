using EntityLayer.Concrete;
using KHOBilgiSistemiMVCCoreWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KHOBilgiSistemiMVCCoreWebApp.Controllers
{
    //[Authorize(Roles = "Yönetici")]
    [AllowAnonymous]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRolesTbl> _roleManager;

        public RoleController(RoleManager<AppRolesTbl> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult RoleRegister()
        {
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleRegister(RoleViewModel p)
        {
            var role=new AppRolesTbl() { Id=p.Id, Name = p.Name };
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index", "Role");        
        }
        public async Task<IActionResult> RoleEdit(string id)
        {
            var role=await _roleManager.FindByIdAsync(id);
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleViewModel p)
        {
            var role = new AppRolesTbl() { Id=p.Id, Name = p.Name };
            await _roleManager.UpdateAsync(role);
            return RedirectToAction("Index", "Role");
        }



        public async Task<IActionResult> RoleDetails(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return View(role);
        }

     
        public async Task<IActionResult> RoleDelete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index", "Role");
        }
    }
}
