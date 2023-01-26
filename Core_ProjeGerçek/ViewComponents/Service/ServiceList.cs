using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using System.Net;

namespace Core_ProjeGerçek.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {
        ServiceManager abm = new ServiceManager(new EfServiceDal());
        public IViewComponentResult Invoke()
        {
            var values = abm.TGetList();
            return View(values);
        }
    }
}
