using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Controllers
{
    [Authorize(Roles = "Akademik Danışman")]

    [Area("AkademikDanismanArea")]
    
    public class KisimDegerlendirmeleriController : Controller
    {
        KisimDegerlendirmeleriManager kisimdegerlendirmemanager = new KisimDegerlendirmeleriManager(new EfKisimDegerlendirmeleriRepository());
        [HttpGet]
        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            return View();
        }

        public IActionResult KisimDegerlendirmeleriniGetir(int? EOYiliID, int? Donem, int? PerID)
        {
            var values = kisimdegerlendirmemanager.GetList(EOYiliID, Donem, PerID);
            return View(values);
        }
    }
}
