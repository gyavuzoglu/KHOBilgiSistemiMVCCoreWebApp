using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Controllers
{
    public class BirimlerController : Controller
    {
        BirimlerManager birimlersm = new BirimlerManager(new EfBirimlerRepository());
        [HttpGet]
        public IActionResult BirimAdd()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = birimlersm.GetListAll();
            return View(values);
        }
        
        [HttpPost]
        public IActionResult BirimAdd(BirimlerTbl p)
        {
            BirimValidator validationRules = new BirimValidator();
            ValidationResult validationResult = validationRules.Validate(p);
            if (validationResult.IsValid)
            {
                birimlersm.BirimAdd(p);
                return RedirectToAction("Index", "Birimler");

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

        public IActionResult BirimDelete(int id)
        {
            var birimvalue=birimlersm.TGetByID(id);
            birimlersm.BirimDelete(birimvalue);
            return RedirectToAction("Index","Birimler");
        }
    }
}
