using GamingTech.BusinessLogic.Interfaces;
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
            throw new NotImplementedException();
        }
    }
}
