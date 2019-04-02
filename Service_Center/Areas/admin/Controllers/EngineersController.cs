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
    public class EngineersController : Controller
    {
        DataUtility d = new DataUtility();
        // GET: admin/Engineers
        public ActionResult Index()
        {
            return View();
        }
        #region Enginners List
        [HttpPost]
        public ActionResult enginners_list(string action)
        {
            EngineersD responce = new EngineersD();
            try
            {
                string query = "EXEC spEngineers '','','','','','','"+action+"'";
                DataSet ds = d.BindDataset(query);
                List<EngineerDetails> lste = new List<EngineerDetails>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        EngineerDetails v = new EngineerDetails();
                        v.Id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                        v.e_name = ds.Tables[0].Rows[i]["Engineer Name"].ToString();
                        v.contact = ds.Tables[0].Rows[i]["Phone Number"].ToString();
                        v.gender_id = int.Parse(ds.Tables[0].Rows[i]["GenderId"].ToString());
                        v.gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                        v.Exp_id = int.Parse(ds.Tables[0].Rows[i]["ExpId"].ToString());
                        v.E_Experience = ds.Tables[0].Rows[i]["Experience"].ToString();
                        v.D_OF_J = ds.Tables[0].Rows[i]["D_OF_J"].ToString();
                        lste.Add(v);
                    }
                    responce.data = lste;
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
        #region Enginners List by ID
        [HttpPost]
        public ActionResult enginners_listByID(EngineerDetails a)
        {
            EngineersD responce = new EngineersD();
            try
            {
                string query = "EXEC spEngineers '"+a.Id+ "','','','','','','SelectById'";
                DataSet ds = d.BindDataset(query);
                List<EngineerDetails> lste = new List<EngineerDetails>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                  
                        EngineerDetails v = new EngineerDetails();
                        v.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                        v.e_name = ds.Tables[0].Rows[0]["Engineer Name"].ToString();
                        v.contact = ds.Tables[0].Rows[0]["Phone Number"].ToString();
                        v.gender_id = int.Parse(ds.Tables[0].Rows[0]["GenderId"].ToString());
                        v.gender = ds.Tables[0].Rows[0]["Gender"].ToString();
                        v.Exp_id = int.Parse(ds.Tables[0].Rows[0]["ExpId"].ToString());
                        v.E_Experience = ds.Tables[0].Rows[0]["Experience"].ToString();
                        v.D_OF_J = ds.Tables[0].Rows[0]["D_OF_J"].ToString();
                        lste.Add(v);
                  
                    responce.data = lste;
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
        #region add Enginners
        [HttpPost]
        public ActionResult Add_enginners(EngineerDetails en)
        {
            EngineersD responce = new EngineersD();
            try
            {
                string query = "Exec spEngineers '','"+en.e_name+ "','" + en.contact + "','" + en.gender_id + "','" + en.Exp_id + "','" + en.D_OF_J + "','Insert'";
                DataSet ds = d.BindDataset(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    responce.Description = ds.Tables[0].Rows[0][0].ToString();
                    if (responce.Description == "OK")
                    {
                        responce.Description = "Engineer Added Successfully";
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
        #region Update Enginners
        [HttpPost]
        public ActionResult Update_enginners(EngineerDetails en)
        {
            EngineersD responce = new EngineersD();
            try
            {
                string query = "Exec spEngineers '"+en.Id+"','" + en.e_name + "','" + en.contact + "','" + en.gender_id + "','" + en.Exp_id + "','" + en.D_OF_J + "','Update'";
                DataSet ds = d.BindDataset(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    responce.Description = ds.Tables[0].Rows[0][0].ToString();
                    if (responce.Description == "OK")
                    {
                        responce.Description = "Engineer Updated Successfully";
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
        #region Delete Enginners
        [HttpPost]
        public ActionResult Delete_enginners(EngineerDetails a)
        {
            EngineersD responce = new EngineersD();
           try
            {
                string query = "EXEC spEngineers '" + a.Id + "','','','','','','Delete'";
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
        #region Gender List
        [HttpPost]
        public ActionResult Gender_list(string action)
        {
            GenderList responce = new GenderList();
            try
            {
                string query = "EXEC spDropdown '"+action+"'";
                DataSet ds = d.BindDataset(query);
                List<Gender> lst = new List<Gender>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Gender v = new Gender();
                        v.ID = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                        v.gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                        lst.Add(v);
                    }
                    responce.data = lst;
                    responce.Description = "Data Found";
                }
            }
            catch(Exception e)
            {
                responce.Description = e.Message;
            }
            return Json(responce);
        }
        #endregion
        #region Experience List
        [HttpPost]
        public ActionResult Experience_list(string action)
        {
            ExperienceList responce = new ExperienceList();
            try
            {
                string query = "EXEC spDropdown '" + action + "'";
                DataSet ds = d.BindDataset(query);
                List<Experience> lst = new List<Experience>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Experience v = new Experience();
                        v.ID = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                        v.experience = ds.Tables[0].Rows[i]["Experience"].ToString();
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
    }
}