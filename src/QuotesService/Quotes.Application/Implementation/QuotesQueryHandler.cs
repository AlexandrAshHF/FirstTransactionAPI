using Microsoft.Extensions.Caching.Distributed;
using Quotes.Application.Contracts.Responses;
using Quotes.Core.Abstractions;
using Quotes.Core.Enums;
using Quotes.Core.Models;
using Shared.Core.Abstractions;
using System.Text.Json;

namespace Quotes.Application.Implementation
{
    public class QuotesQueryHandler : IHandlerAsync<List<QuotesItemResponse>, _>
    {
        private IDistributedCache _cache;
        private IRateTracker _rateTracker;
        private string _keyQuotesKey = "QuotesKey";
        public QuotesQueryHandler(IDistributedCache cache, IRateTracker rateTracker)
        {
            _cache = cache;
            _rateTracker = rateTracker;
        }
        public async Task<List<QuotesItemResponse>> HandleAsync(_ request)
        {
            var currenciesStr = await _cache.GetStringAsync(_keyQuotesKey);
            List<Currency> currencies = new List<Currency>();

            if (currenciesStr == null)
            {
                currencies = await _rateTracker.GetAllCurrency();
                currenciesStr = JsonSerializer.Serialize<List<Currency>>(currencies);

                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(new TimeSpan(12, 0, 0));

                await _cache.SetStringAsync(_keyQuotesKey, currenciesStr, options);
            }

            else
                currencies = JsonSerializer.Deserialize<List<Currency>>(currenciesStr) ?? throw new ArgumentNullException();

            return currencies.Select(x => new QuotesItemResponse
            {
                Id = (CurrencyId)x.Id,
                Abbreviation = x.Abbreviation,
                Rate = x.OfficialRate,
                Scale = x.Scale
            }).ToList();
        }
    }
}