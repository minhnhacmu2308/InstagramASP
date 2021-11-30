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
        FollowDao followDao = new FollowDao();
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
                ViewBag.listFollowing = followDao.getListFollowing(user.id_user);
                return View(obj);
            }       
        }
        [HttpPost]
        public ActionResult Comment(FormCollection form)
        {
            var user = (User)Session["User"];
            var text = form["content"];
            var post = form["post"];
            Comment comment = new Comment();
            comment.text = text;
            comment.id_user = user.id_user;
            comment.id_post = Int32.Parse(post);
            comment.createdAt = DateTime.Now;
            comment.parent = 0;
            comment.status = 1;
            postDao.addComment(comment);
            return RedirectToAction("Index");
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