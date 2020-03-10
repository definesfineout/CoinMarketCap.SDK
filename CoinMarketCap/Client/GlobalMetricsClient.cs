using CoinMarketCap.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinMarketCap.Client
{
    public class GlobalMetricsClient : ApiClientBase
    {
        public GlobalMetricsClient(string apiKey, bool sandbox = false)
            : base(apiKey, sandbox)
        { }

        #region Endpoint: /v1/global-metrics/quotes/latest - Latest Global Metrics

        /// <summary>
        /// Returns the latest global cryptocurrency market metrics. Use the <value>convert</value> option to return market
        /// values in multiple fiat and cryptocurrency conversions in the same call.
        /// </summary>
        /// <param name="convert">
        /// Optionally calculate market quotes in up to 120 currencies at once by passing a comma-separated list of
        /// cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an additional
        /// call credit. A list of supported fiat options can be found at 
        /// https://sandbox.coinmarketcap.com/api/v1/#section/Standards-and-Conventions. 
        /// Each conversion is returned in its own <value>quote</value> object.
        /// </param>
        /// <param name="convertId">
        /// Optionally calculate market quotes by CoinMarketCap ID instead of symbol. This option is
        /// identical to <see cref="convert"/> outside of ID format. Ex: <value>convert_id=1,2781</value>
        /// would replace <value>convert=BTC,USD</value> in your query. This parameter cannot be used when
        /// <see cref="convert"/> is used.
        /// </param>
        /// <returns></returns>
        public ApiResponse<GlobalMetricsQuotesLatest> QuotesLatest(
            string convert = null, string convertId = null)
        {
            return ApiRequest<ApiResponse<GlobalMetricsQuotesLatest>>("global-metrics/quotes/latest",
                new Dictionary<string, string>()
                {
                    ["convert"] = convert,
                    ["convert_id"] = convertId
                });
        }

        #endregion Endpoint: /v1/global-metrics/quotes/latest - Latest Global Metrics
    }
}
