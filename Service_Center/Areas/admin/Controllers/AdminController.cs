using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Service_Center.Models;
using Service_Center.Areas.Customer.Models;
using Service_Center.Areas.admin.Models;

namespace Service_Center.Areas.admin.Controllers
{
    public class AdminController : Controller
    {
        DataUtility d = new DataUtility();
        // GET: admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        #region admin login
        [HttpPost]
        public ActionResult AdminLogin(admin_model ad)
        {
            LoginView responce = new LoginView();
            try
            {
                string query = "Exec spLogin '"+ad.username+"','"+ad.password+ "','AdminLogin'";
                DataSet ds = d.BindDataset(query);
                if(ds.Tables[0].Rows.Count>0)
                {
                    responce.Description = ds.Tables[0].Rows[0]["msg"].ToString();
                    if (responce.Description == "Failed")
                    {
                        responce.Description = "Username or password Invalid...!!";
                    }
                    else
                    {
                        Session["Name"] = ds.Tables[0].Rows[0]["name"].ToString();
                        Session["Username"] = ds.Tables[0].Rows[0]["username"].ToString();
                        Session["LoginAs"] = ds.Tables[0].Rows[0]["LogAs"].ToString();
                        responce.returnurl = "/Home/Admin_Index";
                    }
                }
            }
            catch(Exception e)
            {
                responce.Description = e.Message;
            }
            return Json(responce);
        }
        #endregion
        public ActionResult AdminLogout()
        {
            Session.Abandon();
            Response.Redirect("/admin/Admin/AdminLogin");
            return View();
        }
        #region get Appointment List
        public ActionResult GetAppointment_List(string action)
        {
            AppointmentList responce = new AppointmentList();
            try
            {
                string query = "Exec spAppointment '','','','','','','','','','','','"+action+"'";
                DataSet ds = d.BindDataset(query);
               List<Appointment_details> lst = new List<Appointment_details>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        
                        Appointment_details v = new Appointment_details();
                        v.Id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                        v.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                        v.Contact = ds.Tables[0].Rows[i]["Contact"].ToString();
                        v.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                        v.PinCode = int.Parse(ds.Tables[0].Rows[i]["Pin_Code"].ToString());
                        v.Brand = ds.Tables[0].Rows[i]["Brand"].ToString();
                        v.Product_Name = ds.Tables[0].Rows[i]["Product_name"].ToString();
                        v.D_Of_P = ds.Tables[0].Rows[i]["D_OF_P"].ToString();
                        v.Serial_No = ds.Tables[0].Rows[i]["Serial_NO"].ToString();
                        v.Price = int.Parse(ds.Tables[0].Rows[i]["price"].ToString());
                        v.Problem = ds.Tables[0].Rows[i]["problem"].ToString();
                        v.Warranty_Status = ds.Tables[0].Rows[i]["Warranty_status"].ToString();
                        v.status = bool.Parse(ds.Tables[0].Rows[i]["Appoint_status"].ToString());
                        v.Appnt_Date = ds.Tables[0].Rows[i]["Appointment_Date"].ToString();
                        v.Engineer_Name = ds.Tables[0].Rows[i]["Eng_Name"].ToString();
                        lst.Add(v);
                    }
                    responce.data = lst;
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
        #region get Appointment List By Id
        public ActionResult GetAppointment_ListById(Appointment_details a)
        {
            AppointmentList responce = new AppointmentList();
            try
            {
                string query = "Exec spAppointment '"+a.Id+ "','','','','','','','','','','','AppointmentById'";
                DataSet ds = d.BindDataset(query);
                List<Appointment_details> lst = new List<Appointment_details>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                        Appointment_details v = new Appointment_details();
                        v.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                        v.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                        v.Contact = ds.Tables[0].Rows[0]["Contact"].ToString();
                        v.EmailID = ds.Tables[0].Rows[0]["Email"].ToString();
                        v.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                        v.PinCode = int.Parse(ds.Tables[0].Rows[0]["Pin_Code"].ToString());
                        v.Brand = ds.Tables[0].Rows[0]["Brand"].ToString();
                        v.Product_Id = int.Parse(ds.Tables[0].Rows[0]["Applinces_Id"].ToString());
                        v.Product_Name = ds.Tables[0].Rows[0]["Product_name"].ToString();
                        v.D_Of_P = ds.Tables[0].Rows[0]["D_OF_P"].ToString();
                        v.Serial_No = ds.Tables[0].Rows[0]["Serial_NO"].ToString();
                        v.Price = int.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                        v.Problem = ds.Tables[0].Rows[0]["problem"].ToString();
                        v.Warranty_Status = ds.Tables[0].Rows[0]["Warranty_status"].ToString();
                        v.status = bool.Parse(ds.Tables[0].Rows[0]["Appoint_status"].ToString());
                        v.Appnt_Date = ds.Tables[0].Rows[0]["Appointment_Date"].ToString();
                        lst.Add(v);
                    
                    responce.data = lst;
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
        public ActionResult Follow_up()
        {
            return View();
        }
        #region update Replace Parts
        public ActionResult Update_Replace_part(Replace_Part r)
        {
            AddReplaceP responce = new AddReplaceP();
            try
            {
                string query = "Exec spUpdateReplacePart '','"+r.Appintmnt_id+"','"+r.Applince_Id+"','"+r.Part_Name+"','"+r.P_SerialNo+"','"+r.Price+"','"+r.Replace_Date+"','Insert'";
                DataSet ds = d.BindDataset(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    responce.Description = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch(Exception e)
            {
                responce.Description = e.Message;
            }
            return Json(responce);
        }
        #endregion
        public ActionResult Engineers()
        {
            
            return View();
        }
        #region Assign Engineers
        [HttpPost]
        public ActionResult Assign_Engineer(Appointment_details a)
        {
            AppointmentList responce = new AppointmentList();
            try
            {
                string query = "Exec spAppointment '" + a.Id + "','','','','','','','','','','"+a.Engineer_id+"','AssignEngineer'";
                DataSet ds = d.BindDataset(query);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    responce.Description = ds.Tables[0].Rows[0][0].ToString();
                    if(responce.Description == "OK")
                    {
                        responce.Description = "Engineer Assigned Successfully";
                    }
                }
            }
            catch(Exception e)
            {
                responce.Description = e.Message;
            }
            return Json(responce);
        }
        #endregion
    }
}