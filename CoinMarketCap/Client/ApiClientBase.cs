using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace CoinMarketCap.Client
{
    public abstract class ApiClientBase
    {
        private readonly string _apiKey;
        private readonly bool _sandbox;

        private const string ApiBaseUrlPro = "https://pro-api.coinmarketcap.com/v1/";
        private const string ApiBaseUrlSandbox = "https://sandbox-api.coinmarketcap.com/v1/";

        private string ApiBaseUrl =>
            _sandbox
                ? ApiBaseUrlSandbox
                : ApiBaseUrlPro;

        protected ApiClientBase(string apiKey, bool sandbox = false)
        {
            _apiKey = apiKey;
            _sandbox = sandbox;
        }

        protected T ApiRequest<T>(string endpoint, Dictionary<string, string> parameters) where T : class
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
            using (var client = new AutomaticDecompressionWebClient())
            {
                client.Headers.Add("X-CMC_PRO_API_KEY", _apiKey);
                client.Headers.Add(HttpRequestHeader.Accept, "application/json");

                try
                {
                    responseJson = client.DownloadString(url.ToString());
                }
                catch (WebException ex)
                {
                    if (ex.Response == null)
                    {
                        throw;
                    }
                    // Deserialize response from the API if present
                    using (var response = ex.Response)
                    {
                        var stream = response.GetResponseStream();
                        if (stream == null)
                        {
                            throw;
                        }

                        using (var reader = new StreamReader(stream))
                        {
                            responseJson = reader.ReadToEnd();
                        }
                    }
                }
            }

            return string.IsNullOrWhiteSpace(responseJson)
                ? null
                : JsonConvert.DeserializeObject<T>(responseJson);
        }
    }
}
