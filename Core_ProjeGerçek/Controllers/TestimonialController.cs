using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_ProjeGerçek.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        TestimonialManager tsm = new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
           var values= tsm.TGetList();
            return View(values);
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var deger= tsm.GetByID(id);
            tsm.TDelete(deger);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var values = tsm.GetByID(id);
            return View(values);

        }

        [HttpPost]

        public IActionResult UpdateTestimonial(Testimonial p)
        {
            tsm.Update(p);
            return RedirectToAction("Index");   

        }
    }
}
