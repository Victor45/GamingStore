using GamingTech.BusinessLogic.DBModel.Seed;
using GamingTech.Domain.Product;
using GamingTech.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GamingTech.BusinessLogic.Core
{
     public class ProductApi
     {
          internal PostResult CreateProductAction(PDbTable product)
          {
               using (var db = new UserContext())
               {
                    db.Products.Add(product);
                    db.SaveChanges();
               }

               return new PostResult { Status = true };
          }

          internal List<PDbTable> GetAccessoriesAction()
          {
               var Accessories = new List<PDbTable>();
               using (var db = new UserContext())
               {
                    foreach (var item in db.Products)
                    {
                         Accessories.Add(item);
                    }
               }
               return Accessories;
          }

          internal PDbTable GetProductByIdAction(int id)
          {
               using (var db = new UserContext())
               {
                    foreach(var item in db.Products)
                    {
                         if(item.Id == id)
                         {
                              var accessory = new PDbTable
                              {
                                   Id = item.Id,
                                   Name = item.Name,
                                   Description = item.Description,
                                   Price = item.Price,
                                   ImageURL = item.ImageURL,
                              };
                              return accessory;
                         }
                    }
               }
               return null;
          }
     }
}
