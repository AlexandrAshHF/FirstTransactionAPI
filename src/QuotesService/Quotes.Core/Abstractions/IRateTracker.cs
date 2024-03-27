using Quotes.Core.Enums;
using Quotes.Core.Models;

namespace Quotes.Core.Abstractions
{
    public interface IRateTracker
    {
        Task<List<BankCurrencyFormat>> GetAllCurrency();
        Task<BankCurrencyFormat> GetCurrencyById(CurrencyId id);
    }
}