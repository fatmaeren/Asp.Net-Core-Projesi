using Microsoft.AspNetCore.Mvc;

namespace Core_ProjeGerçek.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult ParticalSideBar()
        {
            return PartialView();
        }

        public PartialViewResult ParticalFooter()
        {
            return PartialView();
        }

        public PartialViewResult ParticalNavbar()
        {
            return PartialView();
        }
        public PartialViewResult ParticalHeader()
        {
            return PartialView();
        }
        public PartialViewResult ParticalScript()
        {
            return PartialView();
        }
        public PartialViewResult NavigationPartical() 
        {
            return PartialView();
        }
        public PartialViewResult NewSidebar() 
        {
            return PartialView();
        }
    }
}
