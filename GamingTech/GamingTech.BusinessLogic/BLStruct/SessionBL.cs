using GamingTech.BusinessLogic.Core;
using GamingTech.BusinessLogic.Interfaces;
using GamingTech.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GamingTech.BusinessLogic.BLStruct
{
    public class SessionBL : UserApi, ISession
    {
        public bool ValidateSessionId(string sessionId)
        {
            return ValidateSessionIdAction(sessionId);
        }

        public PostResult UserRegister(RegisterData data)
        {
            return UserRegisterAction(data);
        }

        public PostResult UserLogin(UserLoginData data)
        {
            return UserLoginAction(data);
        }

        public HttpCookie GenCookie(string credential)
        {
            return Cookie(credential);
        }

        public UProfileData GetUserByCookie(string value)
        {
            return GetUserByCookieAction(value);
        }

        public void UserLogout(string cookie)
        {
            UserLogoutAction(cookie);
        }
    }
}
