
using InstagramAspMVC.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace InstagramAspMVC.Controllers.Admin
{
    public class AdminPostController : Controller
    {
        AdminPostDao adminP = new AdminPostDao();
        // GET: AdminPost
        public ActionResult Index(string mess)
        {
            ViewBag.Msg = mess;
            var list = adminP.getAll();
            return View(list);
        }

        public ActionResult ChangeStatus(int id)
        {
            adminP.changeStatus(id);
            return RedirectToAction("Index", new { mess = "Thành công" });
        }

    }
}