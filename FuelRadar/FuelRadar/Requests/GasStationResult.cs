using System;

using Newtonsoft.Json;

namespace FuelRadar.Model
{
    public class GasStationResult
    {
        [JsonProperty("id")]
        public String ID { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("brand")]
        public String Brand { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lng")]
        public double Longitude { get; set; }

        [JsonProperty("diesel")]
        public double DieselPrice { get; set; }
        [JsonProperty("e5")]
        public double E5Price { get; set; }
        [JsonProperty("e10")]
        public double E10Price { get; set; }
    }
}
