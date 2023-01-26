using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;

namespace Core_ProjeGerçek.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageRSController : Controller
    {
        WriterMessageManager msm = new WriterMessageManager(new EfWriterMessageDal());

        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "mehmetkeskin@gmail.com";
            var values = msm.GetListReceiverMessage(p);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string p;
            p = "mehmetkeskin@gmail.com";
            var values = msm.GetListSenderMessage(p);
            return View(values);
        }
        public IActionResult WriterMessageDetails(int id)
        {
            var values = msm.GetByID(id);
            return View(values);
        }
        public IActionResult DeleteMessageWriter(int id)
        {
            var values = msm.GetByID(id);
            msm.TDelete(values);
            return RedirectToAction("Index","AdminMessage");
        }

        [HttpGet]
        public IActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddMessage(WriterMessage p)
        {
            Context c = new Context();
            var nameReciever = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = nameReciever;
            p.Sender = "mehmetkeskin@gmail.com";
            p.SenderName = "Fatma Eren";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            msm.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }
    }
}
