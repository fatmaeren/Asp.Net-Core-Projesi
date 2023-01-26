﻿using BusinessLayer.Concrete;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_ProjeGerçek.Areas.Writer.View_Components
{
    public class Navbar: ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public Navbar(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.ImageUrl;
            return View(values);
        }
    }
}
