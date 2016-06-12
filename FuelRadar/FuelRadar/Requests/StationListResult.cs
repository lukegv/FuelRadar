using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace FuelRadar.Requests
{
    public class StationListResult
    {
        [JsonProperty("status")]
        public String Status { get; set; }

        [JsonProperty("ok")]
        public bool IsOk { get; set; }

        [JsonProperty("stations")]
        public List<StationResult> Stations { get; set; }
    }

    public class StationResult
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
