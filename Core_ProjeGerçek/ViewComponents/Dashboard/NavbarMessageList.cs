using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_ProjeGerçek.ViewComponents.Dashboard
{
    public class NavbarMessageList : ViewComponent
    {
        WriterMessageManager wmm = new WriterMessageManager(new EfWriterMessageDal());
        public IViewComponentResult Invoke()
        {
            string p = "mehmetkeskin@gmail.com";
            var values = wmm.GetListReceiverMessage(p).OrderByDescending(x => x.ID).Take(3).ToList();
            return View(values);
        }
    }
}
