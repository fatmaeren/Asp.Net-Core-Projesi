using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core_ProjeGerçek.Areas.Writer.Controllers
{
    [Area ("Writer")]
    [Route ("Writer/Message")]
    public class MessageController : Controller
    {
        WriterMessageManager rmm = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> _userManager;

        public DateTime ConvertTo { get; private set; }

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messagelist = rmm.GetListReceiverMessage(p);
            return View(messagelist);
        }

        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p) 
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messagelist = rmm.GetListSenderMessage(p);
            return View(messagelist);
        }

        [Route("MessageDetails/{id}")]
        public IActionResult MessageDetails(int id)
        {
            var value = rmm.GetByID(id);
            return View(value);
        }

  
        [HttpGet]
        [Route("")]
        [Route("AddMessage")]

        public IActionResult AddMessage()
        {
            return View(); 
        }

        [HttpPost]
        [Route("")]
        [Route("AddMessage")]

        public async Task<IActionResult> AddMessage(WriterMessage p)
        {
            var value= await _userManager.FindByNameAsync(User.Identity.Name);
           string mail= value.Email;
           string Name = value.Name + " " + value.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = Name;
            Context c = new Context();
             var nameReciever= c.Users.Where(x => x.Email == p.Receiver).Select(y=>y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName= nameReciever;
            rmm.TAdd(p);
            return RedirectToAction("SenderMessage");
        }
    }
}
