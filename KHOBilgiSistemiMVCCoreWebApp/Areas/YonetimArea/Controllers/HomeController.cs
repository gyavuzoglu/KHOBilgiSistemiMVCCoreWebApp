using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.YonetimArea.Controllers
{
    [Authorize(Roles = "Yönetici")]
    [Area("YonetimArea")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
