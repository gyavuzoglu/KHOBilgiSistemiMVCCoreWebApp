using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace KHOBilgiSistemiMVCCoreWebApp.Areas.YonetimArea.Controllers
{

    [Authorize(Roles = "Yönetici")]
    [Area("YonetimArea")]
    public class AskeriSiniflarController : Controller
    {
        AskeriSiniflarManager asm = new AskeriSiniflarManager(new EfAskeriSiniflarRepository());
        [HttpGet]


        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            var values = asm.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AskeriSinifAdd()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            var RoleName = HttpContext.Session.GetString("RoleName");
            ViewBag.RoleName = RoleName;
            ViewBag.UserName = UserName;
            return View();
        }
        [HttpPost]
        public IActionResult AskeriSinifAdd(AskeriSiniflarTbl p)
        {
            AskeriSinifValidator validationRules = new AskeriSinifValidator();
            ValidationResult validationResult = validationRules.Validate(p);
            if (validationResult.IsValid)
            {
                asm.AskeriSinifAdd(p);
                return RedirectToAction("Index", "AskeriSiniflar");

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
    }
}
