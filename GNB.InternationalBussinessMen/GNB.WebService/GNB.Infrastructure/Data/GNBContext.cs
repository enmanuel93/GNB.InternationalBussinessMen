using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GNB.Domain.Entities.Models;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Infrastructure.Data
{
    public class GNBContext: DbContext
    {
        public GNBContext(DbContextOptions<GNBContext> options) : base(options) {}

        public DbSet<RateModel> Rates { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
