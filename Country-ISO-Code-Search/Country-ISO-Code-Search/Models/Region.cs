using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryISOSearch.Models
{
    public class Region
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("iso2Code")]
        public string Iso2Code { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
