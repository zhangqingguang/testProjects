using SqlCacheDependencyTest.Dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SqlCacheDependencyTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var userQuery = new UserManager().GetCacheUser();

            return View();
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