using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_ProjeGerçek.Areas.Writer.Controllers
{

    [Area("Writer")]
    public class DefaultController : Controller
    {
        DuyurularManager dr = new DuyurularManager(new EfDuyurularDal());
        
        public IActionResult Index()
        {
            var deger = dr.TGetList();
            return View(deger);
        }

        [HttpGet]
        public IActionResult DuyuruDetay(int id)
        {
            Duyurular deger=dr.GetByID(id);
            return View(deger);
        }
    }
}
