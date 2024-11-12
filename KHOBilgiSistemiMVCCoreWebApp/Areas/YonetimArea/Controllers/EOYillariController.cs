using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.YonetimArea.Controllers
{
    [Authorize(Roles = "Yönetici")]
    [Area("YonetimArea")]
    public class EOYillariController : Controller
    {
        EOYiliManager eoyilism = new EOYiliManager(new EfEOYiliRepository());

        [HttpGet]
        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            var values = eoyilism.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult EOYiliAdd()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EOYiliAdd(EOYiliTbl p)
        {
            EOYiliValidator validationRules = new EOYiliValidator();
            ValidationResult validationResult = validationRules.Validate(p);
            if (validationResult.IsValid)
            {
                eoyilism.EOYiliAdd(p);
                return RedirectToAction("Index", "EOYillari");

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

        public IActionResult EOYiliDelete(int id)
        {

            var eoyilivalue = eoyilism.TGetByID(id);
            eoyilism.EOYiliDelete(eoyilivalue);
            return RedirectToAction("Index", "EOYillari");
        }
        [HttpGet]
        public IActionResult EOYiliGet(int id)
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            var eoyilivalue = eoyilism.TGetByID(id);
            return View(eoyilivalue);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EOYiliUpdate(EOYiliTbl p)
        {
            eoyilism.EOYiliUpdate(p);
            return RedirectToAction("Index", "EOYillari");
        }
    }
}
