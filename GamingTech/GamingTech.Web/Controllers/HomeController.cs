using GamingTech.BusinessLogic.Interfaces;
using GamingTech.Domain.Enums;
using GamingTech.Domain.User;
using GamingTech.Web.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamingTech.Web.Controllers
{
     public class HomeController : BaseController
     {
          // GET: Home
          private readonly IProduct _product;
          private readonly ISession _session;
          public HomeController()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _product = bl.GetProductBL();
               _session = bl.GetSessionBL();
          }
          public ActionResult Index()
          {
               SessionStatus();
            var apiCookie = Request.Cookies["gta_token"];
            UProfileData uProfile = null;
            List<int> favorites = new List<int>();
            if (apiCookie != null)
            {
                uProfile = _session.GetUserByCookie(apiCookie.Value);
                favorites = _product.GetFavorites(uProfile.Id);
            }
            var db_products = _product.GetAccessories();
            var products = new List<Accessory>();

               foreach (var db_product in db_products)
               {
                    var product = new Accessory
                    {
                         Id = db_product.Id,
                         Name = db_product.Name,
                         Price = db_product.Price,
                         Description = db_product.Description,
                         ImageURL = db_product.ImageURL,
                         IsFavorite = favorites.Contains(db_product.Id),
                    };
                    products.Add(product);
               }

               return View(products);
          }

          public ActionResult Products()
          {
               return View();
          }

        public ActionResult ProductsByCategory(int category)
        {
             var products = _product.GetProductsByCategory((PCategory)category);
            return RedirectToAction("Index", products);
        }
     }
}