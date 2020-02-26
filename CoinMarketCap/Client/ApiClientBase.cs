using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace CoinMarketCap.Client
{
    public abstract class ApiClientBase
    {
        private readonly string _apiKey = ConfigurationManager.AppSettings["CoinMarketCap.ApiKey"];

        private readonly bool _sandbox =
            ConfigurationManager.AppSettings["CoinMarketCap"]?.ToLowerInvariant().Equals("true") ?? false;

        private const string ApiBaseUrlPro = "https://pro-api.coinmarketcap.com/v1/";
        private const string ApiBaseUrlSandbox = "https://pro-api.coinmarketcap.com/v1/";

        private string ApiBaseUrl =>
            _sandbox
                ? ApiBaseUrlSandbox
                : ApiBaseUrlPro;

        protected T ApiRequest<T>(string endpoint, Dictionary<string, string> parameters)
        {
            var url = new UriBuilder($"{ApiBaseUrl}{endpoint}");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            foreach (var param in parameters
                .Where(param => !string.IsNullOrWhiteSpace(param.Value)))
            {
                queryString[param.Key] = param.Value;
            }
            url.Query = queryString.ToString();

            string responseJson;
            using (var client = new WebClient())
            {
                client.Headers.Add("X-CMC_PRO_API_KEY", _apiKey);
                client.Headers.Add("Accepts", "application/json");
                responseJson = client.DownloadString(url.ToString());
            }

            return JsonConvert.DeserializeObject<T>(responseJson);
        }
    }
}
