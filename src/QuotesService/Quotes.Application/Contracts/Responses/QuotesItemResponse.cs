using Shared.Core.Enums;

namespace Quotes.Application.Contracts.Responses
{
    public class QuotesItemResponse
    {
        public int Scale { get; set; }
        public decimal Rate { get; set; }
        public string Abbreviation { get; set; }
        public CurrencyId Id { get; set; }
    }
}
