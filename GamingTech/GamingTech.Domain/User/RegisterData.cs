using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTech.Domain.User
{
    public class RegisterData
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RepPassword { get; set; }
        public string LoginIP { get; set; }
        public DateTime LoginDateTime { get; set; }
    }
}
