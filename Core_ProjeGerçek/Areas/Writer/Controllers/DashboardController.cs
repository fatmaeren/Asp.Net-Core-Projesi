using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core_ProjeGerçek.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;

            //api
            string api = "397d9ab5c4dec660ec091dbd9fd2fdff";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&appid=397d9ab5c4dec660ec091dbd9fd2fdff&mode=xml&lang=tr&units=metric&apid=" + api;
            XDocument document = XDocument.Load(connection); 
            ViewBag.V5= document.Descendants("temperature").ElementAt(0).Attribute("value").Value;    


            Context c= new Context();
            ViewBag.v1 = c.WriterMessages.Where(x=> x.Receiver==values.Email).Count();
            ViewBag.v2 =c.Duyurulars.Count();
            ViewBag.v3 =c.Users.Count();
            ViewBag.v4 =c.Skills.Count();
            return View();
        }
    }
}
