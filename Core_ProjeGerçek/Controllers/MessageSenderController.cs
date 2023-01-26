using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_ProjeGerçek.Controllers
{
    public class MessageSenderController : Controller
    {
        MessageSenderManager msm = new MessageSenderManager(new EfMessageSenderDal());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListUser()
        {
            var values = JsonConvert.SerializeObject(msm.TGetList());
            return Json(values);
        }

        public IActionResult AddUser(WriterUser p)
        {
            msm.TAdd(p);
            var value = JsonConvert.SerializeObject(p);
            return Json(value);
        }
    }
}
