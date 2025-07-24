using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTech.Domain.User
{
     public class WLDbTable
     {
          [Required]
          public List<int> WList { get; set; }

          [Required]
          [Display(Name = "Email Adrress")]
          [StringLength(30)]
          public string Email { get; set; }
     }
}
