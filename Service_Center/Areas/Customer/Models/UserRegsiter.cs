using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service_Center.Models;

namespace Service_Center.Areas.Customer.Models
{
    public class UserRegsiter
    {
        public string Description { get; set; }
        public List<userdata> data { get; set; }
    }
    public class UserLogin
    {
        public string Description { get; set; }
        public List<userdata> date { get; set; }
        public string returnurl { get; set; }
    }
    public class AllApplinces
    {
        public string Description { get; set; }
        public List<Applinces_Data> Data { get; set; }
    }
    public class Appointment_app
    {
        public string Description { get; set; }
        public List<Applinces_Data> Data { get; set; }
    }
}