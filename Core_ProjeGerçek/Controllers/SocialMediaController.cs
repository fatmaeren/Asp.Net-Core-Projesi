using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_ProjeGerçek.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        SocialMediaManager smm = new SocialMediaManager(new EfSocialMediaDal());
        public IActionResult Index()
        {
            var values=smm.TGetList();
            return View(values);
        }
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = smm.GetByID(id);
            smm.TDelete(values);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia p) 
        {
            smm.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var values = smm.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia p)
        {
            smm.Update(p);
            return RedirectToAction("Index");
        }
    }
}
