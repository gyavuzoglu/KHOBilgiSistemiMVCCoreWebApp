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
using System.Text;

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

            List<SelectListItem> Siniflar = new List<SelectListItem>();
            foreach (var item in AskeriSinifMng.GetListAll().ToList())
            {   
                Siniflar.Add(new SelectListItem { Text = item.SinifKisa, Value = item.SinifID.ToString() });
            }
            ViewBag.SinifList=Siniflar;

            List<SelectListItem> Rutbeler = new List<SelectListItem>();
            foreach (var item in RutbeMng.GetListAll().ToList())
            {
                Rutbeler.Add(new SelectListItem { Text = item.RutbeKisa, Value = item.RutbeID.ToString() });
            }
            ViewBag.RutbeList = Rutbeler;

            List<SelectListItem> Unvanlar = new List<SelectListItem>();
            foreach (var item in UnvanMng.GetListAll().ToList())
            {
                Unvanlar.Add(new SelectListItem { Text = item.UnvanKisa, Value = item.UnvanID.ToString() });
            }
            ViewBag.UnvanList = Unvanlar;

            List<SelectListItem> Gorevler = new List<SelectListItem>();
            foreach (var item in GorevMng.GetListAll().ToList())
            {
                Gorevler.Add(new SelectListItem { Text = item.GorevAdi, Value = item.GorevID.ToString() });
            }
            ViewBag.GorevList = Gorevler;

            List<SelectListItem> Bolumler = new List<SelectListItem>();
            foreach (var item in BolumMng.GetListAll().ToList())
            {
                Bolumler.Add(new SelectListItem { Text = item.BolumAdi, Value = item.BolumID.ToString() });
            }
            ViewBag.BolumList = Bolumler;

            List<SelectListItem> Birimler = new List<SelectListItem>();
            foreach (var item in BirimMng.GetListAll().ToList())
            {
                Birimler.Add(new SelectListItem { Text = item.BirimAdi, Value = item.BirimID.ToString() });
            }
            ViewBag.BirimList = Birimler;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersonelAdd(PersonelAddVM p)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var Personellist = pm.GetListAll().ToList();

            if (ModelState.IsValid)
            {
                if (p.SinifID == null) p.SinifID = 1;
                if (p.RutbeID == null) p.RutbeID = 1;
                if (p.UnvanID == null) p.UnvanID = 1;
                if (p.GorevID == null) p.GorevID = 1;
                if (p.BolumID == null) p.BolumID = 1;
                if (p.BirimID == null) p.BirimID = 1;

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

                if (!Personellist.Any(x => x.PersonelTC == p.PersonelTC))
                {
                    pm.PersonelAdd(per);
                    return RedirectToAction("Index", "Personel");
                }
                else
                {
                    ModelState.AddModelError("PersonelTC", "Bu T.C. kimlik numarası kullanılmaktadır.");
                }

            }

            List<SelectListItem> Siniflar = new List<SelectListItem>();
            foreach (var item in AskeriSinifMng.GetListAll().ToList())
            {
                Siniflar.Add(new SelectListItem { Text = item.SinifKisa, Value = item.SinifID.ToString() });
            }
            ViewBag.SinifList = Siniflar;

            List<SelectListItem> Rutbeler = new List<SelectListItem>();
            foreach (var item in RutbeMng.GetListAll().ToList())
            {
                Rutbeler.Add(new SelectListItem { Text = item.RutbeKisa, Value = item.RutbeID.ToString() });
            }
            ViewBag.RutbeList = Rutbeler;

            List<SelectListItem> Unvanlar = new List<SelectListItem>();
            foreach (var item in UnvanMng.GetListAll().ToList())
            {
                Unvanlar.Add(new SelectListItem { Text = item.UnvanKisa, Value = item.UnvanID.ToString() });
            }
            ViewBag.UnvanList = Unvanlar;

            List<SelectListItem> Gorevler = new List<SelectListItem>();
            foreach (var item in GorevMng.GetListAll().ToList())
            {
                Gorevler.Add(new SelectListItem { Text = item.GorevAdi, Value = item.GorevID.ToString() });
            }
            ViewBag.GorevList = Gorevler;

            List<SelectListItem> Bolumler = new List<SelectListItem>();
            foreach (var item in BolumMng.GetListAll().ToList())
            {
                Bolumler.Add(new SelectListItem { Text = item.BolumAdi, Value = item.BolumID.ToString() });
            }
            ViewBag.BolumList = Bolumler;

            List<SelectListItem> Birimler = new List<SelectListItem>();
            foreach (var item in BirimMng.GetListAll().ToList())
            {
                Birimler.Add(new SelectListItem { Text = item.BirimAdi, Value = item.BirimID.ToString() });
            }
            ViewBag.BirimList = Birimler;

            //return den önce dropdown listeleri varsa yeniden oluşturuluyor.

            return View(p);
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
