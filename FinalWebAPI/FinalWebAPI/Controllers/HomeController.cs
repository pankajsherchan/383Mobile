using FinalWebAPI.APIHelper;
using FinalWebAPI.Barcode;
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

            //BarcodeGenerator a = new BarcodeGenerator();
            //a.generate();

            //MovieAPI1 a = new MovieAPI1();
            //a.Get();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
