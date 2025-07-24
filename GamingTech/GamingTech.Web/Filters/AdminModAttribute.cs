using GamingTech.BusinessLogic.Interfaces;
using GamingTech.Domain.Enums;
using GamingTech.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GamingTech.Web.Filters
{
     public class AdminModAttribute : ActionFilterAttribute
     {
          private readonly ISession _session;
          public AdminModAttribute()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();
          }

          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var cookie = HttpContext.Current.Request.Cookies["gta_token"];
               if (cookie != null)
               {
                    var profile = _session.GetUserByCookie(cookie.Value);
                    if (profile != null && profile.Level == URole.Admin)
                    {
                         HttpContext.Current.Session.Add("__SessionObject", profile);
                         return;
                    }
               }
               filterContext.Result = new RedirectToRouteResult(
                           new RouteValueDictionary(new { controller = "Error", action = "Error404" }));
          }
     }
}