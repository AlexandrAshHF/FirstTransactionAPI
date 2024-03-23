using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transactions.Core.Entities;

namespace Transactions.Persistance.Configurations
{
    internal class CardConfiguration : IEntityTypeConfiguration<CardEntity>
    {
        public void Configure(EntityTypeBuilder<CardEntity> builder)
        {
            builder.HasMany(x => x.Transactions)
                .WithOne(x => x.SenderCard)
                .HasForeignKey(x => x.SenderCardId);

            builder.HasMany(c => c.Transactions)
                .WithOne(t => t.ConsumerCard)
                .HasForeignKey(t => t.ConsumerCardId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
