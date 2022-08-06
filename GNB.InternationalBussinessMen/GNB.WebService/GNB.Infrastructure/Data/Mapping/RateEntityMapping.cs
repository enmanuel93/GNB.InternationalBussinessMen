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
    public class RateEntityMapping : IEntityTypeConfiguration<RateModel>
    {
        public void Configure(EntityTypeBuilder<RateModel> builder)
        {
            builder.ToTable("Rate", "GNB");
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Rate).HasColumnName("rate");
            builder.Property(e => e.To).HasColumnName("toR");
            builder.Property(e => e.From).HasColumnName("fromR");
        }
    }
}
