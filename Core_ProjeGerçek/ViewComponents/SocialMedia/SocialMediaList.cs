using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_ProjeGerçek.ViewComponents.SocialMedia
{
    public class SocialMediaList :ViewComponent
    {
        SocialMediaManager fr = new SocialMediaManager(new EfSocialMediaDal());
        public IViewComponentResult Invoke()
        {
            var values = fr.TGetList();
            return View(values);
        }
    }
}
