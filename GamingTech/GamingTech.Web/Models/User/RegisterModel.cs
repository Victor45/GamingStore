using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamingTech.Web.Models.User
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RepPassword { get; set; }
        public string LoginIP { get; set; }
        public DateTime LoginDateTime { get; set; }
    }
}