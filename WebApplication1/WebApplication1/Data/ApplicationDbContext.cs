using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cimob.Models;

namespace Cimob.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Cimob.Models.Question> Questions { get; set; }
        public DbSet<Cimob.Models.ProfileType> ProfileTypes { get; set; }
        public DbSet<Cimob.Models.Destination> Destinations { get; set; }
        public DbSet<Cimob.Models.Entity> Entities { get; set; }
        public DbSet<Cimob.Models.Program> Programs { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Cimob.Data.ApplicationDbContext" /> class. 
        /// </summary>
        /// <param name="options"></param>
        /// <remarks></remarks>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public DbSet<Cimob.Models.Candidatura> Candidatura { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public DbSet<Cimob.Models.Interview> Interview { get; set; }
    }
}
