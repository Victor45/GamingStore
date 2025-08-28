using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingTech.Domain.Enums;

namespace GamingTech.Domain.Product
{
     [Table("Products")]
     public class PDbTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Required]
          public string Name { get; set; }
          [Required]
          public string Description { get; set; }
          [Required]
          public float Price { get; set; }
          [Required]
          public string ImageURL { get; set; }
        [Required]
        public int Stock { get; set; }

        [Required]
        public PCategory Category { get; set; }
     }
}
