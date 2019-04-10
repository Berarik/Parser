using MVC_ParserTestApps.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ParserTestApps.Areas.Default.Controllers
{
    public class CarModelController : DefaultController
    {


        // GET: Test
        //public ActionResult Index()
        //{
        //    var carmodels = Repository.CarModelss.ToList();
        //    return View(carmodels);
        //}
        public ActionResult Index(int page = 1)
        {
            ExistParser pasd = new ExistParser();
                pasd.Parse("Tesla");
            ViewData.Add("List", Repository.CarModelss);
            var data = new PageableData<CarModels>(Repository.CarModelss, page, 30);
            return View(data);           
        }
       
        [HttpGet]
        public ActionResult Register()
        {
            var newUser = new CarModels();
            
            return View(newUser);
        }

        [HttpPost]
        public ActionResult Register(CarModels carmodel)
        {
            var anyUser = Repository.CarModelss.Where(p => string.Compare(p.BrandName, carmodel.BrandName) == 0 && string.Compare(p.ModelName, carmodel.ModelName) == 0).Count();
            if (anyUser>0)
            {
                ModelState.AddModelError("ModelName", "Такая модель уже зарегестрирована ");
            }
            if (ModelState.IsValid)
            {
                var CarModels = carmodel;

                Repository.CreateCarModel(CarModels);                
                return View(carmodel);
            }
            return View(carmodel);
        }
    }
}