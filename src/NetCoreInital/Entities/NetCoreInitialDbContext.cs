using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreInital.Entities
{
    public class NetCoreInitialDbContext  : IdentityDbContext<User>
    {
        public NetCoreInitialDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
