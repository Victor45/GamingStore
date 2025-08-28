using GamingTech.BusinessLogic.Interfaces;
using GamingTech.Domain.Product;
using GamingTech.Web.Filters;
using GamingTech.Web.Models.Product;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace GamingTech.Web.Controllers
{
    public class AccessoryController : BaseController
    {
        private readonly IProduct _product;
        private readonly ISession _session;
        public AccessoryController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _product = bl.GetProductBL();
            _session = bl.GetSessionBL();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult AddToWishList(int productId)
        {
            var apiCookie = Request.Cookies["gta_token"];
            var uProfile = _session.GetUserByCookie(apiCookie.Value);
            var marked = _product.MarkAsFavorite(uProfile.Id, productId);
            if (marked) 
            {
                return Json(new { status = "added" });
            }
            else
            {
                return Json(new { status = "removed" });
            }
        }

        public ActionResult WishList()
        {
            var apiCookie = Request.Cookies["gta_token"];
            var uProfile = _session.GetUserByCookie(apiCookie.Value);
            var wishlistids = _product.GetFavorites(uProfile.Id);
            var wishlist = new List<Accessory>();
            foreach(var id in wishlistids)
            {
                var accessory = _product.GetProductById(id);
                var favaccessory = new Accessory()
                {
                    Id = accessory.Id,
                    Name = accessory.Name,
                    Description = accessory.Description,
                    ImageURL = accessory.ImageURL,
                    Price = accessory.Price,
                    IsFavorite = true
                };
                wishlist.Add(favaccessory);
            }
            return View(wishlist);
        }

        public ActionResult ProductDetails(int id)
        {
            SessionStatus();
            var db_accessory = _product.GetProductById(id);
            var accessory = new Accessory
            {
                Id = db_accessory.Id,
                Name = db_accessory.Name,
                Description = db_accessory.Description,
                Price = db_accessory.Price,
                ImageURL = db_accessory.ImageURL,
            };
            return View(accessory);
        }

        [AdminMod]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(HttpPostedFileBase ImageFile, Accessory accessory)
        {
            string fileName;
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                FileInfo fi = new FileInfo(ImageFile.FileName);
                using (var md5 = MD5.Create())
                {
                    fileName = BitConverter.ToString(md5.ComputeHash(ImageFile.InputStream)).Replace("-", "");
                    accessory.ImageURL = "Content/img/" + fileName + fi.Extension;
                    var FilePath = Path.Combine("D:\\GamingTech\\GamingStore\\GamingTech\\GamingTech.Web\\Content\\img\\", fileName + fi.Extension);
                    if (!System.IO.File.Exists(FilePath))
                    {
                        ImageFile.SaveAs(FilePath);
                    }
                }
            }

            SessionStatus();

            PDbTable data = new PDbTable
            {
                Name = accessory.Name,
                Description = accessory.Description,
                Price = accessory.Price,
                Stock = accessory.Stock,
                Category = accessory.Category,
                ImageURL = accessory.ImageURL
            };

            var productCreate = _product.CreateProduct(data);
            if (productCreate.Status)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Error");
                return View();
            }
        }
    }
}