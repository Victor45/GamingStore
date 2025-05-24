using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTech.Domain.User
{
    public class UserLoginData
    {
        public string Credential { get; set; }
        public string Password { get; set; }
        public string LastIP { get; set; }
        public DateTime LoginDateTime { get; set; }
    }
}
