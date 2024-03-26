using Quotes.Core.Enums;
using Quotes.Core.Models;

namespace Quotes.Core.Abstractions
{
    public interface IRateTracker
    {
        Task<List<Currency>> GetAllCurrency();
        Task<Currency> GetCurrencyById(CurrencyId id);
    }
}