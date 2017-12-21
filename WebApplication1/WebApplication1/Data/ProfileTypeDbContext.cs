using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cimob.Models
{
    public class ProfileTypeDbContext : DbContext
    {
        public ProfileTypeDbContext(DbContextOptions<ProfileTypeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cimob.Models.ProfileType> ProfileType { get; set; }

    }
}
