using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_ProjeGerçek.ViewComponents.Dashboard
{
    public class StatisticsDashboard2:ViewComponent
    {
        Context c=new Context();
        public IViewComponentResult Invoke()
        {

            ViewBag.v1 = c.Portfolios.Count();
            ViewBag.v2 = c.Portfolios.Sum(x => x.Value).ToString();
            ViewBag.v3=c.Messages.Count();

            return View(); 
        }
    }
}
