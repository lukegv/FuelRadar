using System;

using Newtonsoft.Json;

namespace FuelRadar.Requests
{
    public class PriceResult
    {
        [JsonProperty("status")]
        public String Status { get; set; }

        [JsonProperty("diesel")]
        public double DieselPrice { get; set; }
        [JsonProperty("e5")]
        public double E5Price { get; set; }
        [JsonProperty("e10")]
        public double E10Price { get; set; }
    }
}
