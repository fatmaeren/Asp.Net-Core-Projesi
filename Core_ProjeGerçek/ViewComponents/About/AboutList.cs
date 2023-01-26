using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_ProjeGerçek.ViewComponents.About
{
    public class AboutList:ViewComponent
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        public IViewComponentResult Invoke() 
        {
            var values = abm.TGetList();
            return View(values);
        }
    }
}
