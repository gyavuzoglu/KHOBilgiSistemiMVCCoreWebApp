using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.KisimDegerlendirmeVM;
using KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.OgrenciDegerlendirmeVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Controllers
{
    [Authorize(Roles = "Akademik Danışman")]
    [Area("AkademikDanismanArea")]
    
    public class KisimDegerlendirmeleriController : Controller
    {
        Context db = new Context();
        KisimDegerlendirmeleriManager kisimdegerlendirmemanager = new KisimDegerlendirmeleriManager(new EfKisimDegerlendirmeleriRepository());

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

        [HttpGet]
        public IActionResult KisimlariGetirForm()
        {
            KisimGetirFormVM skc = new KisimGetirFormVM();

            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var PerTC = HttpContext.Session.GetString("PerTC");
            var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();

            skc.SiniflarListe = new SelectList(db.SiniflarTbl, "Sinif", "SinifAdi");
            //skc.KisimlarListe = new SelectList(db.KisimlarTbl, "KisimAdi", "KisimAdi");
            skc.EOYiliListe = new SelectList(db.EOYiliTbl, "EOYiliID", "EOYili");
            skc.DonemlerListe = new SelectList(db.DonemlerTbl, "Donem", "DonemAdi");
            skc.PerID = PerID;

            return View(skc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult KisimlariGetir(KisimGetirFormVM model)
        {
            var PerTC = HttpContext.Session.GetString("PerTC");
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.UserName = UserName;
            ViewBag.RoleName = RoleName;

            var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();
            
            var modelKisimveDegListe = db.KisimlarTbl.Where(x => x.Sinif == model.Sinif && x.EOYiliID==model.EOYiliID).Select(KisimList => new KisimListeDegSayilariIleVM
            {
                KisimAdi=KisimList.KisimAdi,
                BolumID = KisimList.BolumID,
                BolumAdi = db.BolumlerTbl.Where(x => x.BolumID == KisimList.BolumID).Select(x => x.BolumAdi).FirstOrDefault(),
                BolumAdiKisa = db.BolumlerTbl.Where(x => x.BolumID == KisimList.BolumID).Select(x => x.BolumAdiKisa).FirstOrDefault(),
                EOYiliID=model.EOYiliID,
                EOYili= db.EOYiliTbl.Where(x => x.EOYiliID == model.EOYiliID).Select(x => x.EOYili).FirstOrDefault(),
                KisimToplamDegAdedi = db.KisimDegerlendirmeleriTbl.Count(x => x.EOYiliID == model.EOYiliID && x.Donem == model.Donem && x.KisimAdi == KisimList.KisimAdi),
                KisimOgretmeninDegAdedi = db.KisimDegerlendirmeleriTbl.Count(x => x.EOYiliID == model.EOYiliID && x.Donem == model.Donem && x.KisimAdi == KisimList.KisimAdi && x.PerID == PerID),

            }).ToList();

            var modelKisimListe = new KisimListeClass
            {
                Sinif = model.Sinif,
                EOYiliID = model.EOYiliID,
                EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == model.EOYiliID).Select(x => x.EOYili).FirstOrDefault(),
                Donem = model.Donem,
                DonemAdi = db.DonemlerTbl.Where(x => x.Donem == model.Donem).Select(x => x.DonemAdi).FirstOrDefault(),
                KisimAdi= db.KisimlarTbl.Where(x => x.KisimAdi == model.KisimAdi).Select(x => x.KisimAdi).FirstOrDefault(),
                KisimVeDegListe = modelKisimveDegListe,
                PerID = PerID,

            };
            return View("KisimlariListele", modelKisimListe);
        }

        [HttpGet]
        public IActionResult KisimlariListele(KisimListelemekIcinOnBilgiVM model)
        {

            var PerTC = HttpContext.Session.GetString("PerTC");
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = UserName;
            ViewBag.RoleName = RoleName;

            var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();
           
            var modelKisimveDegListe = db.KisimlarTbl.Where(x => x.Sinif == model.Sinif && x.EOYiliID == model.EOYiliID).Select(KisimList => new KisimListeDegSayilariIleVM
            {
                KisimAdi = db.KisimlarTbl.Where(x => x.EOYiliID == model.EOYiliID && x.Sinif == model.Sinif).Select(x => x.KisimAdi).FirstOrDefault(),
                BolumID = KisimList.BolumID,
                BolumAdi = db.BolumlerTbl.Where(x => x.BolumID == KisimList.BolumID).Select(x => x.BolumAdi).FirstOrDefault(),
                BolumAdiKisa = db.BolumlerTbl.Where(x => x.BolumID == KisimList.BolumID).Select(x => x.BolumAdiKisa).FirstOrDefault(),
                EOYiliID = model.EOYiliID,
                EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == model.EOYiliID).Select(x => x.EOYili).FirstOrDefault(),
                KisimToplamDegAdedi = db.KisimDegerlendirmeleriTbl.Count(x => x.EOYiliID == model.EOYiliID && x.Donem == model.Donem && x.KisimAdi == KisimList.KisimAdi),
                KisimOgretmeninDegAdedi = db.KisimDegerlendirmeleriTbl.Count(x => x.EOYiliID == model.EOYiliID && x.Donem == model.Donem && x.KisimAdi == KisimList.KisimAdi && x.PerID == PerID),

            }).ToList();

            var modelKisimListe = new KisimListeClass
            {
                Sinif = model.Sinif,
                EOYiliID = model.EOYiliID,
                EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == model.EOYiliID).Select(x => x.EOYili).FirstOrDefault(),
                Donem = model.Donem,
                DonemAdi = db.DonemlerTbl.Where(x => x.Donem == model.Donem).Select(x => x.DonemAdi).FirstOrDefault(),
                KisimAdi = db.KisimlarTbl.Where(x => x.KisimAdi == model.KisimAdi).Select(x => x.KisimAdi).FirstOrDefault(),
                KisimVeDegListe = modelKisimveDegListe,
                PerID = PerID,

            };

            return View("KisimlariListele", modelKisimListe);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult KisimDegerlendirmeEkleForm(KisimDegerlendirmeClassVM model)
        {
            var PerTC = HttpContext.Session.GetString("PerTC");
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.UserName = UserName;
            ViewBag.RoleName = RoleName;

            var DegerlendirmeGirisModel = new KisimDegerlendirmeClassVM
            {
                PerID = model.PerID,
                BolumID = model.BolumID,
                BolumAdiKisa = db.BolumlerTbl.Where(x => x.BolumID == model.BolumID).Select(x => x.BolumAdiKisa).FirstOrDefault(),
                BolumAdi = db.BolumlerTbl.Where(x => x.BolumID == model.BolumID).Select(x => x.BolumAdi).FirstOrDefault(),
                Sinif = model.Sinif,
                KisimAdi = model.KisimAdi,
                EOYiliID = model.EOYiliID,
                EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == model.EOYiliID).Select(x => x.EOYili).FirstOrDefault(),
                Donem = model.Donem,
                
            };
            return View(DegerlendirmeGirisModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult KisimDegerlendirmeAdd(KisimDegerlendirmeClassVM model)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            if (ModelState.IsValid)
            {
                KisimDegerlendirmeleriTbl YapilanDegerlendirme = new KisimDegerlendirmeleriTbl()
                {
                    KisimAdi=model.KisimAdi,
                    PerID = model.PerID,
                    TarihSaat = model.TarihSaat,
                    KisimDegerlendirme = model.KisimDegerlendirme,
                    EOYiliID = model.EOYiliID,
                    Donem = model.Donem,
                };
                kisimdegerlendirmemanager.KisimDegerlendirmeAdd(YapilanDegerlendirme);
            }

            var modelKisimDegerlendirmeListe = db.KisimDegerlendirmeleriTbl.Where(deglist => deglist.PerID == model.PerID && deglist.KisimAdi == model.KisimAdi && deglist.EOYiliID == model.EOYiliID && deglist.Donem == model.Donem).Select(deglist => new KisimDegerlendirmeListVM
            {
                KisimDegerlendirmeID = deglist.KisimDegerlendirmeID,
                PerID = deglist.PerID,
                EOYiliID = deglist.EOYiliID,
                Donem = deglist.Donem,
                BolumID = model.BolumID,
                BolumAdiKisa = model.BolumAdiKisa,
                BolumAdi = model.BolumAdi,
                KisimAdi=model.KisimAdi,
                TarihSaat = deglist.TarihSaat,
                KisimDegerlendirme = deglist.KisimDegerlendirme,
            }).ToList();

            var KisimDegList = new KisimDegerlendirmeleriListesiVM
            {
                PerID = model.PerID,
                EOYiliID = model.EOYiliID,
                EOYili = model.EOYili,
                Donem = model.Donem,
                DonemAdi = db.DonemlerTbl.Where(x=>x.Donem==model.Donem).Select(x=>x.DonemAdi).FirstOrDefault(),
                BolumID = model.BolumID,
                BolumAdi = model.BolumAdi,
                KisimAdi = model.KisimAdi,
                Sinif = model.Sinif,
                KisimDegListe = modelKisimDegerlendirmeListe,
            };
            return View("KisimDegerlendirmeListelemeForm", KisimDegList);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult KisimDegerlendirmeListelemeForm(KisimDegerlendirmeleriListesiVM model)
        {
            var PerTC = HttpContext.Session.GetString("PerTC");
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.UserName = UserName;
            ViewBag.RoleName = RoleName;

            var BolumID = model.BolumID;

            var modelKisimDegerlendirmeListe = db.KisimDegerlendirmeleriTbl.Where(deglist => deglist.PerID == model.PerID && deglist.EOYiliID == model.EOYiliID && deglist.Donem == model.Donem && deglist.KisimAdi==model.KisimAdi).Select(deglist => new KisimDegerlendirmeListVM
            {
                KisimDegerlendirmeID = deglist.KisimDegerlendirmeID,
                PerID = model.PerID,
                EOYiliID = model.EOYiliID,
                Donem = model.Donem,
                BolumID = model.BolumID,
                BolumAdiKisa = db.BolumlerTbl.Where(x => x.BolumID == BolumID).Select(x => x.BolumAdiKisa).FirstOrDefault(),
                TarihSaat = deglist.TarihSaat,
                KisimDegerlendirme = deglist.KisimDegerlendirme,
            }).ToList();

            var modelKisimDegSartlari = new KisimDegerlendirmeleriListesiVM
            {
                KisimDegListe = modelKisimDegerlendirmeListe,
                PerID = model.PerID,
                EOYiliID = model.EOYiliID,
                EOYili = model.EOYili,
                Donem = model.Donem,
                DonemAdi = model.DonemAdi,
                KisimAdi=model.KisimAdi,
                BolumID = model.BolumID,
                BolumAdi = db.BolumlerTbl.Where(x => x.BolumID == BolumID).Select(x => x.BolumAdi).FirstOrDefault(),
                Sinif = model.Sinif,
                
            };

            return View(modelKisimDegSartlari);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DegerlendirmeGet(long id, KisimDegerlendirmeClassVM model)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var degerlendirmevalue = kisimdegerlendirmemanager.GetByID(id);
            var modelDegerlendirmeClassVM = new KisimDegerlendirmeClassVM
            {
                KisimDegId = id,
                PerID = degerlendirmevalue.PerID,
                EOYiliID = degerlendirmevalue.EOYiliID,
                Donem = degerlendirmevalue.Donem,
                TarihSaat = degerlendirmevalue.TarihSaat,
                KisimDegerlendirme = degerlendirmevalue.KisimDegerlendirme,
                Sinif = model.Sinif,
                KisimAdi = model.KisimAdi,
                BolumID = model.BolumID,
                BolumAdi = model.BolumAdi,
                BolumAdiKisa = model.BolumAdiKisa,
                
            };
            return View(modelDegerlendirmeClassVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DegerlendirmeUpdate(long DegId, KisimDegUpdateClassVM p)
        {
            KisimDegerlendirmeleriTbl KisimDegTbl = kisimdegerlendirmemanager.GetByID(DegId);
            if (KisimDegTbl != null)
            {
                if (!string.IsNullOrEmpty(p.KisimDegerlendirme))
                {
                    KisimDegTbl.KisimDegerlendirme = p.KisimDegerlendirme;
                }
                else
                {
                    ModelState.AddModelError("", "Degerlendirme boş olamaz.");
                }
                KisimDegTbl.PerID = p.PerID;
                KisimDegTbl.TarihSaat = p.TarihSaat;
                KisimDegTbl.EOYiliID = p.EOYiliID;
                KisimDegTbl.Donem = p.Donem;
                KisimDegTbl.KisimAdi = p.KisimAdi;

                kisimdegerlendirmemanager.KisimDegerlendirmeUpdate(KisimDegTbl);
            }

            var modelKisimDegerlendirmeListe = db.KisimDegerlendirmeleriTbl.Where(Kisimdeglist => Kisimdeglist.PerID == p.PerID && Kisimdeglist.EOYiliID == p.EOYiliID && Kisimdeglist.Donem == p.Donem && Kisimdeglist.KisimAdi==p.KisimAdi).Select(Kisimdeglist => new KisimDegerlendirmeListVM
            {
                KisimDegerlendirmeID = Kisimdeglist.KisimDegerlendirmeID,
                PerID = Kisimdeglist.PerID,
                EOYiliID = Kisimdeglist.EOYiliID,
                Donem = Kisimdeglist.Donem,
                TarihSaat = Kisimdeglist.TarihSaat,
                KisimDegerlendirme = Kisimdeglist.KisimDegerlendirme,
            }).ToList();

            var modelKisimDegerlendirmeListeSartlari = new KisimDegerlendirmeleriListesiVM
            {
                PerID = KisimDegTbl.PerID,
                EOYiliID = KisimDegTbl.EOYiliID,
                Donem = KisimDegTbl.Donem,
                BolumID = p.BolumID,
                BolumAdi = p.BolumAdi,
                KisimAdi = p.KisimAdi,
                Sinif = db.KisimlarTbl.Where(x=>x.KisimAdi==p.KisimAdi).Select(x=>x.Sinif).FirstOrDefault(),
                EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == p.EOYiliID).Select(x => x.EOYili).FirstOrDefault(),
                DonemAdi = db.DonemlerTbl.Where(x => x.Donem == p.Donem).Select(x => x.DonemAdi).FirstOrDefault(),
                KisimDegListe = modelKisimDegerlendirmeListe,
            };
            return View("KisimDegerlendirmeListelemeForm", modelKisimDegerlendirmeListeSartlari);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult KisimDegerlendirmeDelete(long id, KisimDegerlendirmeleriListesiVM model)
        {
            KisimDegerlendirmeleriTbl KisimDegTbl = kisimdegerlendirmemanager.GetByID(id);
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");

            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var Degerlendirmevalue = kisimdegerlendirmemanager.GetByID(id);
            kisimdegerlendirmemanager.KisimDegerlendirmeDelete(Degerlendirmevalue);

            var modelKisimDegerlendirmeListe = db.KisimDegerlendirmeleriTbl.Where(Kisimdeglist => Kisimdeglist.PerID == model.PerID && Kisimdeglist.EOYiliID == model.EOYiliID && Kisimdeglist.Donem == model.Donem && Kisimdeglist.KisimAdi == model.KisimAdi).Select(Kisimdeglist => new KisimDegerlendirmeListVM
            {
                KisimDegerlendirmeID = Kisimdeglist.KisimDegerlendirmeID,
                PerID = Kisimdeglist.PerID,
                EOYiliID = Kisimdeglist.EOYiliID,
                Donem = Kisimdeglist.Donem,
                KisimAdi = Kisimdeglist.KisimAdi,
                BolumID = model.BolumID,
                BolumAdi = db.BolumlerTbl.Where(x => x.BolumID == model.BolumID).Select(x => x.BolumAdi).FirstOrDefault(),
                BolumAdiKisa = db.BolumlerTbl.Where(x => x.BolumID == model.BolumID).Select(x => x.BolumAdiKisa).FirstOrDefault(),
                TarihSaat = Kisimdeglist.TarihSaat,
                KisimDegerlendirme = Kisimdeglist.KisimDegerlendirme,
            }).ToList();

            

            var modelYeniKisimDegerlendirmeListe = new KisimDegerlendirmeleriListesiVM
            {
                PerID = KisimDegTbl.PerID,
                EOYiliID = KisimDegTbl.EOYiliID,
                Donem = KisimDegTbl.Donem,
                BolumID = model.BolumID,
                BolumAdi = model.BolumAdi,
                KisimAdi = model.KisimAdi,
                Sinif = db.KisimlarTbl.Where(x => x.KisimAdi == model.KisimAdi).Select(x => x.Sinif).FirstOrDefault(),
                EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == model.EOYiliID).Select(x => x.EOYili).FirstOrDefault(),
                DonemAdi = db.DonemlerTbl.Where(x => x.Donem == model.Donem).Select(x => x.DonemAdi).FirstOrDefault(),
                KisimDegListe = modelKisimDegerlendirmeListe,
            };
            return View("KisimDegerlendirmeListelemeForm", modelYeniKisimDegerlendirmeListe);

            
        }
    }
}
