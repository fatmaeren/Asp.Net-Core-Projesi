using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_ProjeGerçek.ViewComponents.Portfolio
{
    public class SlideList : ViewComponent
    {
        PortfolioManager prm = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var values = prm.GetList();
            return View(values);
        }
    }
}
