using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Controllers
{
    [Authorize(Roles = "Akademik Danışman")]
    //[AllowAnonymous]

    [Area("AkademikDanismanArea")]
    public class OgrenciDegerlendirmeleriController : Controller
    {
              
        
            OgrenciDegerlendirmeleriManager ogrencidegerlendirmemanager = new OgrenciDegerlendirmeleriManager(new EfOgrenciDegerlendirmeleriRepository());
            [HttpGet]


            public IActionResult Index()
            {
                var UserName = HttpContext.Session.GetString("UserName");
                var RoleName = HttpContext.Session.GetString("RoleName");
                ViewBag.RoleName = RoleName;
                ViewBag.UserName = UserName;
                
                return View(); 
            }
            
        public IActionResult OgrenciDegerlendirmeleriniGetir(int? EOYiliID, int? Donem, int? PerID)
        {
            var values = ogrencidegerlendirmemanager.GetList(EOYiliID, Donem, PerID);
            return View(values);
        }
        
    }
}
