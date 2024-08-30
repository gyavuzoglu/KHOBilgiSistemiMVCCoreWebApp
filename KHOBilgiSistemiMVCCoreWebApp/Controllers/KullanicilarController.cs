using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace KHOBilgiSistemiMVCCoreWebApp.Controllers
{
    public class KullanicilarController : Controller
    {
        Context c=new Context();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserTbl p)
        {
            if (p.PersonelTC == null)
            {
                
                var bilgiler = c.UserTbl.FirstOrDefault(x => x.OgrenciTC == p.OgrenciTC && x.Password == p.Password);
            }
            else
            {
                var bilgiler = c.UserTbl.FirstOrDefault(x => x.PersonelTC == p.PersonelTC && x.Password == p.Password);
            }
            
            if(bilgiler!=null) {
            {

            }
            return View();
        }
    }
}
