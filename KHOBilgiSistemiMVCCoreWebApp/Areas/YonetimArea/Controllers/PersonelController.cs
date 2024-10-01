using AutoMapper;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using KHOBilgiSistemiMVCCoreWebApp.Areas.YonetimArea.Models.ViewModels.PersonelVM;
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

            ViewBag.SinifList = new SelectList(AskeriSinifMng.GetListAll().ToList(), "SinifID", "SinifKisa");
            ViewBag.RutbeList = new SelectList(RutbeMng.GetListAll().ToList(), "RutbeID", "RutbeKisa");
            ViewBag.UnvanList = new SelectList(UnvanMng.GetListAll().ToList(), "UnvanID", "UnvanKisa");
            ViewBag.GorevList = new SelectList(GorevMng.GetListAll().ToList(), "GorevID", "GorevAdi");
            ViewBag.BolumList = new SelectList(BolumMng.GetListAll().ToList(), "BolumID", "BolumAdi");
            ViewBag.BirimList = new SelectList(BirimMng.GetListAll().ToList(), "BirimID", "BirimAdi");
            

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersonelAdd(PersonelAddVM p)
        {
            //PersonelValidator validationRules = new PersonelValidator();
            //ValidationResult validationResult = validationRules.Validate(p);
            var Personellist = pm.GetListAll().ToList();

            //if (validationResult.IsValid)

            if(ModelState.IsValid) 
            {
                PersonelTbl per = new PersonelTbl()
                {
                    PersonelTC = p.PersonelTC,
                    Adi = p.Adi,
                    Soyadi = p.Soyadi,
                    SinifID = p.SinifID,
                    RutbeID = p.RutbeID,
                    UnvanID = p.UnvanID,
                    GorevID = p.GorevID,
                    BolumID = p.BolumID,
                    BirimID = p.BirimID,
                    MisafirPersonel = p.MisafirPersonel,
                    MisafirGorevYeri = p.MisafirGorevYeri,
                    MisafirEvAdresi = p.MisafirEvAdresi,
                    OkulEPosta = p.OkulEPosta,
                    DigerEPosta = p.DigerEPosta,
                    CepTelefonu = p.CepTelefonu,
                    DahiliTelefonu = p.DahiliTelefonu,
                    KayitTarihi = p.KayitTarihi
                };
                
                if (!Personellist.Any(x=>x.PersonelTC == p.PersonelTC))
                {
                    pm.PersonelAdd(per);
                    return RedirectToAction("Index", "Personel");
                }
                else
                {
                    ModelState.AddModelError("", "Bu TC numarası kullanılmaktadır.");

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
