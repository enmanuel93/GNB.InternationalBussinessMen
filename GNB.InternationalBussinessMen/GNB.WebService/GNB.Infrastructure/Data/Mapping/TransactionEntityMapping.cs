using GNB.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GNB.Infrastructure.Data.Mapping
{
    public class TransactionEntityMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions", "GNB");
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Sku).HasColumnName("sku");
            builder.Property(e => e.Amount).HasColumnName("amount").HasColumnType("decimal(11, 4)"); 
            builder.Property(e => e.Currency).HasColumnName("currency");
        }
    }
}
