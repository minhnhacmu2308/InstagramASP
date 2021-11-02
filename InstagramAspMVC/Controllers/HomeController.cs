using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstagramAspMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = Session["User"];
            if(user == null)
            {
                return RedirectToAction("Login","Authentication");
            }
            else
            {
                return View();
            }       
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}