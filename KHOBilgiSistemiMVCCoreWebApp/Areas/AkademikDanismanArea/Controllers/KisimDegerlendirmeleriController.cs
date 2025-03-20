using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Controllers
{
    [Authorize(Roles = "Akademik Danışman")]

    [Area("AkademikDanismanArea")]
    
    public class KisimDegerlendirmeleriController : Controller
    {
        Context db = new Context();
        KisimDegerlendirmeleriManager kisimdegerlendirmemanager = new KisimDegerlendirmeleriManager(new EfKisimDegerlendirmeleriRepository());

        [HttpGet]
        public IActionResult Index()
        {
            var PerTC = HttpContext.Session.GetString("PerTC");
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.UserName = UserName;
            ViewBag.RoleName = RoleName;

            return View();

        }

        public IActionResult KisimDegerlendirmeleriniGetir(int? EOYiliID, int? Donem, int? PerID)
        {
            var values = kisimdegerlendirmemanager.GetList(EOYiliID, Donem, PerID);
            return View(values);
        }
    }
}
