﻿using Grpc.Core;
using Quotes.Application.Contracts.Responses;
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
            var quoteConsume = quotes.FirstOrDefault(x => x.Id == (CurrencyId)request.ConsumerCurrency) 
                ?? new QuotesItemResponse
                {
                    Id = CurrencyId.BYN,
                    Abbreviation = "BYN",
                    Rate = 1.0m,
                    Scale = 1,
                };

            var quoteSender = quotes.FirstOrDefault(x => x.Id == (CurrencyId)request.SenderCurrency)
                ?? new QuotesItemResponse
                {
                    Id = CurrencyId.BYN,
                    Abbreviation = "BYN",
                    Rate = 1.0m,
                    Scale = 1,
                };

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
