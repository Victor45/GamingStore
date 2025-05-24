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
        public AccessoryController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _product = bl.GetProductBL();
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [AdminMod]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, Accessory accessory)
        {
            string fileName;
            if (file != null)
            {
                FileInfo fi = new FileInfo(file.FileName);
                if (file != null && file.ContentLength > 0)
                {
                    using (var md5 = MD5.Create())
                    {
                        fileName = BitConverter.ToString(md5.ComputeHash(file.InputStream)).Replace("-", "");
                        accessory.ImageURL = "~Content/ShopImages/" + fileName + ".jpg";
                        var filePath = Path.Combine(Server.MapPath("~Content/ShopImages/"), fileName + fi.Extension);
                        if (!System.IO.File.Exists(filePath))
                        {
                            file.SaveAs(filePath);
                        }
                    }
                }
            }

            SessionStatus();

            PDbTable data = new PDbTable
            {
                Name = accessory.Name,
                Description = accessory.Description,
                Price = accessory.Price,
                ImageUrl = accessory.ImageURL
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