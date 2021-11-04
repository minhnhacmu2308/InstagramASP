using InstagramAspMVC.Daos;
using InstagramAspMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstagramAspMVC.Controllers
{
    public class UserController : Controller
    {
        UserDao userDao = new UserDao();
        FollowDao followDao = new FollowDao();
        PostDao postDao = new PostDao();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile() {
            var user = (User)Session["User"];
            var obj = userDao.getInformationByEmail(user.email);
            ViewBag.numberPost = postDao.getNumberPost(user.id_user);
            ViewBag.numberFollower = followDao.getNumberFollower(user.id_user);
            ViewBag.numberFollowing = followDao.getNumberFollowing(user.id_user);
            return View(obj);
        }

        public ActionResult EditProfile()
        {
            var user = (User)Session["User"];
            var obj = userDao.getInformationByEmail(user.email);
            return View(obj);
        }

        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            User userRequest = new User();
            userRequest.address = user.address;
            userRequest.email = user.email; 
            userRequest.status = 0;
            userRequest.phonenumber = user.phonenumber;
            userRequest.username = user.username;
            userRequest.gender = user.gender;
            userRequest.fullname = user.fullname;
            userRequest.id_user = user.id_user;
            userRequest.password = user.password;

            string phonenumberCurrent = userDao.getInformationByEmail(user.email).phonenumber;
            if (phonenumberCurrent.Equals(user.phonenumber))
            {
                userDao.update(userRequest);
                return RedirectToAction("EditProfile");
            }
            else
            {
                var checkPhonenumber = userDao.checkPhonenumberExist(user.phonenumber);
                if (checkPhonenumber != null)
                {
                    ViewBag.msg = "Phone number is existed";
                    return RedirectToAction("EditProfile");
                }
                else
                {
                    userDao.update(userRequest);
                    return RedirectToAction("EditProfile");
                }
            }
        }

        [HttpPost]
        public JsonResult ChangeImage(string email,HttpPostedFileBase file)
        {
              string reName = DateTime.Now.Ticks.ToString() + file.FileName;
              file.SaveAs(Server.MapPath("~/Content/Assests/images/" + reName));
              userDao.changeImage(email, reName);
              string urlImage = "/Content/Assests/images/" + reName;
              return Json(new { status = "OK", data = urlImage, msg = "thanhcong", JsonRequestBehavior.AllowGet });

        }
        [HttpPost]
        public JsonResult ChangePassword(string email,string password)
        {
            string passwordMd5 = userDao.md5(password);
            userDao.changePassword(email, passwordMd5);

            return Json(new { status = "OK", data = true, msg = "thanhcong", JsonRequestBehavior.AllowGet });

        }
    }
}