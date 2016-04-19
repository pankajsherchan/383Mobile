using FinalWebAPI.APIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //MovieAPI1 a = new MovieAPI1();
            //a.Get();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
