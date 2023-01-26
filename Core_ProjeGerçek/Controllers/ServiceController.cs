using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Core_ProjeGerçek.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Core_ProjeGerçek.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        ServiceManager svm = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
           
            var deger= svm.TGetList();
            return View(deger);
        }
        [HttpGet]
        public IActionResult AddService() 
        {
           
            return View();
        }
        [HttpPost]

        public IActionResult AddService(ServiceEkle p)
        {
            Service f = new Service();
        
            
            if (p.ImageUrl != null)
            {
              
                var extension = Path.GetExtension(p.ImageUrl.FileName);
                var imagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/userimage/", imagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageUrl.CopyTo(stream);
               
                f.ImageUrl = "~/userimage/" + imagename;
               
            }
            f.Title = p.Title;
           
                svm.TAdd(f);
                return RedirectToAction("Index");
           
           
           
        }
        public IActionResult RemoveService(int id)
        {
            var deger=svm.GetByID(id);
            svm.TDelete(deger);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var deger = svm.GetByID(id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult UpdateService(ServiceEkle p)
        {
            Service f = svm.GetByID(p.ServiceID);
           

            if (p.ImageUrl != null)
            {

                var extension = Path.GetExtension(p.ImageUrl.FileName);
                var imagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userimage/", imagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageUrl.CopyTo(stream);

                f.ImageUrl = "~/userimage/" + imagename;

            }

           f.Title= p.Title;
           svm.Update(f);
           return RedirectToAction("Index");
           
        }
    }
}
