using MVC_ParserTestApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ParserTestApps.Areas.Default.Controllers
{
    public class HomeController : DefaultController
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Parse()
        {
            ExistParser exist = new ExistParser();

            var listuri = exist.Parse();
            foreach (var node in listuri)
            {
                var anyUser = Repository.CarModelss.Where(p => string.Compare(p.BrandName, node.BrandName) == 0 && string.Compare(p.ModelName, node.ModelName) == 0).Count();

                if (anyUser > 0)
                {
                    ModelState.AddModelError("ModelName", "Такая модель уже зарегестрирована ");
                }
                else
                {
                    ModelState.Remove("ModelName");
                }
                if (ModelState.IsValid)
                {
                    var CarModels = node;
                    Repository.CreateCarModel(CarModels);
                }
            }
            return View(listuri);
        }

        [HttpPost]
        public ActionResult Parse(string brand = null)
        {
            ExistParser exist = new ExistParser();
            if(!string.IsNullOrWhiteSpace(brand))
            {
                var listuri = exist.Parse(brand);
                foreach (var node in listuri)
                {
                    var anyUser = Repository.CarModelss.Where(p => string.Compare(p.BrandName, node.BrandName) == 0 && string.Compare(p.ModelName, node.ModelName) == 0).Count();

                    if (anyUser > 0)
                    {
                        ModelState.AddModelError("ModelName", "Такая модель уже зарегестрирована ");
                    }
                    else
                    {
                        ModelState.Remove("ModelName");
                    }
                    if (ModelState.IsValid)
                    {
                        var CarModels = node;
                        Repository.CreateCarModel(CarModels);
                    }

                }
                return View(listuri);
            }
           
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}