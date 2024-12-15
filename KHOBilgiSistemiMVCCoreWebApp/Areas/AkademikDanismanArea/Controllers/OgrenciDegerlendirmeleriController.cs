using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models;
using KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.OgrenciDegerlendirmeVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Controllers
{
    [Authorize(Roles = "Akademik Danışman")]


    [Area("AkademikDanismanArea")]

    public class OgrenciDegerlendirmeleriController : Controller
    {

        Context db = new Context();
        OgrenciDegerlendirmeleriManager ogrencidegerlendirmemanager = new OgrenciDegerlendirmeleriManager(new EfOgrenciDegerlendirmeleriRepository());
        OgrenciManager OgrencilerMng = new OgrenciManager(new EfOgrencilerRepository());
        SiniflarManager sinifmng = new SiniflarManager(new EfSiniflarRepository());
        EOYiliManager EOYilimng = new EOYiliManager(new EfEOYiliRepository());
        DonemlerManager donemmng = new DonemlerManager(new EfDonemlerRepository());

        SinifKisimSecmeClass skc = new SinifKisimSecmeClass();


        [HttpGet]
        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            return View();

        }

        [HttpGet]
        public IActionResult OgrencileriListele()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            return View();

        }

        public JsonResult KisimGetir(int p)
        {
            var kisimlar = (from x in db.KisimlarTbl
                            join y in db.SiniflarTbl on x.Sinif equals y.Sinif
                            where x.Sinif == p
                            select new
                            {
                                Text = x.KisimAdi,
                                Value = x.KisimAdi
                            }).ToList();
            return Json(kisimlar);
        }

        public IActionResult OgrenciDegerlendirmeleriniGetir(int? EOYiliID, int? Donem, int? PerID)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var values = ogrencidegerlendirmemanager.GetList(EOYiliID, Donem, PerID);
            return View(values);
        }

        [HttpGet]
        public IActionResult OgrencileriGetir()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            skc.SiniflarTbl = new SelectList(db.SiniflarTbl, "Sinif", "SinifAdi");
            skc.KisimlarTbl = new SelectList(db.KisimlarTbl, "KisimAdi", "KisimAdi");

            IEnumerable<SelectListItem> EOYiliList =
                db.EOYiliTbl.Select(i => new SelectListItem
                {
                    Text = i.EOYili,
                    Value = i.EOYiliID.ToString()
                });
            ViewBag.EOYiliListe = EOYiliList;

            IEnumerable<SelectListItem> DonemList =
                db.DonemlerTbl.Select(i => new SelectListItem
                {
                    Text = i.DonemAdi,
                    Value = i.Donem.ToString()
                });
            ViewBag.DonemListe = DonemList;

            return View(skc);
        }

        [HttpPost]
        public IActionResult OgrencileriGetir(int sinif, string KisimAdi, int EOYiliID, int Donem)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var kisimogrencilistesi = db.OgrencilerTbl.Where(x => x.Sinif == null && x.KisimAdi == null).ToList();
            if (sinif != null && !string.IsNullOrEmpty(KisimAdi))
            {
                kisimogrencilistesi = db.OgrencilerTbl.Where(x => x.Sinif == sinif && x.KisimAdi == KisimAdi).ToList();
                ViewBag.sinif = sinif;
                ViewBag.KisimAdi = KisimAdi;
                ViewBag.EOYiliID = EOYiliID;
                ViewBag.EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == EOYiliID).Select(x => x.EOYili).FirstOrDefault();
                ViewBag.Donem = Donem;
                ViewBag.DonemAdi = db.DonemlerTbl.Where(x => x.Donem == Donem).Select(x => x.DonemAdi).FirstOrDefault();

                return View("OgrencileriListele", kisimogrencilistesi);
            }
            else return View("OgrencileriListele", kisimogrencilistesi);
        }


        [HttpGet]
        public IActionResult OgrenciDegerlendirmeAdd(long ogrenciId, string Adi, string Soyadi, int sinif, string KisimAdi, int EOYiliID, int Donem)
        {

            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            ViewBag.OgrenciId = ogrenciId;
            ViewBag.OgrenciAdi = Adi;
            ViewBag.OgrenciSoyadi = Soyadi;
            ViewBag.Sinif = sinif;
            ViewBag.KisimAdi = KisimAdi;
            ViewBag.EOYiliID = EOYiliID;
            ViewBag.EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == EOYiliID).Select(x => x.EOYili);
            ViewBag.Donem = Donem;
            ViewBag.DonemAdi = db.DonemlerTbl.Where(x => x.Donem == Donem).Select(x => x.DonemAdi);

            var PerID = db.PersonelTbl.Where(x => x.PersonelTC == UserName).Select(x => x.PerId).FirstOrDefault();
            ViewBag.PerID = PerID;

            var OgrenciDegerlendirmeListe = db.OgrenciDegerlendirmeleriTbl.Where(x => x.PerID == PerID && x.OgrenciID == ogrenciId && x.EOYiliID == EOYiliID && x.Donem == Donem);
            return View();

        }


        [HttpPost]
        public IActionResult OgrenciDegerlendirmeAdd(OgrenciDegerlendirmeKayit p, int Sinif, string KisimAdi, int EOYiliID, int Donem)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            if (ModelState.IsValid)
            {
                OgrenciDegerlendirmeleriTbl OgrenciDegerlendirme = new OgrenciDegerlendirmeleriTbl()
                {
                    PerID = p.PerID,
                    OgrenciID = p.OgrenciID,
                    DegTurID = p.DegTurID,
                    TarihSaat = DateTime.Now,
                    Degerlendirme = p.Degerlendirme,
                    EOYiliID = p.EOYiliID,
                    Donem = p.Donem,
                };

                ogrencidegerlendirmemanager.OgrenciDegerlendirmeAdd(OgrenciDegerlendirme);

                var kisimogrencilistesi = db.OgrencilerTbl.Where(x => x.Sinif == null && x.KisimAdi == null).ToList();

                kisimogrencilistesi = db.OgrencilerTbl.Where(x => x.Sinif == Sinif && x.KisimAdi == KisimAdi).ToList();
                ViewBag.sinif = Sinif;
                ViewBag.KisimAdi = KisimAdi;
                ViewBag.EOYiliID = EOYiliID;
                ViewBag.EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == EOYiliID).Select(x => x.EOYili).FirstOrDefault();
                ViewBag.Donem = Donem;
                ViewBag.DonemAdi = db.DonemlerTbl.Where(x => x.Donem == Donem).Select(x => x.DonemAdi).FirstOrDefault();

                return View("OgrencileriListele", kisimogrencilistesi);

            }

            return View();
        }

        public IActionResult OgrenciDegerlendirmeDelete(int id)
        {

            var Degerlendirmevalue = ogrencidegerlendirmemanager.GetByID(id);
            ogrencidegerlendirmemanager.OgrenciDegerlendirmeDelete(Degerlendirmevalue);
            return RedirectToAction("Index", "Birimler");
        }
    }
}
