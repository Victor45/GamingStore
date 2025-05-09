using GamingTech.BusinessLogic.DBModel.Seed;
using GamingTech.Domain.User;
using GamingTech.Helpers.Session;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        protected PostResult UserRegisterAction(RegisterData data)
        {
            UDbTable result;

            using (var db = new UserContext())
            {
                var existingUser = db.Users.Any(user => user.UserName == data.Username);

                if (existingUser)
                {
                    return new PostResult
                    {
                        Status = false,
                        Message = "This user already exists"
                    };
                }
                var criptedpass = PassHelper.HashGen(data.Password);
                result = new UDbTable
                {
                    UserName = data.Username,
                    Email = data.Email,
                    Password = criptedpass,
                    LastLogin = data.LoginDateTime,
                    LastIP = data.LoginIP
                };

                db.Users.Add(result);

                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine($"Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                        }
                    }
                    throw;
                }

                return new PostResult
                {
                    Status = true,
                    Message = "Successfully registered"
                };
            }
        }
    }
}
