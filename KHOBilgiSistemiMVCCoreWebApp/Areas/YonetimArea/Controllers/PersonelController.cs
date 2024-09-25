using AutoMapper;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        AskeriSiniflarManager AskeriSinifMng = new AskeriSiniflarManager(new EfAskeriSiniflarRepository());
        RutbelerManager RutbeMng = new RutbelerManager(new EfRutbelerRepository());
        UnvanlarManager UnvanMng = new UnvanlarManager(new EfUnvanlarRepository());
        GorevlerManager GorevMng = new GorevlerManager(new EfGorevlerRepository());
        BolumlerManager BolumMng = new BolumlerManager(new EfBolumlerRepository());
        BirimlerManager BirimMng = new BirimlerManager(new EfBirimlerRepository());


        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            var values = pm.GetPersonelListWithBirimler();
            return View(values);
        }

        [HttpGet]
        public IActionResult PersonelAdd()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            ViewBag.SinifList = new SelectList(AskeriSinifMng.GetListAll(), "SinifId", "SinifKisa");
            ViewBag.RutbeList = new SelectList(RutbeMng.GetListAll(), "RutbeID", "RutbeKisa");
            ViewBag.UnvanList = new SelectList(UnvanMng.GetListAll(), "UnvanID", "UnvanKisa");
            ViewBag.GorevList = new SelectList(GorevMng.GetListAll(), "GorevID", "GorevAdi");
            ViewBag.BolumList = new SelectList(BolumMng.GetListAll(), "BolumID", "BolumAdi");
            ViewBag.BirimList = new SelectList(BirimMng.GetListAll(), "BirimID", "BirimAdi");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersonelAdd(PersonelTbl p)
        {
            PersonelValidator validationRules = new PersonelValidator();
            ValidationResult validationResult = validationRules.Validate(p);
            if (validationResult.IsValid)
            {
                pm.PersonelAdd(p);
                return RedirectToAction("Index", "Personel");

            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }

        public IActionResult PersonelDelete(int id)
        {

            var personelvalue = pm.TGetByID(id);
            pm.PersonelDelete(personelvalue);
            return RedirectToAction("Index", "Personel");
        }
        [HttpGet]
        public IActionResult PersonelGet(int id)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            var personelvalue = pm.TGetByID(id);
            return View(personelvalue);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersonelUpdate(PersonelTbl p)
        {
            pm.PersonelUpdate(p);
            return RedirectToAction("Index", "Personel");
        }
    }
}
