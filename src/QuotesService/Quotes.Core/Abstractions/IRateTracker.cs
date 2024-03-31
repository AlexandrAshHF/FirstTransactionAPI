using Quotes.Core.Models;
using Shared.Core.Enums;

namespace Quotes.Core.Abstractions
{
    public interface IRateTracker
    {
        Task<List<BankCurrencyFormat>> GetAllCurrency();
        Task<BankCurrencyFormat> GetCurrencyById(CurrencyId id);
    }
}