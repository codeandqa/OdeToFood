using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        public ActionResult Index(string name)
        {
            var model = new GreentingViewModel();
            model.Message = ConfigurationManager.AppSettings["message"];
            model.Name = name ?? "Unknown";
            return View(model);
        }
    }
}