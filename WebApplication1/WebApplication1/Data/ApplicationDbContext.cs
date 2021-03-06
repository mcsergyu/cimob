﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cimob.Models;

namespace Cimob.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Cimob.Models.Question> Questions { get; set; }
        public DbSet<Cimob.Models.ProfileType> ProfileTypes { get; set; }
        public DbSet<Cimob.Models.Destination> Destinations { get; set; }
        public DbSet<Cimob.Models.Entity> Entities { get; set; }
        public DbSet<Cimob.Models.Program> Programs { get; set; }


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
       
        public DbSet<Cimob.Models.Candidatura> Candidatura { get; set; }
       
        public DbSet<Cimob.Models.Interview> Interview { get; set; }
    }
}
