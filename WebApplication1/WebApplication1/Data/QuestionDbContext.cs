using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;

namespace Cimob.Models
{
    public class QuestionDbContext : DbContext
    {

        public QuestionDbContext(DbContextOptions<QuestionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cimob.Models.Question> Question { get; set; }
        
    }
}
