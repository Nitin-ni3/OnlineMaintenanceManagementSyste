using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service_Center.Controllers
{
    public class ModuleController : Controller
    {
        // GET: Module
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About_Us()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
    }
}