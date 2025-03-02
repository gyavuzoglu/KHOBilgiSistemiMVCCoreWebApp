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
using Microsoft.CodeAnalysis.Elfie.Serialization;
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

        


        [HttpGet]
        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC= HttpContext.Session.GetString("PerTC");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            return View();

        }

        [HttpGet]
        public IActionResult OgrencileriListele(KisimOgrenciListeClass model)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var kisimogrencilistesi = db.OgrencilerTbl.Where(x => x.Sinif == null && x.KisimAdi == null).ToList();
            var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();

            var modelOgrenciListe = new KisimOgrenciListeClass
            {
                SelectedSinif = model.SelectedSinif,
                SelectedDonem = model.SelectedDonem,
                SelectedEOYili = model.SelectedEOYili,
                SelectedKisimAdi = model.SelectedKisimAdi,
                OgrencilerListe = kisimogrencilistesi,
                PerID = PerID,

            };

            return View(modelOgrenciListe);

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
            SinifKisimSecmeClass skc = new SinifKisimSecmeClass();

            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            skc.SiniflarListe = new SelectList(db.SiniflarTbl, "Sinif", "SinifAdi");
            skc.KisimlarListe = new SelectList(db.KisimlarTbl, "KisimAdi", "KisimAdi");
            skc.EOYiliListe = new SelectList(db.EOYiliTbl, "EOYiliID", "EOYili");
            skc.DonemlerListe = new SelectList(db.DonemlerTbl, "Donem", "DonemAdi");


            //IEnumerable<SelectListItem> EOYiliList =
            //    db.EOYiliTbl.Select(i => new SelectListItem
            //    {
            //        Text = i.EOYili,
            //        Value = i.EOYiliID.ToString()
            //    });
            //ViewBag.EOYiliListe = EOYiliList;

            //IEnumerable<SelectListItem> DonemList =
            //    db.DonemlerTbl.Select(i => new SelectListItem
            //    {
            //        Text = i.DonemAdi,
            //        Value = i.Donem.ToString()
            //    });
            //ViewBag.DonemListe = DonemList;

            return View(skc);
        }

        [HttpPost]
        public IActionResult OgrencileriGetir(SinifKisimSecmeClass model)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var kisimogrencilistesi = db.OgrencilerTbl.Where(x => x.Sinif == null && x.KisimAdi == null).ToList();
            if (model.Sinif != null && !string.IsNullOrEmpty(model.KisimAdi))
            {
                kisimogrencilistesi = db.OgrencilerTbl.Where(x => x.Sinif == model.Sinif && x.KisimAdi == model.KisimAdi).ToList();
                var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();
                var modelKisimOgrenciListe=new KisimOgrenciListeClass
                { 
                    SelectedSinif = model.Sinif,
                    SelectedDonem = model.Donem,
                    SelectedEOYili = model.EOYiliID,
                    SelectedKisimAdi = model.KisimAdi,
                    OgrencilerListe = kisimogrencilistesi,
                    PerID=PerID,
                
                };
                return View("OgrencileriListele", modelKisimOgrenciListe);
            }
            else return View();
        }


        [HttpGet]
        public IActionResult OgcDegerlendirmeAdd(DegerlendirmeGirisClass model)
        {
            
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            
            var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();
            var DegerlendirmeGirisModel = new DegerlendirmeGirisClass
            {
                PerID = PerID,
                OgrenciId = model.OgrenciId,
                Adi = model.Adi,
                Soyadi = model.Soyadi,
                Sinif = model.Sinif,
                KisimAdi = model.KisimAdi,
                EOYili = model.EOYili,
                EOYiliID = db.EOYiliTbl.Where(x => x.EOYili == model.EOYili).Select(x => x.EOYiliID).FirstOrDefault(),
                Donem = model.Donem,
                OgrenciDegerlendirmeleriListe= db.OgrenciDegerlendirmeleriTbl.Where(x => x.PerID == model.PerID && x.OgrenciID == model.OgrenciId && x.EOYiliID == model.EOYiliID && x.Donem == model.Donem).ToList(),
                OgrenciDegerlendirmeTurleriListe= new SelectList(db.OgrenciDegerlendirmeTurleriTbl, "DegTurID", "TurAdi"),
            };
            return View(DegerlendirmeGirisModel);

        }


        [HttpPost]
        public IActionResult OgcDegerlendirmeAdd(OgcDegerlendirmeKayitClass model)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var kisimogrencilistesi = db.OgrencilerTbl.Where(x => x.Sinif == model.Sinif && x.KisimAdi == model.KisimAdi).ToList();

            var kisimogrenciclass = new KisimOgrenciListeClass
            {
                OgrencilerListe = kisimogrencilistesi,
                SelectedEOYili = model.EOYiliID,
                SelectedSinif = model.Sinif,
                SelectedDonem = model.Donem,
                SelectedKisimAdi = model.KisimAdi
            };

            if (ModelState.IsValid)
            {
                OgrenciDegerlendirmeleriTbl YapilanDegerlendirme = new OgrenciDegerlendirmeleriTbl()
                {
                    PerID = model.PerID,
                    OgrenciID = model.OgrenciID,
                    DegTurID = model.DegTurID,
                    TarihSaat = DateTime.Now,
                    Degerlendirme = model.Degerlendirme,
                    EOYiliID = model.EOYiliID,
                    Donem = model.Donem,
                };

                ogrencidegerlendirmemanager.OgrenciDegerlendirmeAdd(YapilanDegerlendirme);               

            }
            
            return View("OgrencileriListele", kisimogrenciclass);

        }

        public IActionResult OgrenciDegerlendirmeDelete(int id)
        {

            var Degerlendirmevalue = ogrencidegerlendirmemanager.GetByID(id);
            ogrencidegerlendirmemanager.OgrenciDegerlendirmeDelete(Degerlendirmevalue);
            return RedirectToAction("Index", "Birimler");
        }
    }
}
