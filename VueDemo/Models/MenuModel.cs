using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VueDemo.Models
{
    public class MenuModel
    {
        public bool active { get; set; }
        public bool hasChild { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        [Remote(controller:"Home",action:"Index")]
        public string href { get; set; }
        public List<MenuModel> children { get; set; }
    }
}