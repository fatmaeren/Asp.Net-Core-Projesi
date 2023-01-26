using BusinessLayer.Concrete;
using Core_ProjeGerçek.Models;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Core_ProjeGerçek.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager exm = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
          
            var deger= exm.TGetList();
            return View(deger);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
          
            return View();

        }
        [HttpPost]
        public IActionResult AddExperience(DeneyimEkle p) 
        {
            Experience f = new Experience();


            if (p.ImageUrl != null)
            {

                var extension = Path.GetExtension(p.ImageUrl.FileName);
                var imagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userimage/", imagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageUrl.CopyTo(stream);

                f.ImageUrl = "~/userimage/" + imagename;

            }
            f.Name = p.Name;
            f.Description = p.Description;
            f.ExperienceAd= p.ExperienceAd;
            string date = p.Date;
            f.Date = date;
            exm.TAdd(f);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteExperience(int id)
        {
            var deger=exm.GetByID(id);
            exm.TDelete(deger);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
           
            var deger = exm.GetByID(id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult UpdateExperience(DeneyimEkle p)
        {
           
            Experience f = exm.GetByID(p.ExperienceID);


            if (p.ImageUrl != null)
            {

                var extension = Path.GetExtension(p.ImageUrl.FileName);
                var imagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userimage/", imagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageUrl.CopyTo(stream);

                f.ImageUrl = "~/userimage/" + imagename;

            }
            f.Name = p.Name;
            f.Description = p.Description;
            f.ExperienceAd = p.ExperienceAd;
            string date = p.Date;
            f.Date = date;
            exm.Update(f);
            return RedirectToAction("Index");

        }
    }
}
