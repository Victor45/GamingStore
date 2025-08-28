using GamingTech.BusinessLogic.Core;
using GamingTech.BusinessLogic.Interfaces;
using GamingTech.Domain.Enums;
using GamingTech.Domain.Product;
using GamingTech.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTech.BusinessLogic.BLStruct
{
    public class ProductBL : ProductApi, IProduct
    {
        public PostResult CreateProduct(PDbTable product)
        {
            return CreateProductAction(product);
        }

        public List<PDbTable> GetAccessories()
        {
            return GetAccessoriesAction();
        }

        public PDbTable GetProductById(int id)
        {
            return GetProductByIdAction(id);
        }

        public bool MarkAsFavorite(int UserID, int ProductID)
        {
            return MarkAsFavoriteAction(UserID, ProductID);
        }

        public List<int> GetFavorites(int UserID)
        {
            return GetFavoritesAction(UserID);
        }

        public List<PDbTable> GetProductsByCategory(PCategory category)
        {
            return GetProductsByCategoryAction(category);
        }
    }
}
