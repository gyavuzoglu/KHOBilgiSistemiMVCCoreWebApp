using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
            
            var DegListOnBilgi = new DegListOnBilgiVM
            {
                UserName = HttpContext.Session.GetString("UserName"),
                RoleName = HttpContext.Session.GetString("RoleName"),
                Sinif = 0,
                EOYiliID = 0,
                Donem = 0,
                
            };

            return View(DegListOnBilgi);

        }

        [HttpGet]
        public IActionResult OgrencileriListele(DegListOnBilgiVM model)
        {
           
            var PerTC = HttpContext.Session.GetString("PerTC");
            var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();
            var modelOgrenciDegListe = db.OgrencilerTbl.Where(x=>x.Sinif==model.Sinif && x.KisimAdi == model.KisimAdi).Select(OgcList => new OgrenciListeDegSayilariIleVM
            {
                YakaNo=OgcList.YakaNo,
                Adi=OgcList.Adi,
                Soyadi=OgcList.Soyadi,
                FotografAdresi=OgcList.FotografAdresi,
                OgcToplamDegAdedi=db.OgrenciDegerlendirmeleriTbl.Count(x=>x.EOYiliID==model.EOYiliID && x.Donem==model.Donem && x.OgrenciID==OgcList.OgrenciID),
                OgcOgretmeninDegAdedi = db.OgrenciDegerlendirmeleriTbl.Count(x=>x.EOYiliID==model.EOYiliID && x.Donem==model.Donem && x.OgrenciID==OgcList.OgrenciID && x.PerID==PerID),

            }).ToList();

            var modelKisimOgrenciListe = new KisimOgrenciListeClass
            {
                
                OgrenciListe=modelOgrenciDegListe,
                Sinif = model.Sinif,
                Donem = model.Donem,
                DonemAdi = db.DonemlerTbl.Where(x=>x.Donem==model.Donem).Select(x=>x.DonemAdi).FirstOrDefault(),
                EOYiliID = model.EOYiliID,
                EOYili = db.EOYiliTbl.Where(x => x.EOYiliID== model.EOYiliID).Select(x => x.EOYili).FirstOrDefault(),
                KisimAdi = model.KisimAdi,
                PerID = PerID,
                RoleName = model.RoleName,
                UserName = model.UserName,
               

            };

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

        public IActionResult OgrenciDegerlendirmeleriniGetir(DegListOnBilgiVM model)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");
            var PerID=db.PersonelTbl.Where(x => x.PersonelTC==PerTC).Select(x=>x.PerId).FirstOrDefault();

            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var deglist = ogrencidegerlendirmemanager.GetList(model.EOYiliID, model.Donem, PerID);
            return View(deglist);
        }

        [HttpPost]
        public IActionResult OgcDegerlendirmeListelemeForm(OgrenciDegerlendirmeleriListelemeSartlari model)
        {
            
            var modelOgrenciDegerlendirmeListe = db.OgrenciDegerlendirmeleriTbl.Where(deglist => deglist.PerID == model.PerID && deglist.OgrenciID == model.OgrenciID && deglist.EOYiliID == model.EOYiliID && deglist.Donem == model.Donem).Select(deglist => new OgrenciDegerlendirmeList
            {
                DegerlendirmeID= deglist.DegerlendirmeID,
                PerID = model.PerID,
                EOYiliID = model.EOYiliID,
                Donem = model.Donem,
                OgrenciID = deglist.OgrenciID,
                DegTurID = deglist.DegTurID,
                TurAdi = db.OgrenciDegerlendirmeTurleriTbl.Where(x => x.DegTurID == deglist.DegTurID).Select(x => x.TurAdi).FirstOrDefault(),
                TarihSaat = deglist.TarihSaat,
                Degerlendirme = deglist.Degerlendirme,


            }).ToList();

            var modelOgcDegSartlari = new OgrenciDegerlendirmeleriListelemeSartlari
            {
                OgrenciDegListe = modelOgrenciDegerlendirmeListe,
                PerID= model.PerID,
                EOYiliID= model.EOYiliID,
                EOYili=model.EOYili,
                Donem = model.Donem,
                DonemAdi = model.DonemAdi,
                OgrenciID=model.OgrenciID,
                Sinif=model.Sinif,
                KisimAdi = model.KisimAdi,
                OgrAdi=db.OgrencilerTbl.Where(x=>x.OgrenciID==model.OgrenciID).Select(x=>x.Adi).FirstOrDefault(),
                OgrSoyadi= db.OgrencilerTbl.Where(x => x.OgrenciID == model.OgrenciID).Select(x => x.Soyadi).FirstOrDefault(),
                YakaNo= db.OgrencilerTbl.Where(x => x.OgrenciID == model.OgrenciID).Select(x => x.YakaNo).FirstOrDefault(),
                FotografAdresi= db.OgrencilerTbl.Where(x => x.OgrenciID == model.OgrenciID).Select(x => x.FotografAdresi).FirstOrDefault(),
                
            };

            return View(modelOgcDegSartlari);
        }



        [HttpGet]
        public IActionResult OgrencileriGetir()
        {
            SinifKisimSecmeClass skc = new SinifKisimSecmeClass();

            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            var PerTC= HttpContext.Session.GetString("PerTC");
            var PerID=db.PersonelTbl.Where(x=>x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();

            skc.SiniflarListe = new SelectList(db.SiniflarTbl, "Sinif", "SinifAdi");
            skc.KisimlarListe = new SelectList(db.KisimlarTbl, "KisimAdi", "KisimAdi");
            skc.EOYiliListe = new SelectList(db.EOYiliTbl, "EOYiliID", "EOYili");
            skc.DonemlerListe = new SelectList(db.DonemlerTbl, "Donem", "DonemAdi");
            skc.PerID=PerID;
            

            return View(skc);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OgrencileriGetir(SinifKisimSecmeClass model)
        {
            var PerTC = HttpContext.Session.GetString("PerTC");
            var UserName= HttpContext.Session.GetString("UserName");
            var RoleName= HttpContext.Session.GetString("RoleName");

            ViewBag.kisimogrenciadedi = db.OgrencilerTbl.Count(x => x.Sinif == model.Sinif && x.KisimAdi == model.KisimAdi);

            var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();

            var modelOgrenciListe = db.OgrencilerTbl.Where(x => x.Sinif == model.Sinif && x.KisimAdi == model.KisimAdi).Select(OgcList => new OgrenciListeDegSayilariIleVM
            {
                OgrenciID=OgcList.OgrenciID,
                YakaNo = OgcList.YakaNo,
                Adi = OgcList.Adi,
                Soyadi = OgcList.Soyadi,
                FotografAdresi = OgcList.FotografAdresi,
                OgcToplamDegAdedi = db.OgrenciDegerlendirmeleriTbl.Count(x => x.EOYiliID == model.EOYiliID && x.Donem == model.Donem && x.OgrenciID == OgcList.OgrenciID),
                OgcOgretmeninDegAdedi = db.OgrenciDegerlendirmeleriTbl.Count(x => x.EOYiliID == model.EOYiliID && x.Donem == model.Donem && x.OgrenciID == OgcList.OgrenciID && x.PerID == PerID),

            }).ToList();

            var modelKisimOgrenciListe = new KisimOgrenciListeClass
            {
                Sinif=model.Sinif,
                EOYiliID=model.EOYiliID,
                Donem=model.Donem,
                KisimAdi=model.KisimAdi,
                EOYili=db.EOYiliTbl.Where(x=>x.EOYiliID==model.EOYiliID).Select(x=>x.EOYili).FirstOrDefault(),
                DonemAdi=db.DonemlerTbl.Where(x=>x.Donem==model.Donem).Select(x=>x.DonemAdi).FirstOrDefault(),
                OgrenciListe= modelOgrenciListe,
                UserName=UserName,
                RoleName=RoleName,
                PerID=PerID,

            };

            
            return View("OgrencileriListele", modelKisimOgrenciListe);
            
        }


        [HttpPost]
        public IActionResult OgcDegerlendirmeEkleForm(DegerlendirmeAddClass model)
        {
            //var PerTC = HttpContext.Session.GetString("PerTC");

            //var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();

            var DegerlendirmeGirisModel = new DegerlendirmeAddClass
            {
                PerID = model.PerID,
                OgrenciId = model.OgrenciId,
                Adi = model.Adi,
                Soyadi = model.Soyadi,
                YakaNo=model.YakaNo,
                Sinif = model.Sinif,
                KisimAdi = model.KisimAdi,
                EOYiliID = model.EOYiliID,
                EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == model.EOYiliID).Select(x => x.EOYili).FirstOrDefault(),
                Donem = model.Donem,
                FotografAdresi = model.FotografAdresi,
                OgrenciDegerlendirmeTurleriListe = new SelectList(db.OgrenciDegerlendirmeTurleriTbl, "DegTurID", "TurAdi"),
            };
            return View(DegerlendirmeGirisModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OgcDegerlendirmeAdd(OgcDegerlendirmeKayitClass model)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var kisimogrencilistesi = db.OgrencilerTbl.Where(x => x.Sinif == model.Sinif && x.KisimAdi == model.KisimAdi).ToList();
            var EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == model.EOYiliID).Select(x => x.EOYili ).FirstOrDefault();
            ViewBag.EOYili = EOYili;
            var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();
            ViewBag.DonemAdi=db.DonemlerTbl.Where(x=>x.Donem==model.Donem).Select(x=>x.DonemAdi).FirstOrDefault();

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

            var modelOgrenciDegListe = db.OgrenciDegerlendirmeleriTbl.Where(x => x.PerID == model.PerID && x.EOYiliID == model.EOYiliID && x.Donem==model.Donem && x.OgrenciID==model.OgrenciID).Select(OgcDegList => new OgrenciDegerlendirmeList
            {
                DegerlendirmeID=OgcDegList.DegerlendirmeID,
                PerID=model.PerID,
                OgrenciID=model.OgrenciID,
                EOYiliID=model.EOYiliID,
                Donem=model.Donem,
                DegTurID=model.DegTurID,
                TurAdi=db.OgrenciDegerlendirmeTurleriTbl.Where(x=>x.DegTurID==model.DegTurID).Select(x=>x.TurAdi).FirstOrDefault(),
                TarihSaat=model.TarihSaat,
                Degerlendirme=model.Degerlendirme,
                
            }).ToList();

            var DegList = new OgrenciDegerlendirmeleriListelemeSartlari
            {
                PerID = model.PerID,
                EOYiliID=model.EOYiliID,
                Donem = model.Donem,
                OgrenciID=model.OgrenciID,
                Sinif=model.Sinif,
                KisimAdi=model.KisimAdi,
                OgrAdi=db.OgrencilerTbl.Where(x=>x.OgrenciID==model.OgrenciID).Select(x=>x.Adi).FirstOrDefault(),
                OgrSoyadi=db.OgrencilerTbl.Where(x=>x.OgrenciID==model.OgrenciID).Select(x=>x.Soyadi).FirstOrDefault(),
                YakaNo=db.OgrencilerTbl.Where(x=>x.OgrenciID==model.OgrenciID).Select(x=>x.YakaNo).FirstOrDefault(),
                FotografAdresi=db.OgrencilerTbl.Where(x=>x.OgrenciID==model.OgrenciID).Select(x=>x.FotografAdresi).FirstOrDefault(),                
                OgrenciDegListe= modelOgrenciDegListe,

            };


            return View("OgrenciDegerlendirmeleriListeleme", DegList);

        }

        [HttpGet]
        public IActionResult OgrenciDegerlendirmeDelete(long id, OgrenciDegerlendirmeleriListelemeSartlari model)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");

            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var Degerlendirmevalue = ogrencidegerlendirmemanager.GetByID(id);
            ogrencidegerlendirmemanager.OgrenciDegerlendirmeDelete(Degerlendirmevalue);

            ViewBag.EOYiliID = model.EOYiliID;
            ViewBag.EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == model.EOYiliID).Select(x => x.EOYili).FirstOrDefault();
            ViewBag.Donem = model.Donem;
            ViewBag.Sinif = model.Sinif;
            ViewBag.KisimAdi = model.KisimAdi;
            ViewBag.OgrAdi = model.OgrAdi;
            ViewBag.OgrSoyadi = model.OgrSoyadi;
            ViewBag.Fotograf = model.FotografAdresi;
            
            var YakaNo=db.OgrencilerTbl.Where(x=>x.OgrenciID==model.OgrenciID).Select(x=>x.YakaNo).FirstOrDefault();
            ViewBag.YakaNo =YakaNo;
            var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();

            var modelOgrenciDegerlendirmeListeSartlari = new OgrenciDegerlendirmeleriListelemeSartlari
            {

                PerID = PerID,
                EOYiliID = model.EOYiliID,
                Donem = model.Donem,
                Sinif = model.Sinif,
                OgrenciID = model.OgrenciID,
                KisimAdi = model.KisimAdi,
                OgrAdi = model.OgrAdi,
                OgrSoyadi = model.OgrSoyadi,
                YakaNo = YakaNo,
                FotografAdresi = model.FotografAdresi,

            };

            return RedirectToAction("OgrenciDegerlendirmeListeleme", modelOgrenciDegerlendirmeListeSartlari);
           
        }

        [HttpGet]
        public IActionResult DegerlendirmeGet(long id, int Sinif, string KisimAdi, int YakaNo, string OgrAdi, string OgrSoyadi, string FotografAdresi)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            
            
            var degerlendirmevalue = ogrencidegerlendirmemanager.GetByID(id);
            var modelDegerlendirmeGetClass = new DegerlendirmeGetClass
            {
                DegId = id,
                PerID=degerlendirmevalue.PerID,
                OgrenciID=degerlendirmevalue.OgrenciID,
                EOYiliID=degerlendirmevalue.EOYiliID,
                Donem=degerlendirmevalue.Donem,
                DegTurID=degerlendirmevalue.DegTurID,
                TarihSaat=degerlendirmevalue.TarihSaat,
                Degerlendirme=degerlendirmevalue.Degerlendirme,
                Sinif=Sinif,
                KisimAdi=KisimAdi,
                YakaNo=YakaNo,
                OgrAdi=OgrAdi,
                OgrSoyadi=OgrSoyadi,
                FotografAdresi = FotografAdresi,
                OgrenciDegerlendirmeTurleriListe = new SelectList(db.OgrenciDegerlendirmeTurleriTbl, "DegTurID", "TurAdi"),
            };
            
            return View(modelDegerlendirmeGetClass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DegerlendirmeUpdate(long DegId, OgcDegUpdateClass p)
        {
            OgrenciDegerlendirmeleriTbl OgcDegTbl= ogrencidegerlendirmemanager.GetByID(DegId);
            if (OgcDegTbl != null)
            {
                if (!string.IsNullOrEmpty(p.Degerlendirme))
                {
                    OgcDegTbl.Degerlendirme = p.Degerlendirme;
                }
                else
                {
                    ModelState.AddModelError("", "Degerlendirme boş olamaz.");
                }
                OgcDegTbl.PerID = p.PerID;
                OgcDegTbl.DegTurID = p.DegTurID;
                OgcDegTbl.OgrenciID = db.OgrenciDegerlendirmeleriTbl.Where(x=>x.DegerlendirmeID==DegId).Select(x=>x.OgrenciID).FirstOrDefault();
                OgcDegTbl.TarihSaat = p.TarihSaat;
                OgcDegTbl.EOYiliID = p.EOYiliID;
                OgcDegTbl.Donem = p.Donem;

            }
            ogrencidegerlendirmemanager.OgrenciDegerlendirmeUpdate(OgcDegTbl);

            var modelOgrenciDegerlendirmeListeSartlari = new OgrenciDegerlendirmeleriListelemeSartlari
            {

                PerID = OgcDegTbl.PerID,
                EOYiliID = OgcDegTbl.EOYiliID,
                Donem = OgcDegTbl.Donem,
                OgrenciID = OgcDegTbl.OgrenciID,
                Sinif = db.OgrencilerTbl.Where(x => x.OgrenciID == OgcDegTbl.OgrenciID).Select(x => x.Sinif).FirstOrDefault(),
                KisimAdi = db.OgrencilerTbl.Where(x => x.OgrenciID == OgcDegTbl.OgrenciID).Select(x=>x.KisimAdi).FirstOrDefault(),
                OgrAdi = db.OgrencilerTbl.Where(x => x.OgrenciID == OgcDegTbl.OgrenciID).Select(x => x.Adi).FirstOrDefault(),
                OgrSoyadi = db.OgrencilerTbl.Where(x => x.OgrenciID == OgcDegTbl.OgrenciID).Select(x => x.Soyadi).FirstOrDefault(),
                YakaNo = db.OgrencilerTbl.Where(x => x.OgrenciID == OgcDegTbl.OgrenciID).Select(x => x.YakaNo).FirstOrDefault(),
                FotografAdresi = db.OgrencilerTbl.Where(x => x.OgrenciID == OgcDegTbl.OgrenciID).Select(x => x.FotografAdresi).FirstOrDefault(),

            };

            return RedirectToAction("OgrenciDegerlendirmeListeleme", modelOgrenciDegerlendirmeListeSartlari);
        }
    }
}
