using Microsoft.AspNetCore.Mvc;

namespace Core_ProjeGerçek.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
