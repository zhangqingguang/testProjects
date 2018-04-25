using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VueDemo.Models;

namespace VueDemo.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult Menu()
        {
            List<MenuModel> menus = new List<MenuModel>();
            menus.Add(new MenuModel()
            {
                name = "首页",
                href = "/apps/home",
                icon = "icon-home",
                hasChild = false
            });
            menus.Add(new MenuModel()
            {
                name = "销售单",
                icon = "icon-cogs",
                active = true,
                hasChild = true,
                children = new List<MenuModel>()
                {
                    new MenuModel()
                    {
                        name = "所有销售单",
                        active = true,
                        href = "/apps/sales/index",
                        hasChild = false
                    }
                }
            });
            return Json(menus, JsonRequestBehavior.AllowGet);
        }
    }
}