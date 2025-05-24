using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using GamingTech.Domain.User;
using GamingTech.BusinessLogic.Interfaces;
using GamingTech.Domain.Enums;

namespace GamingTech.Web.Filters
{
    public class UserModAttribute : ActionFilterAttribute
    {
        private readonly ISession _session;
        public UserModAttribute()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var adminSession = (UProfileData)HttpContext.Current?.Session["__SessionObject"];
            if (adminSession != null)
            {
                var cookie = HttpContext.Current.Request.Cookies["gta_token"];
                if (cookie != null)
                {
                    var profile = _session.GetUserByCookie(cookie.Value);
                    if (profile != null && (profile.Level == URole.User || profile.Level == URole.Moderator || profile.Level == URole.Admin))
                    {
                        HttpContext.Current.Session.Add("__SessionObject", profile);
                        return;
                    }
                }
            }
        }
    }
}