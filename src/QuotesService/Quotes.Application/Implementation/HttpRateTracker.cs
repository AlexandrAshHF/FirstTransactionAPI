using Newtonsoft.Json;
using Quotes.Core.Abstractions;
using Quotes.Core.Enums;
using Quotes.Core.Models;

namespace Quotes.Application.Implementation
{
    public class HttpRateTracker : IRateTracker
    {
        private HttpClient _httpClient = new HttpClient();
        private readonly string _url = "https://api.nbrb.by/exrates/rates";
        private readonly string _partPeriodicity = "?periodicity=0";
        public async Task<List<Currency>> GetAllCurrency()
        {
            var response = await _httpClient.GetAsync(_url + _partPeriodicity);
            var json = await response.Content.ReadAsStringAsync();

            List<Currency> result = new List<Currency>();
            result = JsonConvert.DeserializeObject<List<Currency>>(json) ?? throw new NullReferenceException();

            return result;
        }
        public async Task<Currency> GetCurrencyById(CurrencyId id)
        {
            var response = await _httpClient.GetAsync(_url + $"/{(int)id}" + _partPeriodicity);
            var json = await response.Content.ReadAsStringAsync();

            Currency result = JsonConvert.DeserializeObject<Currency>(json) ?? throw new NullReferenceException();

            return result;
        }
    }
}