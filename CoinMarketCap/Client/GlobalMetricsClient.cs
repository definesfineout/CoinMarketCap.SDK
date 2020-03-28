using CoinMarketCap.DataContracts;
using CoinMarketCap.Enumerations;
using System;
using System.Collections.Generic;

namespace CoinMarketCap.Client
{
    public class GlobalMetricsClient : ApiClientBase
    {
        public GlobalMetricsClient(string apiKey, bool sandbox = false)
            : base(apiKey, sandbox)
        { }

        #region Endpoint: /v1/global-metrics/quotes/latest - Latest Global Metrics

        /// <summary>
        /// Returns the latest global cryptocurrency market metrics. Use the <value>convert</value> option to return
        /// market values in multiple fiat and cryptocurrency conversions in the same call.
        /// </summary>
        /// <param name="convert">
        /// Optionally calculate market quotes in up to 120 currencies at once by passing a comma-separated list of
        /// cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an
        /// additional call credit. A list of supported fiat options can be found at 
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

        #region Endpoint: /v1/global-metrics/quotes/historical - Historical Global Metrics

        /// <summary>
        /// Returns an interval of historical global cryptocurrency market metrics based on time and interval parameters.
        /// </summary>
        /// <param name="timeStart">
        /// Timestamp (Unix or ISO 8601) to start returning quotes for. Optional, if not passed, returns quotes calculated in
        /// reverse from <value>time_end</value>.
        /// </param>
        /// <param name="timeEnd">
        /// Timestamp (Unix or ISO 8601) to stop returning quotes for (inclusive). Optional, if not passed, defaults to the 
        /// current time. If no <value>time_start</value> is passed, returns quotes in reverse order starting from this time.
        /// </param>
        /// <param name="count">
        /// The number of interval periods to return results for. Optional, required if both <value>time_start</value> and 
        /// <value>time_end</value> aren't supplied.
        ///     Default: <value>10</value>.
        ///     Valid values: <value>[1 .. 10000]</value>
        /// </param>
        /// <param name="interval">
        /// Interval of time to return data points for.
        /// See https://coinmarketcap.com/api/documentation/v1/#operation/getV1GlobalmetricsQuotesHistorical for details.
        ///     Default: <value>1d</value>.
        ///     Valid values: see <see cref="eInterval"/>
        /// </param>
        /// <param name="convert">
        /// By default market quotes are returned in <value>USD</value>. Optionally calculate market quotes in up to 3 other fiat
        /// currencies or cryptocurrencies.
        /// </param>
        /// <param name="convertId">
        /// Optionally calculate market quotes by CoinMarketCap ID instead of symbol. This option is
        /// identical to <see cref="convert"/> outside of ID format. Ex: <value>convert_id=1,2781</value>
        /// would replace <value>convert=BTC,USD</value> in your query. This parameter cannot be used when
        /// <see cref="convert"/> is used.
        /// </param>
        /// <param name="aux">
        /// Optionally specify a comma-separated list of supplemental data fields to return. Pass
        /// <value>btc_dominance, active_cryptocurrencies, active_
        /// s, active_market_pairs, total_volume_24h, 
        /// total_volume_24h_reported, altcoin_market_cap, altcoin_volume_24h, altcoin_volume_24h_reported, search_interval
        /// </value> to include all auxilliary fields.
        ///     Default: <value>btc_dominance, active_cryptocurrencies, active_exchanges, active_market_pairs, total_volume_24h, 
        ///              total_volume_24h_reported, altcoin_market_cap, altcoin_volume_24h, altcoin_volume_24h_reported</value>
        /// </param>
        /// <returns>	
        /// Results of your query returned as an object.
        ///</returns>
        public ApiResponse<GlobalMetricsQuotesHistorical> QuotesHistorical(
            DateTime? timeStart = null, DateTime? timeEnd = null,
            int? count = null, eInterval? interval = null,
            string convert = null, string convertId = null,
            string aux = null)
        {
            return ApiRequest<ApiResponse<GlobalMetricsQuotesHistorical>>("global-metrics/quotes/historical",
                new Dictionary<string, string>()
                {
                    ["time_start"] = timeStart?.ToString("yyyy-MM-dd"),
                    ["time_end"] = timeEnd?.ToString("yyyy-MM-dd"),
                    ["count"] = count?.ToString(),
                    ["interval"] = interval?.GetDescription(),
                    ["convert"] = convert,
                    ["convertId"] = convertId,
                    ["aux"] = aux
                });
        }

        #endregion Endpoint: /v1/global-metrics/quotes/historical - Historical Global Metrics
    }
}
