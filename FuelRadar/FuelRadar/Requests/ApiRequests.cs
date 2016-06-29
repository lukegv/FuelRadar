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
    /// <summary>
    /// Handles the web requests to the Tankerkönig API
    /// </summary>
    public static class ApiRequests
    {
        private const String LIST_REQUEST = "https://creativecommons.tankerkoenig.de/json/list.php?";
        private const String PRICE_REQUEST = "https://creativecommons.tankerkoenig.de/json/prices.php?";

        private const double DEFAULT_RADIUS = 3;

        public static async Task<List<PriceInfo>> RequestGasStations(GlobalCoordinate location, double radius = DEFAULT_RADIUS)
        {
            String requestString = ApiRequests.BuildRequest(LIST_REQUEST, 
                new Parameter("type", "all"), new Parameter("lat", location.Latitude.ToString()),
                new Parameter("lng", location.Longitude.ToString()), new Parameter("rad", radius.ToString()),
                new Parameter("apikey", Secrets.API_KEY));
            try
            {
                HttpWebRequest httpRequest = WebRequest.CreateHttp(requestString);
                WebResponse response = await httpRequest.GetResponseAsync();
                StationListResult result = null;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                using (JsonTextReader jsonReader = new JsonTextReader(reader))
                {
                    result = JsonSerializer.CreateDefault().Deserialize<StationListResult>(jsonReader);
                }
                return result.IsOk ? result.ToPriceInfos() : null;
            }
            catch (Exception ex)
            {
                // If anything went wrong (maybe better error handling later)
                return null;
            }
        }

        public static async Task<Dictionary<String, Price>> RequestPrices(IEnumerable<String> stationIds)
        {
            String requestString = ApiRequests.BuildRequest(PRICE_REQUEST, 
                new Parameter("ids", ApiRequests.BuildIdsParameter(stationIds)),
                new Parameter("apikey", Secrets.API_KEY));
            try
            {
                HttpWebRequest httpRequest = WebRequest.CreateHttp(requestString);
                WebResponse response = await httpRequest.GetResponseAsync();
                PriceListResult result = null;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                using (JsonTextReader jsonReader = new JsonTextReader(reader))
                {
                    result = JsonSerializer.CreateDefault().Deserialize<PriceListResult>(jsonReader);
                }
                return result.IsOk ? result.Prices.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToPrice()) : null;
            }
            catch (Exception ex)
            {
                // If anything went wrong (maybe better error handling later)
                return null;
            }
        }

        private static String BuildRequest(String endpoint, params Parameter[] parameters)
        {
            return endpoint + String.Join("&", parameters.Select(par => par.ToString()));
        }

        private const String QUOTE = "\"";

        private static String BuildIdsParameter(IEnumerable<String> ids)
        {
            return "[" + String.Join(",", ids.Select(id => QUOTE + id + QUOTE)) + "]";
        }

    }

    /// <summary>
    /// Builds a request parameter
    /// </summary>
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
