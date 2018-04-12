using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using HTPSSystem.JMont.Data.Entities;
#endregion

namespace HTPSSystem.JMont.DAL
{
   internal class HTPSContext:DbContext
    {
        public HTPSContext() : base("HTPS_db")
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Registration> Registration { get; set; }

    }
}
