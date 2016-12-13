using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospOnline.DTO
{
    public class LoginadmDTO
    {
        public Int64 personalID { get; set; }
        public Int64 personaID { get; set; }
        public string rut { get; set; }
        public string dv { get; set; }
        public string nombres { get; set; }
        public string ap_paterno { get;set;}
        public string ap_materno {get;set;}
        public string clave { get; set; }
    }
}