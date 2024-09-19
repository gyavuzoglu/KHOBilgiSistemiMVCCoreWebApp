using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Controllers
{
    [Authorize(Roles = "Yönetici")]
    public class YoneticiController : Controller
    {
        
        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName=RoleName;
            ViewBag.UserName = UserName;
            return View();
        }
    }
}
