using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transactions.Core.Entities;

namespace Transactions.Persistance.Configurations
{
    internal class CurrencyAccountConfiguration : IEntityTypeConfiguration<CurrencyAccount>
    {
        public void Configure(EntityTypeBuilder<CurrencyAccount> builder)
        {
            builder.HasOne(x => x.Card)
                .WithMany(x => x.CurrencyAccounts)
                .HasForeignKey(x => x.CardId);
        }
    }
}
