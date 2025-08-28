using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamingTech.Domain.Enums;

namespace GamingTech.Web.Models.Product
{
    public class Accessory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImageURL { get; set; }
        public int Stock { get; set; }
        public bool IsFavorite { get; set; }
        public PCategory Category { get; set; }

    }
}