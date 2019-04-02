using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Service_Center.Areas.admin.Models
{

    public class Appointment_details
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public int PinCode { get; set; }
        public string Brand { get; set; }
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string D_Of_P { get; set; }
        public string Serial_No { get; set; }
        public int Price { get; set; }
        public string Problem { get; set; }
        public string Warranty_Status { get; set; }
        public bool status { get; set; }
        public string Appnt_Date { get; set; }
        public int Engineer_id { get; set; }
        public string Engineer_Name { get; set; }
    }

    public class Replace_Part
    {
       // public int Id { get; set; }
        public int Appintmnt_id { get; set; }
        public int Applince_Id { get; set; }
        public string Part_Name { get; set; }
        public string P_SerialNo { get; set; }
        public int Price { get; set; }
        public string Replace_Date { get; set; }
    }
    public class Gender
    {
        public int ID { get; set; }
        public string gender { get; set; }
    }
    public class Experience
    {
        public int ID { get; set; }
        public string experience { get; set; }
    }
    public class EngineerDetails
    {
        public int Id { get; set; }
        public string e_name { get; set; }
        public string contact { get; set; }
        public int gender_id { get; set; }
        public string gender { get; set; }
        public int Exp_id { get; set; }
        public string E_Experience { get; set; }
        public string D_OF_J { get; set; }
    }
}