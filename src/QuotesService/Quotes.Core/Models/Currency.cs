using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace Quotes.Core.Models
{
    [Serializable]
    public class Currency
    {
        public Currency(int id, DateTime requestDate, int scale, string abbreviation, string name, decimal officialRate)
        {
            Id = id;
            RequestDate = requestDate;
            Scale = scale;
            Abbreviation = abbreviation;
            Name = name;
            OfficialRate = officialRate;
        }

        [JsonConstructor]
        public Currency(JObject jObject)
        {
            Id = (int)jObject["Cur_ID"];
            RequestDate = (DateTime)jObject["Date"];
            Scale = (int)jObject["Cur_Scale"];
            Abbreviation = (string)jObject["Cur_Abbreviation"];
            Name = (string)jObject["Cur_Name"];
            OfficialRate = (decimal)jObject["Cur_OfficialRate"];
        }
        public int Id { get; private set; }
        public DateTime RequestDate { get; private set; }
        public int Scale { get; private set; }
        public string Abbreviation { get; private set; }
        public string Name { get; private set; }
        public decimal OfficialRate { get; private set; }
    }
}
