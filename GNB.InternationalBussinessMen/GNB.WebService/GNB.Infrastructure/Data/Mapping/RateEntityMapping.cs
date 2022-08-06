using GNB.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Infrastructure.Data.Mapping
{
    public class RateEntityMapping : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.ToTable("Rate", "GNB");
            builder.HasKey(x => x.Id);
            builder.Property(e => e.RateProp).HasColumnName("Rate");
            builder.Property(e => e.To).HasColumnName("To");
            builder.Property(e => e.From).HasColumnName("From");
        }
    }
}
