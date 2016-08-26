using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using FuelRadar.Model;

namespace FuelRadar.Requests
{
    /// <summary>
    /// Deserializes the JSON result of a price request
    /// </summary>
    public class PriceListResult
    {
        [JsonProperty("status")]
        public String Status { get; set; }

        [JsonProperty("ok")]
        public bool IsOk { get; set; }

        [JsonProperty("prices")]
        public Dictionary<String, PriceResult> Prices { get; set; }

        public PriceListResult()
        {

        }

    }

    /// <summary>
    /// Deserializes a single price element from the JSON result of a price request
    /// </summary>
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

        public PriceResult()
        {

        }

        public Price ToPrice()
        {
            if (this.Status == "open")
            {
                return new Price(this.DieselPrice, this.E5Price, this.E10Price);
            }
            return null;
        }
    }
}
