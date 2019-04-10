using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ParserTestApps.Areas.Default.Controllers
{
    public class CarController : DefaultController
    {
        // GET: Car
        public ActionResult Index()
        {
            var roles = Repository.Carss.ToList();
            return View(roles);
        }
        public ActionResult Register()
        {
            var regCar = new Cars();
            return View(regCar);
        }
    }
}