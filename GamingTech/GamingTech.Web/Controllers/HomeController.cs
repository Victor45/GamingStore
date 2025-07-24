using GamingTech.BusinessLogic.Interfaces;
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
          public HomeController()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _product = bl.GetProductBL();
          }
          public ActionResult Index()
          {
               SessionStatus();
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
                         ImageURL = db_product.ImageURL
                    };
                    products.Add(product);
               }

               return View(products);
          }

          public ActionResult Products()
          {
               return View();
          }
     }
}