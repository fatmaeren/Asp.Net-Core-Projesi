using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Core_ProjeGerçek.ViewComponents.Skill
{
    public class SkillList: ViewComponent
    {
        SkillManager skl = new SkillManager(new EfSkillDal());
        public IViewComponentResult Invoke()
        {
            var values = skl.TGetList();
            return View(values);
        }
    }
}
