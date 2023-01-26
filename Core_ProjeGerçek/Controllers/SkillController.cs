using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_ProjeGerçek.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        SkillManager skm = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            ViewBag.d1 = "Yetenek Listem";
            ViewBag.d2 = "Anasayfa";
            ViewBag.d3 = "Yetenek Sayfası";
            var values = skm.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.d1 = "Yetenek Ekleme Formu";
            ViewBag.d2 = "Yetenekler";
            ViewBag.d3 = "Yetenek Ekleme Sayfası";
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill p) 
        {
            skm.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveSkill(int id)
        {
            var deger=skm.GetByID(id);
            skm.TDelete(deger);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateSkill(int id) 
        {
            ViewBag.d1 = "Yetenek Güncelleme Formu";
            ViewBag.d2 = "Yetenekler";
            ViewBag.d3 = "Yetenek Güncelleme Sayfası";
            var deger = skm.GetByID(id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill p)
        {
            skm.Update(p);
            return RedirectToAction("Index");
        }
    
    }
}
