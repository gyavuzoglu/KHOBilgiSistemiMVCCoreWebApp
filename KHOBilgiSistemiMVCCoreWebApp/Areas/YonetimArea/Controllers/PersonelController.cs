using AutoMapper;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.YonetimArea.Controllers
{
    [Authorize(Roles = "Yönetici")]
    [Area("YonetimArea")]
    public class PersonelController : Controller
    {
        public IMapper Mapper { get; set; }
        public PersonelController(IMapper mapper)
        {
            Mapper = mapper;
        }


        PersonelManager pm = new PersonelManager(new EfPersonelRepository());
        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            var values = pm.GetPersonelListWithBirimler();
            return View(values);
        }
    }
}
