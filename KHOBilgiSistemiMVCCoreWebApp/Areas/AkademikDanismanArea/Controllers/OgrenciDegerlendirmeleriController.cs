using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Models.OgrenciDegerlendirmeVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.AkademikDanismanArea.Controllers
{
    [Authorize(Roles = "Akademik Danışman")]
    [Area("AkademikDanismanArea")]

    public class OgrenciDegerlendirmeleriController : Controller
    {

        Context db = new Context();
        OgrenciDegerlendirmeleriManager ogrencidegerlendirmemanager = new OgrenciDegerlendirmeleriManager(new EfOgrenciDegerlendirmeleriRepository());
        OgrenciManager OgrencilerMng = new OgrenciManager(new EfOgrencilerRepository());

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
        public IActionResult OgrencileriListele(OgcListelemekIcinOnBilgiVM model)
        {
           
            var PerTC = HttpContext.Session.GetString("PerTC");
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName=HttpContext.Session.GetString("UserName");     
            ViewBag.UserName=UserName;
            ViewBag.RoleName=RoleName;

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
                 
            };

            return View("OgrencileriListele",modelKisimOgrenciListe);

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

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OgcDegerlendirmeListelemeForm(OgcDegerlendirmeleriListesiVM model)
        {
            var PerTC = HttpContext.Session.GetString("PerTC");
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.UserName = UserName;
            ViewBag.RoleName = RoleName;

            var modelOgrenciDegerlendirmeListe = db.OgrenciDegerlendirmeleriTbl.Where(deglist => deglist.PerID == model.PerID && deglist.OgrenciID == model.OgrenciID && deglist.EOYiliID == model.EOYiliID && deglist.Donem == model.Donem).Select(deglist => new OgcDegerlendirmeListVM
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

            var modelOgcDegSartlari = new OgcDegerlendirmeleriListesiVM
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
                Adi=db.OgrencilerTbl.Where(x=>x.OgrenciID==model.OgrenciID).Select(x=>x.Adi).FirstOrDefault(),
                Soyadi= db.OgrencilerTbl.Where(x => x.OgrenciID == model.OgrenciID).Select(x => x.Soyadi).FirstOrDefault(),
                YakaNo= db.OgrencilerTbl.Where(x => x.OgrenciID == model.OgrenciID).Select(x => x.YakaNo).FirstOrDefault(),
                FotografAdresi= db.OgrencilerTbl.Where(x => x.OgrenciID == model.OgrenciID).Select(x => x.FotografAdresi).FirstOrDefault(),                
            };

            return View(modelOgcDegSartlari);
        }



        [HttpGet]
        public IActionResult OgrencileriGetirForm()
        {
            OgrenciGetirFormVM skc = new OgrenciGetirFormVM();

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
        public IActionResult OgrencileriGetir(OgrenciGetirFormVM model)
        {
            var PerTC = HttpContext.Session.GetString("PerTC");
            var UserName= HttpContext.Session.GetString("UserName");
            var RoleName= HttpContext.Session.GetString("RoleName");
            ViewBag.UserName=UserName;
            ViewBag.RoleName=RoleName;
            
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
                PerID=PerID,

            };            
            return View("OgrencileriListele", modelKisimOgrenciListe);            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OgcDegerlendirmeEkleForm(DegerlendirmeClassVM model)
        {
            var PerTC = HttpContext.Session.GetString("PerTC");
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.UserName = UserName;
            ViewBag.RoleName = RoleName;

            var DegerlendirmeGirisModel = new DegerlendirmeClassVM
            {
                PerID = model.PerID,
                OgrenciID = model.OgrenciID,
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
        public IActionResult OgcDegerlendirmeAdd(DegerlendirmeClassVM model)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
                                
            if (ModelState.IsValid)
            {
                OgrenciDegerlendirmeleriTbl YapilanDegerlendirme = new OgrenciDegerlendirmeleriTbl()
                {
                    PerID = model.PerID,
                    OgrenciID = model.OgrenciID,
                    DegTurID = model.DegTurID,
                    TarihSaat = model.TarihSaat,
                    Degerlendirme = model.Degerlendirme,
                    EOYiliID = model.EOYiliID,
                    Donem = model.Donem,
                };
                ogrencidegerlendirmemanager.OgrenciDegerlendirmeAdd(YapilanDegerlendirme);
            }

            var modelOgrenciDegerlendirmeListe = db.OgrenciDegerlendirmeleriTbl.Where(deglist => deglist.PerID == model.PerID && deglist.OgrenciID == model.OgrenciID && deglist.EOYiliID == model.EOYiliID && deglist.Donem == model.Donem).Select(deglist => new OgcDegerlendirmeListVM
            {
                DegerlendirmeID = deglist.DegerlendirmeID,
                PerID = deglist.PerID,
                EOYiliID = deglist.EOYiliID,
                Donem = deglist.Donem,
                OgrenciID = deglist.OgrenciID,
                DegTurID = deglist.DegTurID,
                TurAdi = db.OgrenciDegerlendirmeTurleriTbl.Where(x => x.DegTurID == deglist.DegTurID).Select(x => x.TurAdi).FirstOrDefault(),
                TarihSaat = deglist.TarihSaat,
                Degerlendirme = deglist.Degerlendirme,
            }).ToList();

            var DegList = new OgcDegerlendirmeleriListesiVM
            {
                PerID = model.PerID,
                EOYiliID=model.EOYiliID,
                Donem = model.Donem,
                OgrenciID=model.OgrenciID,
                Sinif=model.Sinif,
                KisimAdi=model.KisimAdi,
                Adi=db.OgrencilerTbl.Where(x=>x.OgrenciID==model.OgrenciID).Select(x=>x.Adi).FirstOrDefault(),
                Soyadi=db.OgrencilerTbl.Where(x=>x.OgrenciID==model.OgrenciID).Select(x=>x.Soyadi).FirstOrDefault(),
                YakaNo=db.OgrencilerTbl.Where(x=>x.OgrenciID==model.OgrenciID).Select(x=>x.YakaNo).FirstOrDefault(),
                FotografAdresi=db.OgrencilerTbl.Where(x=>x.OgrenciID==model.OgrenciID).Select(x=>x.FotografAdresi).FirstOrDefault(),                
                OgrenciDegListe= modelOgrenciDegerlendirmeListe,
            };
            return View("OgcDegerlendirmeListelemeForm", DegList);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OgrenciDegerlendirmeDelete(long id, OgcDegerlendirmeleriListesiVM model)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");

            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var Degerlendirmevalue = ogrencidegerlendirmemanager.GetByID(id);
            ogrencidegerlendirmemanager.OgrenciDegerlendirmeDelete(Degerlendirmevalue);
                       
            var modelOgrenciDegerlendirmeListe = db.OgrenciDegerlendirmeleriTbl.Where(deglist => deglist.PerID == model.PerID && deglist.OgrenciID == model.OgrenciID && deglist.EOYiliID == model.EOYiliID && deglist.Donem == model.Donem).Select(deglist => new OgcDegerlendirmeListVM
            {
                DegerlendirmeID = deglist.DegerlendirmeID,
                PerID = deglist.PerID,
                EOYiliID = deglist.EOYiliID,
                Donem = deglist.Donem,
                OgrenciID = deglist.OgrenciID,
                DegTurID = deglist.DegTurID,
                TurAdi = db.OgrenciDegerlendirmeTurleriTbl.Where(x => x.DegTurID == deglist.DegTurID).Select(x => x.TurAdi).FirstOrDefault(),
                TarihSaat = deglist.TarihSaat,
                Degerlendirme = deglist.Degerlendirme,
            }).ToList();

            var ModelDegList = new OgcDegerlendirmeleriListesiVM
            {
                PerID = model.PerID,
                EOYiliID = model.EOYiliID,
                Donem = model.Donem,
                OgrenciID = model.OgrenciID,
                Sinif = model.Sinif,
                KisimAdi = model.KisimAdi,
                Adi = db.OgrencilerTbl.Where(x => x.OgrenciID == model.OgrenciID).Select(x => x.Adi).FirstOrDefault(),
                Soyadi = db.OgrencilerTbl.Where(x => x.OgrenciID == model.OgrenciID).Select(x => x.Soyadi).FirstOrDefault(),
                YakaNo = db.OgrencilerTbl.Where(x => x.OgrenciID == model.OgrenciID).Select(x => x.YakaNo).FirstOrDefault(),
                FotografAdresi = db.OgrencilerTbl.Where(x => x.OgrenciID == model.OgrenciID).Select(x => x.FotografAdresi).FirstOrDefault(),
                OgrenciDegListe = modelOgrenciDegerlendirmeListe,
            };

            return View("OgcDegerlendirmeListelemeForm", ModelDegList);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DegerlendirmeGet(long id, DegerlendirmeClassVM model)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
                        
            var degerlendirmevalue = ogrencidegerlendirmemanager.GetByID(id);
            var modelDegerlendirmeClassVM = new DegerlendirmeClassVM
            {
                DegId = id,
                PerID=degerlendirmevalue.PerID,
                OgrenciID=degerlendirmevalue.OgrenciID,
                EOYiliID=degerlendirmevalue.EOYiliID,
                Donem=degerlendirmevalue.Donem,
                DegTurID=degerlendirmevalue.DegTurID,
                TarihSaat=degerlendirmevalue.TarihSaat,
                Degerlendirme=degerlendirmevalue.Degerlendirme,
                Sinif=model.Sinif,
                KisimAdi= model.KisimAdi,
                YakaNo= model.YakaNo,
                Adi= model.Adi,
                Soyadi= model.Soyadi,
                FotografAdresi = model.FotografAdresi,
                OgrenciDegerlendirmeTurleriListe = new SelectList(db.OgrenciDegerlendirmeTurleriTbl, "DegTurID", "TurAdi"),
            };            
            return View(modelDegerlendirmeClassVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DegerlendirmeUpdate(long DegId, OgcDegUpdateClassVM p)
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

            var modelOgrenciDegerlendirmeListe = db.OgrenciDegerlendirmeleriTbl.Where(deglist => deglist.PerID == p.PerID && deglist.OgrenciID == p.OgrenciID && deglist.EOYiliID == p.EOYiliID && deglist.Donem == p.Donem).Select(deglist => new OgcDegerlendirmeListVM
            {
                DegerlendirmeID = deglist.DegerlendirmeID,
                PerID = deglist.PerID,
                EOYiliID = deglist.EOYiliID,
                Donem = deglist.Donem,
                OgrenciID = deglist.OgrenciID,
                DegTurID = deglist.DegTurID,
                TurAdi = db.OgrenciDegerlendirmeTurleriTbl.Where(x => x.DegTurID == deglist.DegTurID).Select(x => x.TurAdi).FirstOrDefault(),
                TarihSaat = deglist.TarihSaat,
                Degerlendirme = deglist.Degerlendirme,
            }).ToList();

            var modelOgrenciDegerlendirmeListeSartlari = new OgcDegerlendirmeleriListesiVM
            {
                PerID = OgcDegTbl.PerID,
                EOYiliID = OgcDegTbl.EOYiliID,
                Donem = OgcDegTbl.Donem,
                OgrenciID = OgcDegTbl.OgrenciID,
                Sinif = db.OgrencilerTbl.Where(x => x.OgrenciID == OgcDegTbl.OgrenciID).Select(x => x.Sinif).FirstOrDefault(),
                KisimAdi = db.OgrencilerTbl.Where(x => x.OgrenciID == OgcDegTbl.OgrenciID).Select(x=>x.KisimAdi).FirstOrDefault(),
                Adi = db.OgrencilerTbl.Where(x => x.OgrenciID == OgcDegTbl.OgrenciID).Select(x => x.Adi).FirstOrDefault(),
                Soyadi = db.OgrencilerTbl.Where(x => x.OgrenciID == OgcDegTbl.OgrenciID).Select(x => x.Soyadi).FirstOrDefault(),
                YakaNo = db.OgrencilerTbl.Where(x => x.OgrenciID == OgcDegTbl.OgrenciID).Select(x => x.YakaNo).FirstOrDefault(),
                FotografAdresi = db.OgrencilerTbl.Where(x => x.OgrenciID == OgcDegTbl.OgrenciID).Select(x => x.FotografAdresi).FirstOrDefault(),
                EOYili=db.EOYiliTbl.Where(x=>x.EOYiliID==p.EOYiliID).Select(x=>x.EOYili).FirstOrDefault(),
                DonemAdi=db.DonemlerTbl.Where(x=>x.Donem==p.Donem).Select(x=>x.DonemAdi).FirstOrDefault(),
                OgrenciDegListe= modelOgrenciDegerlendirmeListe,
            };
            return View("OgcDegerlendirmeListelemeForm", modelOgrenciDegerlendirmeListeSartlari);
        }


        [HttpGet]
        public IActionResult TumOgrenciDegerlendirmelerimiGetirForm()
        {
            OgrenciGetirFormVM OgrenciGetirForm = new OgrenciGetirFormVM();

            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var PerTC = HttpContext.Session.GetString("PerTC");
            var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();

            OgrenciGetirForm.SiniflarListe = new SelectList(db.SiniflarTbl, "Sinif", "SinifAdi");
            OgrenciGetirForm.KisimlarListe = new SelectList(db.KisimlarTbl, "KisimAdi", "KisimAdi");
            OgrenciGetirForm.EOYiliListe = new SelectList(db.EOYiliTbl, "EOYiliID", "EOYili");
            OgrenciGetirForm.DonemlerListe = new SelectList(db.DonemlerTbl, "Donem", "DonemAdi");
            OgrenciGetirForm.PerID = PerID;

            return View(OgrenciGetirForm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TumOgrenciDegerlendirmelerimiListele(OgrenciGetirFormVM model)
        {
            var PerTC = HttpContext.Session.GetString("PerTC");
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.UserName = UserName;
            ViewBag.RoleName = RoleName;

            var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();

            var TumOgcDegListe = db.OgrenciDegerlendirmeleriTbl.Include(OgcList => OgcList.OgrencilerTbl).Where(OgcList => OgcList.EOYiliID == model.EOYiliID && OgcList.Donem == model.Donem).Include(OgcList => OgcList.OgrenciDegerlendirmeTurleriTbl).Include(OgcList => OgcList.PersonelTbl).Where(OgcList => OgcList.PerID == model.PerID).Select(OgcList => new TumOgcDegListeFormVM
            {
                OgrenciID = OgcList.OgrencilerTbl.OgrenciID,
                YakaNo = OgcList.OgrencilerTbl.YakaNo,
                Adi = OgcList.OgrencilerTbl.Adi,
                Soyadi = OgcList.OgrencilerTbl.Soyadi,
                FotografAdresi = OgcList.OgrencilerTbl.FotografAdresi,
                Sinif = OgcList.OgrencilerTbl.Sinif,
                KisimAdi = OgcList.OgrencilerTbl.KisimAdi,

                DegerlendirmeID = OgcList.DegerlendirmeID,
                DegTurID = OgcList.OgrenciDegerlendirmeTurleriTbl.DegTurID,
                TurAdi = OgcList.OgrenciDegerlendirmeTurleriTbl.TurAdi,
                TarihSaat = OgcList.TarihSaat,
                Degerlendirme = OgcList.Degerlendirme,
            //}).OrderByDescending(x => x.TarihSaat).ThenBy(x=>x.OgrenciID).ToList(); //Yavaşlama yapıyor
            }).ToList();

        var modelTumOgcDegListe = new TumOgcDegListelemeVM
            {
                TumOgrenciDegListe=TumOgcDegListe,
                EOYiliID = model.EOYiliID,
                EOYili= db.EOYiliTbl.Where(x => x.EOYiliID == model.EOYiliID).Select(x => x.EOYili).FirstOrDefault(),
                Donem= model.Donem,
                DonemAdi= db.DonemlerTbl.Where(x => x.Donem == model.Donem).Select(x => x.DonemAdi).FirstOrDefault(),
                PerID=PerID, 
            }; 

            return View(modelTumOgcDegListe);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TumOgrenciDegerlendirmeDelete(long id, OgrenciGetirFormVM model)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            var PerTC = HttpContext.Session.GetString("PerTC");

            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;

            var Degerlendirmevalue = ogrencidegerlendirmemanager.GetByID(id);
            ogrencidegerlendirmemanager.OgrenciDegerlendirmeDelete(Degerlendirmevalue);

            var PerID = db.PersonelTbl.Where(x => x.PersonelTC == PerTC).Select(x => x.PerId).FirstOrDefault();

            var TumOgcDegListe = db.OgrenciDegerlendirmeleriTbl.Include(OgcList => OgcList.OgrencilerTbl).Where(OgcList => OgcList.EOYiliID == model.EOYiliID && OgcList.Donem == model.Donem).Include(OgcList => OgcList.OgrenciDegerlendirmeTurleriTbl).Include(OgcList => OgcList.PersonelTbl).Where(OgcList => OgcList.PerID == model.PerID).Select(OgcList => new TumOgcDegListeFormVM
            {
                OgrenciID = OgcList.OgrencilerTbl.OgrenciID,
                YakaNo = OgcList.OgrencilerTbl.YakaNo,
                Adi = OgcList.OgrencilerTbl.Adi,
                Soyadi = OgcList.OgrencilerTbl.Soyadi,
                FotografAdresi = OgcList.OgrencilerTbl.FotografAdresi,
                Sinif = OgcList.OgrencilerTbl.Sinif,
                KisimAdi = OgcList.OgrencilerTbl.KisimAdi,

                DegerlendirmeID = OgcList.DegerlendirmeID,
                DegTurID = OgcList.OgrenciDegerlendirmeTurleriTbl.DegTurID,
                TurAdi = OgcList.OgrenciDegerlendirmeTurleriTbl.TurAdi,
                TarihSaat = OgcList.TarihSaat,
                Degerlendirme = OgcList.Degerlendirme,
                //}).OrderByDescending(x => x.TarihSaat).ThenBy(x => x.OgrenciID).ToList();  //Yavaşlama yapıyor
            }).ToList();

            var modelTumOgcDegListe = new TumOgcDegListelemeVM
            {
                TumOgrenciDegListe = TumOgcDegListe,
                EOYiliID = model.EOYiliID,
                EOYili = db.EOYiliTbl.Where(x => x.EOYiliID == model.EOYiliID).Select(x => x.EOYili).FirstOrDefault(),
                Donem = model.Donem,
                DonemAdi = db.DonemlerTbl.Where(x => x.Donem == model.Donem).Select(x => x.DonemAdi).FirstOrDefault(),
                PerID = PerID,
            };

            return View("TumOgrenciDegerlendirmelerimiListele", modelTumOgcDegListe);

        }
    }
}
