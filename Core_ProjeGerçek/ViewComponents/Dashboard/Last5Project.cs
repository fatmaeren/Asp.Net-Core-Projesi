using DataAccessLayer.Concrete;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Core_ProjeGerçek.ViewComponents.Dashboard
{
    public class Last5Project: ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            
            ViewBag.Nesne = c.Portfolios.OrderBy(x => x.PortfolioID).Take(5).ToList();

           
            return View();
        }
    }
}
