using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service_Center.Models;

namespace Service_Center.Models
{
    public class LoginView
    {
        public string Description { get; set; }
        public List<admin_model> date { get; set; }
        public string returnurl { get; set; }
    }
    public class User_Details
    {
        public string Description { get; set; }
        public List<userdata> Data { get; set; }
    }
   
}