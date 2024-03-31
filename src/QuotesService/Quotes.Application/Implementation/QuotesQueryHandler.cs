using Microsoft.Extensions.Caching.Distributed;
using Quotes.Application.Contracts.Responses;
using Quotes.Core.Abstractions;
using Quotes.Core.Models;
using Shared.Core.Abstractions;
using Shared.Core.Enums;
using System.Text.Json;

namespace Quotes.Application.Implementation
{
    public class QuotesQueryHandler : IHandlerAsync<List<QuotesItemResponse>, object?>
    {
        private IDistributedCache _cache;
        private IRateTracker _rateTracker;
        private string _keyQuotesKey = "QuotesKey";
        public QuotesQueryHandler(IDistributedCache cache, IRateTracker rateTracker)
        {
            _cache = cache;
            _rateTracker = rateTracker;
        }
        public async Task<List<QuotesItemResponse>> HandleAsync(object? request)
        {
            var currenciesStr = await _cache.GetStringAsync(_keyQuotesKey);
            List<BankCurrencyFormat> currencies = new List<BankCurrencyFormat>();

            if (currenciesStr == null)
            {
                currencies = await _rateTracker.GetAllCurrency();
                currenciesStr = JsonSerializer.Serialize<List<BankCurrencyFormat>>(currencies);

                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(new TimeSpan(12, 0, 0));

                await _cache.SetStringAsync(_keyQuotesKey, currenciesStr, options);
            }

            else
                currencies = JsonSerializer.Deserialize<List<BankCurrencyFormat>>(currenciesStr) ?? throw new ArgumentNullException();

            return currencies.Select(x => new QuotesItemResponse
            {
                Id = (CurrencyId)x.CurrencyId,
                Abbreviation = x.Abberviation,
                Scale = x.Scale,
                Rate = x.OfficalRate
            }).ToList();
        }
    }
}