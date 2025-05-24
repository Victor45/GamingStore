using GamingTech.BusinessLogic.DBModel.Seed;
using GamingTech.Domain.User;
using GamingTech.Helpers.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GamingTech.BusinessLogic.Core
{
    public class UserApi
    {
        protected bool ValidateSessionIdAction(string id)
        {
            return true;
        }

        protected PostResult UserLoginAction(UserLoginData data)
        {
            UDbTable result;
            var pass = PassHelper.HashGen(data.Password);
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(user => (user.Email == data.Credential || user.UserName == data.Credential) && user.Password == pass);
            }

            if (result == null)
            {
                return new PostResult { Status = false, Message = "The username/email or password is incorrect"};
            }

            using (var db = new UserContext())
            {
                result.LastIP = data.LastIP;
                result.LastLogin = data.LoginDateTime;
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
            }
            return new PostResult { Status = true };
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
                db.SaveChanges();

                return new PostResult
                {
                    Status = true
                };
            }
        }

        protected HttpCookie Cookie(string credential)
        {
            var apiCookie = new HttpCookie("gta_token")
            {
                Value = CookieGenerator.Create(credential)
            };

            UDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(user => user.Email == credential || user.UserName == credential);
            }

            credential = result.Email;

            using (var db = new UserContext())
            {
                SessionDbTable current;
                current = (from e in db.Sessions where e.UserEmail == credential select e).FirstOrDefault();

                if (current != null)
                {
                    current.CookieString = apiCookie.Value;
                    current.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var bd = new UserContext())
                    {
                        bd.Entry(current).State = EntityState.Modified;
                        bd.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new SessionDbTable
                    {
                        UserEmail = credential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }
            return apiCookie;
        }

        protected UProfileData GetUserByCookieAction(string cookie)
        {
            SessionDbTable session;
            UDbTable currentUser;

            using (var db = new UserContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;

            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.UserEmail))
                {
                    currentUser = db.Users.FirstOrDefault(u => u.Email == session.UserEmail);
                }
                else
                {
                    return null;
                }
            }

            var userprofile = new UProfileData
            {
                Id = currentUser.Id,
                Username = currentUser.UserName,
                Email = currentUser.Email,
                FirstLogin = currentUser.LastLogin,
            };

            return userprofile;
        }
    }
}
