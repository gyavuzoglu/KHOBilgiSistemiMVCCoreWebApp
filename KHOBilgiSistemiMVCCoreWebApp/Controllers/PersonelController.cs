using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Controllers
{
    public class PersonelController : Controller
    {
        PersonelManager pm=new PersonelManager(new EfPersonelRepository());
        public IActionResult Index()
        {
            var values=pm.GetPersonelListWithBirimler();
            return View(values);
        }
    }
}
