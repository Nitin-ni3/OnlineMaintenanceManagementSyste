using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Service_Center.Models;
using Service_Center.Areas.Customer.Models;
namespace Service_Center.Areas.Customer.Controllers
{
    public class UserActionController : Controller
    {
        
        // GET: Customer/UserAction
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Appointment()
        {
            if (Session["UName"] == null)
            {
                Response.Redirect("/Home/Index");
            }
            return View();
        }
        #region select user data by Email
        public ActionResult User_Details(userdata ud)
        {
            DataUtility du = new DataUtility();
            User_Details responce = new User_Details();
            try
            {
                string query = "Exec spCustomer '','"+ud.Email+"','','','','','','SelectByEmail'";
                DataSet ds = du.BindDataset(query);
                List<userdata> lst = new List<userdata>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    userdata u = new userdata();
                    u.U_ID = int.Parse(ds.Tables[0].Rows[0]["U_id"].ToString());
                    u.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    u.Contact = ds.Tables[0].Rows[0]["Contact"].ToString();
                    u.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    u.Pin_Code = ds.Tables[0].Rows[0]["Pin_Code"].ToString();
                    u.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    lst.Add(u);
                    responce.Data = lst;
                }
            }
            catch (Exception e)
            {
                responce.Description = e.Message;
            }

            return Json(responce);
        }
        #endregion
        #region get Applinces
        public ActionResult GetApplinces(string action)
        {
            DataUtility d = new DataUtility();
            AllApplinces responce = new AllApplinces();
            try
            {
                string query = "Exec spProcut '','','"+ action + "'";
                DataSet ds = d.BindDataset(query);
                List<Applinces_Data> lst = new List<Applinces_Data>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Applinces_Data v = new Applinces_Data();
                        v.id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                        v.Product_Name = ds.Tables[0].Rows[i]["Product_name"].ToString();
                        lst.Add(v);
                    }

                    responce.Data = lst;
                    responce.Description = "Data Found";
                }
            }
            catch (Exception e)
            {
                responce.Description = e.Message;
            }
            return Json(responce);
        }
        #endregion
        #region user appointment applay 
        [HttpPost]
        public ActionResult Appointment_Applay(Appointment_data ad)
        {
            DataUtility d = new DataUtility();
            Appointment_app responce = new Appointment_app();
            try
            {
                string query = "Exec spAppointment '','"+ad.Customer_Id+ "','" + ad.Brand + "','" + ad.Applinces_Id + "','" + ad.D_OF_P + "','" + ad.Serial_NO + "','" + ad.price + "','" + ad.problem + "','" + ad.warranty_statuse + "','"+ad.Appnt_Date+"','','Insert'";
                DataSet ds = d.BindDataset(query);
                if(ds.Tables[0].Rows.Count>0)
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