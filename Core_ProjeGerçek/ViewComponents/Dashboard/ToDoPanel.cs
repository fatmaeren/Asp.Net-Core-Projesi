using DataAccessLayer.Concrete;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace Core_ProjeGerçek.ViewComponents.Dashboard
{
    public class ToDoPanel: ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke() 
        {
            //ViewBag.Nesne = ToDoList.OrderBy(x=>x.ID).Take(5).ToList();
            return View(); 
        }
    }
}

