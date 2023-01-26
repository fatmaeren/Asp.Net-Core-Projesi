using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_ProjeGerçek.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContectController : Controller
    {
        ContactManager ctm = new ContactManager(new EfContectDal());
        [HttpGet]
        public IActionResult UpdateContact()
        {
            var values = ctm.GetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateContact(Contact p) 
        {
            ctm.Update(p);
            return RedirectToAction("Index","Default");
        }
    }
}
