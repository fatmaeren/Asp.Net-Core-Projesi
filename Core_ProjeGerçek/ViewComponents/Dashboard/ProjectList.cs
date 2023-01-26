using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_ProjeGerçek.ViewComponents.Dashboard
{
    public class ProjectList:ViewComponent
    {
        PortfolioManager prm = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var deger= prm.GetList();
            return View(deger);
        }
    }
}
