using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace InstagramAspMVC.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
       
        public ActionResult Index()
        {
            string result = (string)Session["Admin"];
            if (string.IsNullOrEmpty(result))
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            else
            {
                return View();
            }

        }
    }
}