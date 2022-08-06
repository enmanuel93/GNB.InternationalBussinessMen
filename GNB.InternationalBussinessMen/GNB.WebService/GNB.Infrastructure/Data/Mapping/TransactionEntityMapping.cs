using GNB.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GNB.Infrastructure.Data.Mapping
{
    public class TransactionEntityMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Rate", "GNB");
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Sku).HasColumnName("Sku");
            builder.Property(e => e.Amount).HasColumnName("Amount");
            builder.Property(e => e.Currency).HasColumnName("Currency");
        }
    }
}
