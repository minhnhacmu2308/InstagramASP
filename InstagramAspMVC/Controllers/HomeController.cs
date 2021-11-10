using InstagramAspMVC.Daos;
using InstagramAspMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstagramAspMVC.Controllers
{
    public class HomeController : Controller
    {
        PostDao postDao = new PostDao();
        UserDao userDao = new UserDao();
        public ActionResult Index()
        {
            var user = (User)Session["User"];
            if(user == null)
            {
                return RedirectToAction("Login","Authentication");
            }
            else
            {
                var obj = postDao.getNewFeed(user.id_user);
                ViewBag.listUser = userDao.getUserUnfollow(user.id_user,5);
                return View(obj);
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