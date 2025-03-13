using GamingTech.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTech.BusinessLogic.Interfaces
{
    public interface ISession
    {
        bool ValidateSessionId(string sessionId);
        string AuthUser(UserAuthData data);
    }
}
