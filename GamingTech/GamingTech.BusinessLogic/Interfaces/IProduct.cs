using GamingTech.Domain.Product;
using GamingTech.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTech.BusinessLogic.Interfaces
{
     public interface IProduct
     {
          PostResult CreateProduct(PDbTable product);
          List<PDbTable> GetAccessories();

          PDbTable GetProductById(int id);
     }
}
