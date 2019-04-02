using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service_Center.Areas.Customer.Models
{
    public class Applinces_Data
    {
        public int id { get; set; }
        public string Product_Name{ get; set; }
    }
    public class Appointment_data
    {
        public int id { get; set; }
        public int Customer_Id { get; set; }
        public string Brand { get; set; }
        public int Applinces_Id { get; set; }
        public string D_OF_P  { get; set; }
        public string Serial_NO { get; set; }
        public int price { get; set; }
        public string warranty_statuse { get; set; }
        public string problem { get; set; }
        public string Appnt_Date { get; set; }
        public int Engineer_id { get; set; }
    }
}