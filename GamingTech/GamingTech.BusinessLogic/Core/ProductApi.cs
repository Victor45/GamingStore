using GamingTech.BusinessLogic.DBModel.Seed;
using GamingTech.Domain.Enums;
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
                foreach (var item in db.Products)
                {
                    if (item.Id == id)
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

        internal bool MarkAsFavoriteAction(int UserID, int ProductID)
        {
            var WishListProduct = new WLDbTable
            {
                UserID = UserID,
                ProductID = ProductID
            };
            using (var db = new UserContext())
            {
                var existing = db.WishList.FirstOrDefault(w => w.UserID == UserID && w.ProductID == ProductID);
                if (existing != null)
                {
                    db.WishList.Remove(existing);
                    db.SaveChanges();
                    return false;
                }
                else
                {
                    db.WishList.Add(WishListProduct);
                    db.SaveChanges();
                    return true;
                }
            }
        }

        internal List<int> GetFavoritesAction(int UserID)
        {
            var favorites = new List<int>();
            using (var db = new UserContext())
            {
                favorites = db.WishList.Where(p => p.UserID == UserID).Select(p => p.ProductID).ToList();
            }
            return favorites;
        }

        internal List<PDbTable> GetProductsByCategoryAction(PCategory category)
        {
            var products = new List<PDbTable>();
            using (var db = new UserContext())
            {
                foreach(var prod in db.Products)
                {
                    if(prod.Category == category)
                    {
                        products.Add(prod);
                    }
                }
            }
            return products;
        }
    }
}
