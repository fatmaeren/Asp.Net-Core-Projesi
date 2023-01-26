using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Core_ProjeGerçek.ViewComponents.Contact
{
    public class SendMessage:ViewComponent
    {
        MessageManager cnm = new MessageManager(new EfMessageDal());

        [HttpGet]
        public IViewComponentResult Invoke()
        {
           
            return View();
        }

      
    }
}
