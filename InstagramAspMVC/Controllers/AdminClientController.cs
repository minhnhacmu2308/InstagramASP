using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InstagramAspMVC.Dao;

namespace InstagramAspMVC.Controllers.Admin
{
    public class AdminClientController : Controller
    {
        AdminUserDao adminU = new AdminUserDao();
        // GET: AdminClient
        public ActionResult Index(string mess)
        {
            ViewBag.Msg = mess;
            var list = adminU.getAll();
            return View(list);
        }

        public ActionResult ChangeStatus(int id)
        {
            adminU.changeStatus(id);
            return RedirectToAction("Index", new { mess = "Thành công" });
        }
    }
}