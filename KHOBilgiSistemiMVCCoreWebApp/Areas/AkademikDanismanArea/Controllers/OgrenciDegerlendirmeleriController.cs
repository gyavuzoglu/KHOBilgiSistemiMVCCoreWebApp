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

            var modelKisimOgrenciListe = db.OgrencilerTbl.Where(ogrlist => ogrlist.Sinif == model.Sinif && ogrlist.KisimAdi == model.KisimAdi).Select(ogrlist => new KisimOgrenciListeClass
            {
                OgrenciID = ogrlist.OgrenciID,
                YakaNo = ogrlist.YakaNo,
                Adi = ogrlist.Adi,
                Soyadi = ogrlist.Soyadi,
                Sinif = model.Sinif,
                Donem = model.Donem,
                EOYili = model.EOYili,
                KisimAdi = model.KisimAdi,
                FotografAdresi = ogrlist.FotografAdresi,
                PerID = PerID,
                OgrToplamDegAdedi = db.OgrenciDegerlendirmeleriTbl.Count(x => x.EOYiliID == model.EOYili && x.Donem == model.Donem && x.OgrenciID==ogrlist.OgrenciID),
                OgrOgretmeninDegAdedi = db.OgrenciDegerlendirmeleriTbl.Count(x => x.EOYiliID == model.EOYili && x.Donem == model.Donem && x.OgrenciID == ogrlist.OgrenciID && x.PerID == PerID),

            }).ToList();

            return View(modelKisimOgrenciListe);

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

        public IActionResult OgrenciDegerlendirmeListele() 
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            ViewBag.EOYiliList= new SelectList(db.EOYiliTbl, "EOYiliID", "EOYili");
            ViewBag.DonemList= new SelectList(db.DonemlerTbl, "Donem", "DonemAdi");
            ViewBag.SinifList= new SelectList(db.SiniflarTbl, "Sinif", "SinifAdi");
            ViewBag.KisimList= new SelectList(db.KisimlarTbl, "KisimAdi", "KisimAdi");


            return View(); 
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

            return View(skc);
        }

        [HttpPost]
        public IActionResult OgrencileriGetir(ListelemeSartlari model)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            var EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == model.EOYiliID).Select(x=>x.EOYili).FirstOrDefault();
            ViewBag.EOYili = EOYili;
            var Donem = db.DonemlerTbl.Where(x => x.Donem == model.Donem).Select(x => x.DonemAdi).FirstOrDefault();
            ViewBag.DonemAdi = Donem;


            var kisimogrenciadedi = db.OgrencilerTbl.Count(x => x.Sinif == null && x.KisimAdi == null);
            //if (model.Sinif != null && !string.IsNullOrEmpty(model.KisimAdi))
            //{
                kisimogrenciadedi = db.OgrencilerTbl.Count(x => x.Sinif == model.Sinif && x.KisimAdi == model.KisimAdi);
                var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();

                var modelKisimOgrenciListe=db.OgrencilerTbl.Where(ogrlist=> ogrlist.Sinif==model.Sinif && ogrlist.KisimAdi==model.KisimAdi).Select(ogrlist => new KisimOgrenciListeClass
                { 
                    OgrenciID = ogrlist.OgrenciID,
                    YakaNo= ogrlist.YakaNo,
                    Adi= ogrlist.Adi,
                    Soyadi= ogrlist.Soyadi,
                    Sinif = model.Sinif,
                    Donem = model.Donem,
                    EOYili = model.EOYiliID,
                    KisimAdi = model.KisimAdi,
                    FotografAdresi = ogrlist.FotografAdresi,
                    PerID=PerID,
                    OgrToplamDegAdedi = db.OgrenciDegerlendirmeleriTbl.Count(x => x.EOYiliID == model.EOYiliID && x.Donem == model.Donem && x.OgrenciID==ogrlist.OgrenciID),
                    OgrOgretmeninDegAdedi = db.OgrenciDegerlendirmeleriTbl.Count(x => x.EOYiliID == model.EOYiliID && x.Donem == model.Donem && x.PerID == PerID && x.OgrenciID == ogrlist.OgrenciID),

                }).ToList();
                return View("OgrencileriListele", modelKisimOgrenciListe);
            //}
            //else return View();
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
                Fotograf = model.Fotograf,
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
            var EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == model.EOYiliID).Select(x => x.EOYili).FirstOrDefault();
            ViewBag.EOYili = EOYili;
            var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();

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

            var modelKisimOgrenciListe = db.OgrencilerTbl.Where(ogrlist => ogrlist.Sinif == model.Sinif && ogrlist.KisimAdi == model.KisimAdi).Select(ogrlist => new KisimOgrenciListeClass
            {
                OgrenciID = ogrlist.OgrenciID,
                YakaNo = ogrlist.YakaNo,
                Adi = ogrlist.Adi,
                Soyadi = ogrlist.Soyadi,
                Sinif = model.Sinif,
                Donem = model.Donem,
                EOYili = model.EOYiliID,
                KisimAdi = model.KisimAdi,
                FotografAdresi = ogrlist.FotografAdresi,
                PerID = PerID,
                OgrToplamDegAdedi = db.OgrenciDegerlendirmeleriTbl.Count(x => x.EOYiliID == model.EOYiliID && x.Donem == model.Donem && x.OgrenciID == ogrlist.OgrenciID),
                OgrOgretmeninDegAdedi = db.OgrenciDegerlendirmeleriTbl.Count(x => x.EOYiliID == model.EOYiliID && x.Donem == model.Donem && x.PerID == PerID && x.OgrenciID == ogrlist.OgrenciID),

            }).ToList();


            
            
            return View("OgrencileriListele", modelKisimOgrenciListe);

        }

        public IActionResult OgrenciDegerlendirmeDelete(int id)
        {

            var Degerlendirmevalue = ogrencidegerlendirmemanager.GetByID(id);
            ogrencidegerlendirmemanager.OgrenciDegerlendirmeDelete(Degerlendirmevalue);
            return RedirectToAction("Index", "Birimler");
        }
    }
}
