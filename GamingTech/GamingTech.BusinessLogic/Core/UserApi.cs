using GamingTech.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTech.BusinessLogic.Core
{
    public class UserApi
    {
        protected bool ValidateSessionIdAction(string id)
        {
            return true;
        }

        protected string AuthUserAction(UserAuthData data)
        {
            //Step 1 - Validate data
            if (data != null)
            {
                //Step 2 - check if usernaame exits in ur DB
                //select from User where data.UserName -> FirstOrDefault()

                bool isUserNameValid = false;
                if (isUserNameValid)
                {

                }
            }
            //else var sessionKey = Generate
            return string.Empty;
        }

        protected string GenerateSessionKey(string UserName, string noise)
        {
            string sKey = UserName + noise;
            return sKey;
        }
    }
}
