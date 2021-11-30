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
        DBContextIG myDb = new DBContextIG();
        UserDao userDao = new UserDao();
        FollowDao followDao = new FollowDao();
        PostDao postDao = new PostDao();
        LikeDao likeDao = new LikeDao();
        SaveDao saveDao = new SaveDao();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchUser(FormCollection form)
        {
            var key = form["key"];
            ViewBag.Key = key;
            ViewBag.Search = userDao.search(key);
            return View();
        }

        public ActionResult Profile(string email,int id) {
            var obj = userDao.getInformationByEmail(email);
            ViewBag.numberPost = postDao.getNumberPost(id);
            ViewBag.numberFollower = followDao.getNumberFollower(id);
            ViewBag.numberFollowing = followDao.getNumberFollowing(id);
            ViewBag.ListPost = postDao.getPostUser(id);
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

        [HttpPost]
        public JsonResult LikePost(int idPost)
        {
            var user = (User)Session["User"];
            Like like = new Like();
            like.id_post = idPost;
            like.id_user = user.id_user;
            var obj = likeDao.checkExist(like);
            if(obj != null)
            {
                likeDao.unLike(like);
                return Json(new { status = "OK", data = true, msg = "unlike", JsonRequestBehavior.AllowGet });
            }
            else
            {
                likeDao.like(like);
                return Json(new { status = "OK", data = true, msg = "like", JsonRequestBehavior.AllowGet });
            }        
        }


        [HttpPost]
        public JsonResult FollowUser(int idUserBeFollow)
        {
            var user = (User)Session["User"];
            Follow userFollow = new Follow();
            userFollow.id_userBeFollow = idUserBeFollow;
            userFollow.id_userFollow = user.id_user;
            var obj = followDao.checkExist(userFollow);
            if (obj != null)
            {
                followDao.unFollowUser(userFollow);
                return Json(new { status = "OK", data = true, msg = "unFollow", JsonRequestBehavior.AllowGet });
            }
            else
            {
                followDao.followUser(userFollow);
                return Json(new { status = "OK", data = true, msg = "follow", JsonRequestBehavior.AllowGet });
            }
        }

        [HttpPost]
        public JsonResult SavePost(int idPost)
        {
            var user = (User)Session["User"];
            SavePost userSave = new SavePost();
            userSave.id_post = idPost;
            userSave.id_user = user.id_user;
            var obj = saveDao.checkExist(userSave);
            if (obj != null)
            {
                saveDao.unSave(userSave);
                return Json(new { status = "OK", data = true, msg = "unSave", JsonRequestBehavior.AllowGet });
            }
            else
            {
                saveDao.add(userSave);
                return Json(new { status = "OK", data = true, msg = "save", JsonRequestBehavior.AllowGet });
            }
        }

        public ActionResult GetListSave(int id)
        {
            var listSave = saveDao.GetSavePosts(id);
            return View(listSave);
        }

        public ActionResult ListFollower(int id)
        {
            var listFollower = followDao.getListFollower(id);
            return View(listFollower)
;       }

        public ActionResult ListFollowing(int id)
        {
            var listFollowing = followDao.getListFollowing(id);
            return View(listFollowing);
        }
        public ActionResult CreatePost(string msg)
        {
            ViewBag.Msg = msg;
            return View();
        }
        [HttpPost]
        public ActionResult CreatePost(FormCollection form, HttpPostedFileBase file)
        {
            var user = (User)Session["User"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(file.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Content/Assests/images/" + postedFileName);
            file.SaveAs(path);
            var content = form["content"];
            Post post = new Post();
            post.content = content;
            post.createdAt = DateTime.Now;
            post.status = 1;
            post.id_user = user.id_user;
            postDao.addPost(post);
            int idpost = int.Parse(myDb.Posts.ToList().Last().id_post.ToString());
            Images images = new Images();
            images.id_Post = idpost;
            images.image = postedFileName;
            postDao.addImg(images);
            return RedirectToAction("CreatePost", new { msg = "1" });
        }

        public ActionResult DetailPost(int id)
        {
            ViewBag.Post = postDao.getInforPost(id);
            return View();
        }
        [HttpPost]
        public ActionResult CommentDetail(FormCollection form)
        {
            var user = (User)Session["User"];
            var text = form["content"];
            var post = Int32.Parse(form["post"]);
            Comment comment = new Comment();
            comment.text = text;
            comment.id_user = user.id_user;
            comment.id_post = post;
            comment.createdAt = DateTime.Now;
            comment.parent = 0;
            comment.status = 1;
            postDao.addComment(comment);
            string action = "DetailPost/" + post;
            return RedirectToAction(action);
        }
        [HttpPost]
        public ActionResult CommentSave(FormCollection form)
        {
            var user = (User)Session["User"];
            var text = form["content"];
            var post = Int32.Parse(form["post"]);
            Comment comment = new Comment();
            comment.text = text;
            comment.id_user = user.id_user;
            comment.id_post = post;
            comment.createdAt = DateTime.Now;
            comment.parent = 0;
            comment.status = 1;
            postDao.addComment(comment);
            string action = "GetListSave/" + user.id_user; 
            return RedirectToAction(action);
        }
    }
}