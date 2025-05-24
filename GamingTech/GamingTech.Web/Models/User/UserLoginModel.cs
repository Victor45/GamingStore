using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamingTech.Web.Models.User
{
    public class UserLoginModel
    {
        public string Credential { get; set; }
        public string Password { get; set; }
        public string LastIP { get; set; }
        public DateTime LoginDateTime { get; set; }
    }
}