using Grpc.Core;
using Quotes.Application.Implementation;
using Shared.Application.Protos;
using Shared.Core.Enums;

namespace Quotes.Application.gRPC
{
    public class ExchangeService : Exchange.ExchangeBase
    {
        private QuotesQueryHandler _queryHandler;
        public ExchangeService(QuotesQueryHandler handler) 
        {
            _queryHandler = handler;
        }
        public override async Task<CurrencyConvertResponse> ConvertCurrencies(CurrencyConvertRequest request, ServerCallContext callContext)
        {
            var quotes = await _queryHandler.HandleAsync(null);
            var quoteConsume = quotes.First(x => x.Id == (CurrencyId)request.ConsumerCurrency);
            var quoteSender = quotes.First(x => x.Id == (CurrencyId)request.SenderCurrency);

            double bynAmount = (request.Amount * Convert.ToDouble(quoteSender.Rate)) / Convert.ToDouble(quoteSender.Scale); // define to second return

            return (CurrencyId)request.SenderCurrency == CurrencyId.BYN 
                ? new CurrencyConvertResponse 
                { 
                    ConvartationResult = (request.Amount / Convert.ToDouble(quoteConsume.Rate)) * Convert.ToDouble(quoteConsume.Scale),
                    ConvertationCurrency = (int)request.ConsumerCurrency
                }
                : new CurrencyConvertResponse
                { 
                    ConvartationResult = (bynAmount / Convert.ToDouble(quoteConsume.Rate)) * Convert.ToDouble(quoteConsume.Scale),
                    ConvertationCurrency = (int)request.ConsumerCurrency
                };
        }
    }
}
