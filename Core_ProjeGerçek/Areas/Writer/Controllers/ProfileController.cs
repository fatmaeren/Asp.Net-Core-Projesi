using BusinessLayer.Concrete;
using Core_ProjeGerçek.Areas.Writer.Models;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Core_ProjeGerçek.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[Controller]/[action]")]

    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value= await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model= new UserEditViewModel();
            model.Name= value.Name;
            model.Surname= value.Surname;
            model.PictureUrl = value.ImageUrl;
            return View(model);
        }

        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Picture != null)
            {
                var resource= Directory.GetCurrentDirectory();
                var extension= Path.GetExtension(p.Picture.FileName);
                var imagename= Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimage/" + imagename;
                var stream= new FileStream(savelocation, FileMode.Create);
                await p.Picture.CopyToAsync(stream);
                user.ImageUrl=imagename;
            }
            user.Name= p.Name;
            user.Surname= p.Surname;
            user.PasswordHash= _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
