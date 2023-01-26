using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_ProjeGerçek.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        MessageManager msm = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            var values= msm.TGetList();
            return View(values);
        }

        public IActionResult MessageDetails(int id) 
        {
            var values=msm.GetByID(id);
            return View(values); 
        }

        public IActionResult DeleteMessage(int id)
        {
            var deger=msm.GetByID(id);
            msm.TDelete(deger);
            return RedirectToAction("Index");
        }
    }
}
