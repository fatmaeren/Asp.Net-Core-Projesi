using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_ProjeGerçek.ViewComponents.Dashboard
{
    public class MessageList: ViewComponent
    {
        MessageManager msm = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
           var value= msm.TGetList();
            return View(value);
        }
    }
}
