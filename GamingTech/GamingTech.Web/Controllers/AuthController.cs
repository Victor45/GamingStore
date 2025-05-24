
using GamingTech.BusinessLogic;
using GamingTech.BusinessLogic.Interfaces;
using GamingTech.Domain.User;
using GamingTech.Web.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLoginModel login)
        {
            if (ModelState.IsValid)
            {
                var Data = new UserLoginData
                {
                    
                    Credential = login.Credential,
                    Password = login.Password,
                    LoginDateTime = DateTime.UtcNow,
                    LastIP = "1234567890",
                };

                var userLogin = _session.UserLogin(Data);

                if(userLogin.Status)
                {
                    HttpCookie cookie = _session.GenCookie(Data.Credential);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }

            }

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                RegisterData user = new RegisterData
                {
                    Email = register.Email,
                    Username = register.Username,
                    Password = register.Password,
                    RepPassword = register.RepPassword,
                    LoginIP = "123",
                    LoginDateTime = DateTime.Now
                };

                var userRegister = _session.UserRegister(user);

                if(userRegister.Status)
                {
                    return RedirectToAction("Login", "Auth");
                }
            }
            return View();
        }
        public ActionResult Reset()
        {
            return View();
        }
    }
}