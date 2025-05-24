using GamingTech.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GamingTech.BusinessLogic.Interfaces
{
    public interface ISession
    {
        bool ValidateSessionId(string sessionId);
        PostResult UserRegister(RegisterData data);
        PostResult UserLogin(UserLoginData data);
        HttpCookie GenCookie(string credential);
        UProfileData GetUserByCookie(string value);
    }
}
