using BusinessLayer.Concrete;
using Core_ProjeGerçek.Areas.Writer.Models;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_ProjeGerçek.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area ("Writer")]
    [Route("Writer/[Controller]/[action]")]

    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            this._userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(KullanıcıRegisterViewModel p)
        {
            if(ModelState.IsValid)
            {
                WriterUser w = new WriterUser()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Mail,
                    UserName = p.UserName,
                    ImageUrl = p.ImageUrl
                };
                var result = await _userManager.CreateAsync(w, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var x in result.Errors)
                    {
                        ModelState.AddModelError("", x.Description);
                    }
                }
            }
            return View();
        }
    }
}
