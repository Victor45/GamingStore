using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamingTech.Web.Models.Product
{
     public class WishList
     {
          public List<int> WList {  get; set; }

          public int UserID { get; set; }
     }
}