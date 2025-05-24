using GamingTech.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamingTech.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly ISession _session;

        public BaseController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        public void SessionStatus()
        {
            var apiCookie = Request.Cookies["gta_token"];
            if (apiCookie != null)
            {
                var uProfile = _session.GetUserByCookie(apiCookie.Value);
                if (uProfile != null)
                {
                    ViewBag.Username = uProfile.Username;
                    System.Web.HttpContext.Current.Session.Add("__SessionObject", uProfile);
                    System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
                }
                else
                {
                    ViewBag.Username = "Guest";
                    System.Web.HttpContext.Current.Session.Clear();
                    if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("gta_token"))
                    {
                        var cookie = ControllerContext.HttpContext.Request.Cookies["gta_token"];
                        if (cookie != null)
                        {
                            cookie.Expires = DateTime.Now.AddDays(-1);
                            ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                        }
                    }
                    System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
                }
            }
            else
            {
                ViewBag.Username = "Guest";
                System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
            }
        }
    }
}