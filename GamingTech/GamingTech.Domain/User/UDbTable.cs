using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTech.Domain.User
{
    public class UDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Error")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Error")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email Adrress")]
        [StringLength(30)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastLogin { get; set; }

        [StringLength(30)]
        public string LastIP { get; set; }
    }
}
