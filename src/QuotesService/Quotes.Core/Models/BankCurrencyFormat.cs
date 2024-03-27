using Newtonsoft.Json;

namespace Quotes.Core.Models
{
    public class BankCurrencyFormat
    {
        [JsonProperty("Cur_ID")]
        public int CurrencyId { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("Cur_Abbreviation")]
        public string Abberviation { get; set; }

        [JsonProperty("Cur_Scale")]
        public int Scale { get; set; }

        [JsonProperty("Cur_Name")]
        public string Name { get; set; }

        [JsonProperty("Cur_OfficialRate")]
        public decimal OfficalRate { get; set; }
    }
}
