using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using Newtonsoft.Json;

using FuelRadar.Model;

namespace FuelRadar.Requests
{
    public static class ApiRequests
    {
        private const String LIST_REQUEST = "https://creativecommons.tankerkoenig.de/json/list.php?";
        private const String PRICE_REQUEST = "https://creativecommons.tankerkoenig.de/json/prices.php?";

        public static async Task<List<PriceInfo>> RequestGasStations(GlobalCoordinate location, double radius)
        {
            String requestString = BuildRequest(LIST_REQUEST, 
                new Parameter("type", "all"), new Parameter("lat", location.Latitude.ToString()),
                new Parameter("lng", location.Longitude.ToString()), new Parameter("rad", radius.ToString()),
                new Parameter("apikey", Secrets.API_KEY));
            HttpWebRequest httpRequest = WebRequest.CreateHttp(requestString);
            WebResponse response = await httpRequest.GetResponseAsync();
            StationListResult result = null;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                 result = JsonSerializer.CreateDefault().Deserialize<StationListResult>(jsonReader);
            }
            return result.IsOk ? result.ToPriceInfos() : new List<PriceInfo>();
        }

        public static async Task<PriceListResult> RequestPrices(IEnumerable<String> stationIds)
        {
            String requestString = ApiRequests.BuildRequest(PRICE_REQUEST);
            HttpWebRequest httpRequest = WebRequest.CreateHttp(requestString);
            WebResponse response = await httpRequest.GetResponseAsync();
            PriceListResult result = null;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                result = JsonSerializer.CreateDefault().Deserialize<PriceListResult>(jsonReader);
            }
            return null;
        }

        private static String BuildRequest(String endpoint, params Parameter[] parameters)
        {
            return endpoint + new List<Parameter>(parameters).Aggregate(String.Empty, (a, b) => a + "&" + b.ToString()).TrimStart('&');
        }

    }

    public class Parameter
    {
        public String Name { get; private set; }
        public String Value { get; private set; }

        public Parameter(String name, String value)
        {
            this.Name = name;
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Name + "=" + this.Value;
        }
    }
}
