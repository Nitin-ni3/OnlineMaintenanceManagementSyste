using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service_Center.Models;
using Service_Center.Areas.Customer.Models;
using System.Data;

namespace Service_Center.Areas.Customer.Controllers
{
    public class UserRegistrationController : Controller
    {
        DataUtility d = new DataUtility();
        // GET: Customer/UserRegistration
        public ActionResult Index()
        {
            return View();
        }
        #region User Registration
        [HttpPost]
        public ActionResult Sign_Up(userdata ud)
        {
            UserRegsiter responce = new UserRegsiter();

            try
            {
                string query = "Exec spCustomer '','" + ud.Email + "','"+ud.Password+"','"+ud.Name+"','"+ud.Contact+ "','" + ud.Address + "','" + ud.Pin_Code+ "','Insert'";
                DataSet ds = d.BindDataset(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    responce.Description = ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    responce.Description = "Something went wrong";
                }
                  
            }
            catch (Exception e)
            {
                responce.Description = e.Message;
            }
            return Json(responce);
        }
        #endregion
    }
}