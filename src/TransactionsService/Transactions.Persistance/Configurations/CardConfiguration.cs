using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transactions.Core.Entities;

namespace Transactions.Persistance.Configurations
{
    internal class CardConfiguration : IEntityTypeConfiguration<CardEntity>
    {
        public void Configure(EntityTypeBuilder<CardEntity> builder)
        {
            builder.HasMany(x => x.SentTransactions)
                .WithOne(x => x.SenderCard)
                .HasForeignKey(x => x.SenderCardId)
                .Metadata.PrincipalToDependent?
                .SetPropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.HasMany(c => c.ReceivedTransactions)
                .WithOne(t => t.ConsumerCard)
                .HasForeignKey(t => t.ConsumerCardId)
                .OnDelete(DeleteBehavior.Restrict)
                .Metadata.PrincipalToDependent?
                .SetPropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.HasMany(x => x.CurrencyAccounts)
                .WithOne(x => x.Card)
                .HasForeignKey(x => x.CardId);
        }
    }
}
