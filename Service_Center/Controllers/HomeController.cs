using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Mvc;
using Service_Center.Models;

namespace Service_Center.Controllers
{
    public class HomeController : Controller
    {
        DataUtility d = new DataUtility();
        // GET: Home
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admin_Index()
        {
            if (Session["Name"] == null)
            {
                Response.Redirect("/admin/Admin/AdminLogin");
            }
            return View();
        }

        public ActionResult User_Index()
        {
            return View();
        }
    }
}