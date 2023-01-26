using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_ProjeGerçek.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        FeatureManager fm = new FeatureManager(new EfFeatureDal());
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.d1 = "Proje Güncelle";
            ViewBag.d2 = "Portfolyo Sayfası";
            ViewBag.d3 = "Proje Güncelleme Sayfası";
            var deger = fm.GetByID(1);
            return View(deger);
        }

        [HttpPost]
        public IActionResult Index(Feature p)
        {
            fm.Update(p);
            return RedirectToAction("Index", "Default");
        }
    }
}
