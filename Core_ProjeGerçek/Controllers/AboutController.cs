using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_ProjeGerçek.Controllers
{
    [Authorize (Roles ="Admin")]
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.d1 = "Hakkımda Bilgisi Formu";
            ViewBag.d2 = "Anasayfa";
            ViewBag.d3 = "Hakkımda";
            var values=abm.GetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(About p)
        {
            abm.Update(p);
            return RedirectToAction("Index" , "Default");
        }
    }
}
