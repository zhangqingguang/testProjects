using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITGB.UIS.EFExtend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var profiler = MiniProfiler.Current;
            using (profiler.Step("查询tUsers的数据"))
            {
                using (Models.OReillyEntities db = new Models.OReillyEntities())
                {
                    var count = db.tUsers.Count();
                    count = db.tUsers.Count();
                }
            }
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