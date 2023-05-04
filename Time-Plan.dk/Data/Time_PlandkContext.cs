using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Time_Plan.dk.Data
{
    public class Time_PlandkContext : DbContext
    {
        public Time_PlandkContext (DbContextOptions<Time_PlandkContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; } = default!;
    }
}
