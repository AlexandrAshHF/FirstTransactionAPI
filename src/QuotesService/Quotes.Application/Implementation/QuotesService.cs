using Microsoft.Extensions.Caching.Distributed;
using Quotes.Application.Contracts.Responses;

namespace Quotes.Application.Implementation
{
    public class QuotesService
    {
        private IDistributedCache _cache;
        public QuotesService(IDistributedCache cache)
        {
            _cache = cache;
        }
    }
}
