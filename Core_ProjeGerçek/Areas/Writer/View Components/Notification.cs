using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core_ProjeGerçek.Areas.Writer.View_Components
{
    public class Notification: ViewComponent
    {
        DuyurularManager dym = new DuyurularManager(new EfDuyurularDal());
     

        public IViewComponentResult Invoke()
        {
            var values = dym.TGetList().Take(5).ToList();
            return View(values);
        }
    }
}
