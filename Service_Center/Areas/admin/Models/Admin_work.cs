using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service_Center.Areas.admin.Models;

namespace Service_Center.Areas.admin.Models
{
    public class AppointmentList
    {
        public string Description { get; set; }
        public List<Appointment_details> data { get; set; }
    }
    public class AddReplaceP
    {
        public string Description { get; set; }
        public List<Replace_Part> data { get; set; }
    }
    public class GenderList
    {
        public string Description { get; set; }
        public List<Gender> data { get; set; }
    }
    public class ExperienceList
    {
        public string Description { get; set; }
        public List<Experience> data { get; set; }
    }
    public class EngineersD
    {
        public string Description { get; set; }
        public List<EngineerDetails> data { get; set; }
    }
}