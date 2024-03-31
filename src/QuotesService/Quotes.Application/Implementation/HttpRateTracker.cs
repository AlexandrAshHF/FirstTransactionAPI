using Newtonsoft.Json;
using Quotes.Core.Abstractions;
using Quotes.Core.Models;
using Shared.Core.Enums;

namespace Quotes.Application.Implementation
{
    public class HttpRateTracker : IRateTracker
    {
        private HttpClient _httpClient = new HttpClient();
        private readonly string _url = "https://api.nbrb.by/exrates/rates";
        private readonly string _partPeriodicity = "?periodicity=0";
        public async Task<List<BankCurrencyFormat>> GetAllCurrency()
        {
            var response = await _httpClient.GetAsync(_url + _partPeriodicity);
            string json = await response.Content.ReadAsStringAsync();

            List<BankCurrencyFormat> result = new List<BankCurrencyFormat>();
            result = JsonConvert.DeserializeObject<List<BankCurrencyFormat>>(json)
                .Where(x => Enum.IsDefined(typeof(CurrencyId), x.CurrencyId))
                .ToList()
                ?? throw new NullReferenceException();

            return result;
        }
        public async Task<BankCurrencyFormat> GetCurrencyById(CurrencyId id)
        {
            var response = await _httpClient.GetAsync(_url + $"/{(int)id}" + _partPeriodicity);
            var json = await response.Content.ReadAsStringAsync();

            BankCurrencyFormat result = JsonConvert.DeserializeObject<BankCurrencyFormat>(json) ?? throw new NullReferenceException();

            return result;
        }
    }
}