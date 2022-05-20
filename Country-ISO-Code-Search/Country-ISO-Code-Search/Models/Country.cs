using Newtonsoft.Json;

namespace CountryISOSearch.Models
{
    public class Country
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("iso2Code")]
        public string Iso2Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }

        [JsonProperty("adminregion")]
        public AdminRegion AdminRegion { get; set; }

        [JsonProperty("incomelevel")]
        public IncomeLevel IncomeLevel { get; set; }

        [JsonProperty("lendingType")]
        public LendingType LendingType { get; set; }

        [JsonProperty("capitalCity")]
        public string CapitalCity { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }
    }
}
