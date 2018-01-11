using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cimob.Models.ProgramViewModels;

namespace Cimob.Models
{
    public class ProgramDbContext : DbContext
    {
        public ProgramDbContext (DbContextOptions<ProgramDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cimob.Models.ProgramViewModels.ProgramViewModel> ProgramViewModel { get; set; }
    }
}
