using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using FuelRadar.Model;

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

        public List<PriceInfo> ToPriceInfos()
        {
            return this.Stations.Select(item => item.ToPriceInfo()).ToList();
        }
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

        public PriceInfo ToPriceInfo()
        {
            Station station = new Station(this.ID, this.Name, this.Brand, this.Latitude, this.Longitude);
            Price price = new Price(this.DieselPrice, this.E5Price, this.E10Price);
            return new PriceInfo(station, price);
        }
    }
}
