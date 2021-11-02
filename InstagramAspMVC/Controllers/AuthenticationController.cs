﻿using InstagramAspMVC.Daos;
using InstagramAspMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstagramAspMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        UserDao userD = new UserDao();
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            User obj = new User();
            obj.fullname = user.fullname;
            obj.username = user.username;
            obj.email = user.email;
            obj.password = userD.md5(user.password);
            obj.phonenumber = user.phonenumber;
            obj.address = user.address;

            User objCheck = userD.checkExist(user.email, user.username, user.phonenumber);
            if (objCheck != null)
            {
                ViewBag.message = "Email,username or phonenumber is existed";
                return View();
            }
            else
            {
                userD.add(obj);
                return RedirectToAction("Login");
            }        
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            string passwordMd5 = userD.md5(user.password);
            User checkLogin = userD.checkLogin(user.email, passwordMd5);

            if (checkLogin == null)
            {
                ViewBag.message = "Email or password incorret!!";
                return View();
            }
            else
            {
                User information = userD.getInformationByEmail(user.email);
                Session.Add("User", information);
                return RedirectToAction("Index", "Home");
            }
           
        }
        public ActionResult Logout()
        {
            Session.Remove("User");
            return Redirect("/");
        }
    }
}