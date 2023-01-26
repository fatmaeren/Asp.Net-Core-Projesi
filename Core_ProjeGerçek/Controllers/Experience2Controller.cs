using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_ProjeGerçek.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager exm = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExperienceList()
        {
            var value= JsonConvert.SerializeObject(exm.TGetList());
            return Json(value);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            exm.TAdd(p);
            var value = JsonConvert.SerializeObject(p);
            return Json(value);
        }

        public IActionResult GetById(int ExperienceID)
        {
            var p = exm.GetByID(ExperienceID);
            var values= JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult RemoveExperience(int id)
        {
            var p = exm.GetByID(id);
            exm.TDelete(p);
            return NoContent();
        }
    }
}
