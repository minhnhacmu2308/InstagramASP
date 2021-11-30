using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstagramAspMVC.Controllers.Admin
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult Index(string mess)
        {
            ViewBag.Msg = mess;
            return PartialView();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            var email = form["email"];
            var pass = form["pass"];
            if(email =="admin@gmail.com" && pass == "123456789")
            {
                Session.Add("Admin", "success");
                return RedirectToAction("Index","AdminHome");
            }
            else
            {
                return RedirectToAction("Index", new { mess = "1" });
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("Admin");
            return RedirectToAction("Index");
        }
    }
}