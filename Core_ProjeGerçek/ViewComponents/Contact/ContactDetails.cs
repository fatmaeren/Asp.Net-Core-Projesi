using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_ProjeGerçek.ViewComponents.Contact
{
    public class ContactDetails: ViewComponent
    {
        ContactManager cnm = new ContactManager(new EfContectDal());
        public IViewComponentResult Invoke()
        {
            var deger = cnm.TGetList();
            return View(deger);
        }
    }
}
