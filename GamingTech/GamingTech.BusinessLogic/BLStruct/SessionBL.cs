using GamingTech.BusinessLogic.Core;
using GamingTech.BusinessLogic.Interfaces;
using GamingTech.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTech.BusinessLogic.BLStruct
{
    public class SessionBL : UserApi, ISession
    {
        public bool ValidateSessionId(string sessionId)
        {
            return ValidateSessionIdAction(sessionId);
        }

        public string AuthUser(UserAuthData data)
        {
            return AuthUserAction(data);
        }
    }
}
