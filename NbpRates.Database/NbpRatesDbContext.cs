using Microsoft.EntityFrameworkCore;
using NbpRates.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbpRates.Database
{
    public class NbpRatesDbContext : DbContext
    {
        public NbpRatesDbContext(DbContextOptions<NbpRatesDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Rate> Rates { get; set; }
    }
}
