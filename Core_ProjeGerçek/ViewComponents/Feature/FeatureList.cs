using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_ProjeGerçek.ViewComponents.Feature
{
    public class FeatureList:ViewComponent
    {
        FeatureManager fr = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            var values=fr.TGetList();
            return View(values);
        }
    }
}
