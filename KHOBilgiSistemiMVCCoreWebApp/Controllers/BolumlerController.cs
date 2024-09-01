using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Controllers
{
    public class BolumlerController : Controller
    {
        BolumlerManager bolumlersm = new BolumlerManager(new EfBolumlerRepository());
        public IActionResult Index()
        {
            var values = bolumlersm.GetListAll();
            return View(values);
        }
        public IActionResult BolumlerListeleme()
        {
            var values = bolumlersm.GetListAll();
            return View(values);
        }

    }
}
