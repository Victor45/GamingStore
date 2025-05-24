using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamingTech.Web.Models.Product
{
    public class Accessory
    {
        int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImageURL { get; internal set; }
    }
}