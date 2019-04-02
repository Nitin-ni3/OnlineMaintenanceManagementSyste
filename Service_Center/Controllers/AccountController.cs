using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Service_Center.Models;
using Service_Center.Areas.Customer.Models;

namespace Service_Center.Controllers
{
    public class AccountController : Controller
    {
        DataUtility d = new DataUtility();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }
        #region UserLogin Post
        [HttpPost]
        public ActionResult Login(userdata ud)
        {
            UserLogin responce = new UserLogin();
            try
            {
                string query = "Exec spLogin '" + ud.Email + "','" + ud.Password + "','UserLogin'";
                DataSet ds = d.BindDataset(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    responce.Description = ds.Tables[0].Rows[0]["msg"].ToString();
                    if (responce.Description == "Failed")
                    {
                        responce.Description = "Username or Password incorrect!";
                    }
                    else
                    {
                        Session["UName"] = ds.Tables[0].Rows[0]["Name"].ToString();
                        string val = Session["UName"].ToString();
                        Session["Username"] = ds.Tables[0].Rows[0]["Email"].ToString();
                        Session["LoginAs"] = "User";
                        responce.returnurl = "/Customer/UserAction/Appointment";
                    }
                }
            }
            catch (Exception e)
            {
                responce.Description = e.Message;
            }
            return Json(responce);
        }
        #endregion
        //public ActionResult user_login()
        //{
        //    return View();
        //}
        //#region user login
        //[HttpPost]
        //public ActionResult user_login(userdata ud)
        //{
        //    UserLogin responce = new UserLogin();
        //    try
        //    {
        //        string query = "Exec spLogin '"+ud.Email+"','"+ud.Password+ "','UserLogin'";
        //        DataSet ds = d.BindDataset(query);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            responce.Description = ds.Tables[0].Rows[0]["msg"].ToString();
        //            if (responce.Description == "Failed")
        //            {
        //                responce.Description = "Username or Password incorrect!";
        //            }
        //            else
        //            {
        //                Session["Name"] = ds.Tables[0].Rows[0]["Name"].ToString();
        //                Session["Username"] = ds.Tables[0].Rows[0]["Email"].ToString();
        //                responce.returnurl = "/Home/Admin_Index";
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return View();
        //}
        //#endregion
        public void Logout()
        {
            Session.Abandon();
            Response.Redirect("/Home/Index");
        }

    }
}