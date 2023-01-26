using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Markup;

namespace Core_ProjeGerçek.ViewComponents.Experience
{
    public class ExperienceList:ViewComponent
    {
        ExperienceManager exm = new ExperienceManager(new EfExperienceDal());
        public IViewComponentResult Invoke()
        {
            var values = exm.TGetList();
            return View(values);
        }
       
    }
}
