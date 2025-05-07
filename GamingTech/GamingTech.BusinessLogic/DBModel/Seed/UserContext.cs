using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingTech.Domain.User;

namespace GamingTech.BusinessLogic.DBModel.Seed
{
    class UserContext : DbContext
    {
        public UserContext() : base("name=GamingTech")
        {
        }

        public virtual DbSet<UDbTable> Users { get; set; }
    }
}
