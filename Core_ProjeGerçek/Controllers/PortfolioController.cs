using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_ProjeGerçek.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        PortfolioManager pm = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
           
            var values=pm.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult AddPortfolio(Portfolio p) 
        {
            PortfolioValidator pv = new PortfolioValidator();
            ValidationResult results = pv.Validate(p);
            if (results.IsValid)
            {
                pm.Insert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors) 
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
           
           
        }

        public IActionResult RemovePortfolio(int id)
        {
            var deger= pm.GetByID(id);
            pm.Delete(deger);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
          
            var deger = pm.GetByID(id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio p)
        {
            

            PortfolioValidator pv = new PortfolioValidator();
            ValidationResult results = pv.Validate(p);
            if (results.IsValid)
            {
                pm.Update(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();



            
        }
    }
}
