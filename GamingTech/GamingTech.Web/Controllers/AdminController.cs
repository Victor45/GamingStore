using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamingTech.Web.Controllers
{
     public class AdminController : BaseController
     {
          // GET: Admin
          public ActionResult Panel()
          {
               SessionStatus();
               return View();
          }
          public ActionResult TestView()
          {
               return View();
          }
     }
}