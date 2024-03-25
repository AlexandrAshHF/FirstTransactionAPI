using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transactions.Core.Entities;

namespace Transactions.Persistance.Configurations
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.HasOne(x => x.SenderCard)
                .WithMany(x => x.SentTransactions)
                .HasForeignKey(x => x.SenderCardId);

            builder.HasOne(x => x.ConsumerCard)
                .WithMany(x => x.ReceivedTransactions)
                .HasForeignKey(x => x.ConsumerCardId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
