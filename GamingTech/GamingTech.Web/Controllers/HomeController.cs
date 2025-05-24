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
        public ActionResult Index()
        {
            SessionStatus();

            //ViewBag.Username = "Guest";

            var products = new List<Accessory>
            {
                new Accessory { ImageURL = Url.Content("~/Content/img/mouse.png"),Name = "Mouse Logitech", Price = 1200},
                new Accessory { ImageURL = Url.Content("~/Content/img/keyboard.png"),Name = "Tastatură MK1", Price = 1500},
                new Accessory { ImageURL = Url.Content("~/Content/img/product03.png"),Name = "Laptop Asus", Price = 15999},
                new Accessory { ImageURL = Url.Content("~/Content/img/hyperx2.png"),Name = "Căști HyperX", Price = 1000},
                new Accessory { ImageURL = Url.Content("~/Content/img/product05.png"),Name = "Product 5", Price = 9600},
                new Accessory { ImageURL = Url.Content("~/Content/img/product06.png"),Name = "Product 6", Price = 2300},
                new Accessory { ImageURL = Url.Content("~/Content/img/product07.png"),Name = "Product 7", Price = 1900},
                new Accessory { ImageURL = Url.Content("~/Content/img/product08.png"),Name = "Product 8", Price = 3900},
            };

            return View(products);
        }

        public ActionResult Products()
        {
            return View();
        }
    }
}