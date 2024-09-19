using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.YonetimArea.Controllers
{
    [Authorize(Roles = "Yönetici")]
    [Area("YonetimArea")]
    public class BolumlerController : Controller
    {
        BolumlerManager bolumlersm = new BolumlerManager(new EfBolumlerRepository());
        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            var values = bolumlersm.GetListAll();
            return View(values);
        }
        public IActionResult BolumlerListeleme()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            var values = bolumlersm.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult BolumAdd()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BolumAdd(BolumTbl p)
        {
            BolumValidator validationRules = new BolumValidator();
            ValidationResult validationResult = validationRules.Validate(p);
            if (validationResult.IsValid)
            {
                bolumlersm.BolumAdd(p);
                return RedirectToAction("Index", "Bolumler");

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

        public IActionResult BolumDelete(int id)
        {
           
            var bolumvalue = bolumlersm.TGetByID(id);
            bolumlersm.BolumDelete(bolumvalue);
            return RedirectToAction("Index", "Bolumler");
        }
        [HttpGet]
        public IActionResult BolumGet(int id)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            var bolumvalue = bolumlersm.TGetByID(id);
            return View(bolumvalue);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BolumUpdate(BolumTbl p)
        {
            bolumlersm.BolumUpdate(p);
            return RedirectToAction("Index", "Bolumler");
        }

    }
}
