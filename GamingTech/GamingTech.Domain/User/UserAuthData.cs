﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTech.Domain.User
{
    public class UserAuthData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RequestTime { get; set; }

    }
}
