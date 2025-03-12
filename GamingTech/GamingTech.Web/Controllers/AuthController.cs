
using GamingTech.BusinessLogic;
using GamingTech.BusinessLogic.Interfaces;
using GamingTech.Domain.User;
using GamingTech.Web.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace GamingTech.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly ISession _session;

        public AuthController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }
        // GET: Auth
        public ActionResult Index()
        {
            var sId = "abcd";
            bool isSessionValid = _session.ValidateSessionId(sId);

            if (isSessionValid)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            //UI Field for Auth
            return View();
        }
        [HttpPost]
        public ActionResult Login(AuthData Data)
        {
            //Auth Logic
            var uAuthData = new UserAuthData
            {
                Password = Data.Password,
                UserName = Data.UserName,
                RequestTime = DateTime.UtcNow
            };

            string sessionKey = _session.AuthUser(Data);

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Reset()
        {
            return View();
        }
    }
}