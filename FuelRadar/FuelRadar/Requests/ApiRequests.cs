using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace FuelRadar.Requests
{
    public static class ApiRequests
    {
        private const String LIST_REQUEST = "https://creativecommons.tankerkoenig.de/json/list.php?";
        private const String PRICE_REQUEST = "https://creativecommons.tankerkoenig.de/json/prices.php?";

        public static async Task<StationListResult> RequestGasStations(double latitude, double longitude, double radius)
        {
            String requestString = BuildRequest(LIST_REQUEST, 
                new Parameter("type", "all"), new Parameter("lat", latitude.ToString()),
                new Parameter("lng", longitude.ToString()), new Parameter("rad", radius.ToString()),
                new Parameter("apikey", Secrets.API_KEY));
            HttpWebRequest httpRequest = WebRequest.CreateHttp(requestString);
            WebResponse response = await httpRequest.GetResponseAsync();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                return JsonSerializer.Create().Deserialize<StationListResult>(jsonReader);
            }
        }

        public static async Task<PriceListResult> RequestPrices(IEnumerable<String> stationIds)
        {
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
