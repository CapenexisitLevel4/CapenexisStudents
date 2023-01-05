using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapenexisLearners.Models;

namespace CapenexisLearners.Data
{
    public class CapenexisLearnersContext : DbContext
    {
        public CapenexisLearnersContext (DbContextOptions<CapenexisLearnersContext> options)
            : base(options)
        {
        }

        public DbSet<CapenexisLearners.Models.Learner> Learner { get; set; } = default!;
    }
}
