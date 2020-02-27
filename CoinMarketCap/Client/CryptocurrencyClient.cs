using CoinMarketCap.DataContracts;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CoinMarketCap.Client
{
    // ReSharper disable once UnusedMember.Global
    public class CryptocurrencyClient : ApiClientBase
    {
        #region Endpoint: /v1/cryptocurrency/map - CoinMarketCap ID map

        /// <summary>
        /// Returns a mapping of all cryptocurrencies to unique CoinMarketCap IDs.
        /// <remarks>See https://coinmarketcap.com/api/documentation/v1/#operation/getV1CryptocurrencyMap </remarks>
        /// </summary>
        /// <param name="listingStatus"></param>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="sort"></param>
        /// <param name="symbol"></param>
        /// <param name="aux"></param>
        /// <returns></returns>
        public ApiResponseList<CryptocurrencyIdMapping> Map(string listingStatus = null, int? start = null,
            int? limit = null, string sort = null, string symbol = null, string aux = null)
        {
            if (start.HasValue && start < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(start), start.Value,
                    $"{nameof(start)} must be greater than or equal to 1.");
            }

            return ApiRequest<ApiResponseList<CryptocurrencyIdMapping>>("cryptocurrency/map",
                new Dictionary<string, string>
                {
                    ["listing_status"] = listingStatus,
                    ["start"] = start.HasValue ? start.ToString() : string.Empty,
                    ["limit"] = limit.HasValue ? limit.ToString() : string.Empty,
                    ["sort"] = sort,
                    ["symbol"] = symbol,
                    ["aux"] = aux
                });
        }

        #endregion Endpoint: /v1/cryptocurrency/map - CoinMarketCap ID map

        #region Endpoint: /v1/cryptocurrency/info - Metadata

        // ReSharper disable once UnusedMember.Global
        public ApiResponseMap<CryptocurrencyMetadata> MetadataById(
            string id, string aux = null)
        {
            return Metadata(id, null, null, aux);
        }
        // ReSharper disable once UnusedMember.Global
        public ApiResponseMap<CryptocurrencyMetadata> MetadataBySlug(
            string slug, string aux = null)
        {
            return Metadata(null, slug, null, aux);
        }
        // ReSharper disable once UnusedMember.Global
        public ApiResponseMap<CryptocurrencyMetadata> MetadataBySymbol(
            string symbol, string aux = null)
        {
            return Metadata(null, null, symbol, aux);
        }

        /// <summary>
        /// Returns all static metadata available for one or more cryptocurrencies. This information
        /// includes details like logo, description, official website URL, social links, and links to a
        /// cryptocurrency's technical documentation.
        /// <remarks>See https://coinmarketcap.com/api/documentation/v1/#operation/getV1CryptocurrencyInfo </remarks>
        /// </summary>
        /// <param name="id">One or more comma-separated cryptocurrency CoinMarketCap IDs. Example: 1,2</param>
        /// <param name="slug"></param>
        /// <param name="symbol"></param>
        /// <param name="aux"></param>
        /// <returns>A map of cryptocurrency objects by ID, symbol, or slug (as used in query parameters).</returns>
        public ApiResponseMap<CryptocurrencyMetadata> Metadata(
            string id = null, string slug = null, string symbol = null, string aux = null)
        {
            if (string.IsNullOrWhiteSpace(id) &&
                string.IsNullOrWhiteSpace(slug) &&
                string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException($"Must specify one of: {nameof(id)}, {nameof(slug)}, or {nameof(symbol)}",
                    nameof(id));
            }

            return ApiRequest<ApiResponseMap<CryptocurrencyMetadata>>("cryptocurrency/info",
                new Dictionary<string, string>
                {
                    ["id"] = id,
                    ["slug"] = slug,
                    ["symbol"] = symbol,
                    ["aux"] = aux
                });
        }

        #endregion Endpoint: /v1/cryptocurrency/info - Metadata

        #region Endpoint: /v1/cryptocurrency/listings/latest - Latest listings

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="priceMin"></param>
        /// <param name="priceMax"></param>
        /// <param name="marketCapMin"></param>
        /// <param name="marketCapMax"></param>
        /// <param name="volume24HMin"></param>
        /// <param name="volume24HMax"></param>
        /// <param name="circulatingSupplyMin"></param>
        /// <param name="circulatingSupplyMax"></param>
        /// <param name="percentChange24HMin"></param>
        /// <param name="percentChange24HMax"></param>
        /// <param name="convert"></param>
        /// <param name="convertId"></param>
        /// <param name="sort"></param>
        /// <param name="sortDir"></param>
        /// <param name="cryptocurrencyType"></param>
        /// <param name="aux"></param>
        /// <returns></returns>
        public ApiResponseList<Cryptocurrency> ListingsLatest(
            int? start = 1, int? limit = 5000,
            long? priceMin = null, long? priceMax = null,
            long? marketCapMin = null, long? marketCapMax = null,
            long? volume24HMin = null, long? volume24HMax = null,
            long? circulatingSupplyMin = null, long? circulatingSupplyMax = null,
            double? percentChange24HMin = null, double? percentChange24HMax = null,
            string convert = null, string convertId = null,
            string sort = "market_cap", string sortDir = null,
            string cryptocurrencyType = null, string aux = null)
        {
            return ApiRequest<ApiResponseList<Cryptocurrency>>("cryptocurrency/listings/latest",
                new Dictionary<string, string>
                {
                    ["start"] = start?.ToString(),
                    ["limit"] = limit?.ToString(),
                    ["price_min"] = priceMin?.ToString(),
                    ["price_max"] = priceMax?.ToString(),
                    ["market_cap_min"] = marketCapMin?.ToString(),
                    ["market_cap_max"] = marketCapMax?.ToString(),
                    ["volume_24h_min"] = volume24HMin?.ToString(),
                    ["volume_24h_max"] = volume24HMax?.ToString(),
                    ["circulating_supply_min"] = circulatingSupplyMin?.ToString(),
                    ["circulating_supply_max"] = circulatingSupplyMax?.ToString(),
                    ["percent_change_24h_min"] = percentChange24HMin?.ToString(CultureInfo.InvariantCulture),
                    ["percent_change_24h_max"] = percentChange24HMax?.ToString(CultureInfo.InvariantCulture),
                    ["convert"] = convert,
                    ["convert_id"] = convertId,
                    ["sort"] = sort,
                    ["sort_dir"] = sortDir,
                    ["cryptocurrency_type"] = sortDir,
                    ["aux"] = aux
                });
        }

        #endregion Endpoint: /v1/cryptocurrency/listings/latest - Latest listings

        #region Endpoint: /v1/cryptocurrency/quotes/latest - Latest quotes

        /// <summary>
        /// <see cref="QuotesLatest"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="convert"></param>
        /// <param name="convertId"></param>
        /// <param name="aux"></param>
        /// <param name="skipInvalid"></param>
        /// <returns></returns>
        public ApiResponseMap<Cryptocurrency> QuotesLatestById(
            string id, string convert = null, string convertId = null,
            string aux = null, bool skipInvalid = false)
        {
            return QuotesLatest(id, null, null, convert, convertId, aux, skipInvalid);
        }

        /// <summary>
        /// <see cref="QuotesLatest"/>
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="convert"></param>
        /// <param name="convertId"></param>
        /// <param name="aux"></param>
        /// <param name="skipInvalid"></param>
        /// <returns></returns>
        public ApiResponseMap<Cryptocurrency> QuotesLatestBySlug(
            string slug, string convert = null, string convertId = null,
            string aux = null, bool skipInvalid = false)
        {
            return QuotesLatest(null, slug, null, convert, convertId, aux, skipInvalid);
        }

        /// <summary>
        /// <see cref="QuotesLatest"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="convert"></param>
        /// <param name="convertId"></param>
        /// <param name="aux"></param>
        /// <param name="skipInvalid"></param>
        /// <returns></returns>
        public ApiResponseMap<Cryptocurrency> QuotesLatestBySymbol(
            string symbol, string convert = null, string convertId = null,
            string aux = null, bool skipInvalid = false)
        {
            return QuotesLatest(null, null, symbol, convert, convertId, aux, skipInvalid);
        }

        /// <summary>
        /// Returns the latest market quote for 1 or more cryptocurrencies. Use the "convert" option to
        /// return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// <remarks>See https://coinmarketcap.com/api/documentation/v1/#operation/getV1CryptocurrencyQuotesLatest </remarks>
        /// </summary>
        /// <param name="id">One or more comma-separated cryptocurrency CoinMarketCap IDs. Example: 1,2</param>
        /// <param name="slug"></param>
        /// <param name="symbol"></param>
        /// <param name="convert"></param>
        /// <param name="convertId"></param>
        /// <param name="aux"></param>
        /// <param name="skipInvalid"></param>
        /// <returns>A map of cryptocurrency objects by ID, symbol, or slug (as used in query parameters).</returns>
        public ApiResponseMap<Cryptocurrency> QuotesLatest(
            string id = null, string slug = null, string symbol = null,
            string convert = null, string convertId = null, string aux = null,
            bool skipInvalid = false)
        {
            if (string.IsNullOrWhiteSpace(id) &&
                string.IsNullOrWhiteSpace(slug) &&
                string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException($"Must specify one of: {nameof(id)}, {nameof(slug)}, or {nameof(symbol)}",
                    nameof(id));
            }

            return ApiRequest<ApiResponseMap<Cryptocurrency>>("cryptocurrency/quotes/latest",
                new Dictionary<string, string>
                {
                    ["id"] = id,
                    ["slug"] = slug,
                    ["symbol"] = symbol,
                    ["convert"] = convert,
                    ["convert_id"] = convertId,
                    ["aux"] = aux,
                    ["skip_invalid"] = "true"
                });
        }

        #endregion Endpoint: /v1/cryptocurrency/quotes/latest - Latest quotes

        #region Endpoint: /v1/cryptopcurrency/quotes/historical - Historical Quotes

        /// <summary>
        /// <see cref="QuotesHistorical"/>
        /// </summary>
        /// <param name="id">One or more comma-separated CoinMarketCap cryptocurrency IDs. Example: "1,2"</param>
        /// <param name="time_start">Timestamp (Unix or ISO 8601) to start returning quotes for. Optional, if not passed, we'll return quotes calculated in reverse from "time_end".</param>
        /// <param name="time_end">Timestamp (Unix or ISO 8601) to stop returning quotes for (inclusive). Optional, if not passed, we'll default to the current time. If no "time_start" is passed, we return quotes in reverse order starting from this time.</param>
        /// <param name="count">The number of interval periods to return results for. Optional, required if both "time_start" and "time_end" aren't supplied. The default is 10 items.</param>
        /// <param name="interval">Interval of time to return data points for. If null, defaults to "5m".</param>
        /// <param name="convert">By default market quotes are returned in USD. Optionally calculate market quotes in up to 3 other fiat currencies or cryptocurrencies.</param>
        /// <param name="convertId">Optionally calculate market quotes by CoinMarketCap ID instead of symbol. This option is identical to convert outside of ID format. Ex: convert_id=1,2781 would replace convert=BTC,USD in your query. This parameter cannot be used when convert is used.</param>
        /// <param name="aux">Specify a comma-separated list of supplemental data fields to return. Pass "price, volume, market_cap, quote_timestamp, search_interval" to include all auxiliary fields.</param>
        /// <returns></returns>
        public ApiResponse<CryptocurrencyHistoricalData> QuotesHistoricalById(
            string id, DateTime? time_start = null,
            DateTime? time_end = null, int? count = null, string interval = null, string convert = null,
            string convertId = null, string aux = null)
        {
            return QuotesHistorical(id, null, time_start, time_end, count, interval, convert, convertId, aux);
        }

        /// <summary>
        /// <see cref="QuotesHistorical"/>
        /// </summary>
        /// <param name="symbol">Alternatively pass one or more comma-separated cryptocurrency symbols. Example: "BTC,ETH". At least one "id" or "symbol" is required for this request.</param>
        /// <param name="time_start">Timestamp (Unix or ISO 8601) to start returning quotes for. Optional, if not passed, we'll return quotes calculated in reverse from "time_end".</param>
        /// <param name="time_end">Timestamp (Unix or ISO 8601) to stop returning quotes for (inclusive). Optional, if not passed, we'll default to the current time. If no "time_start" is passed, we return quotes in reverse order starting from this time.</param>
        /// <param name="count">The number of interval periods to return results for. Optional, required if both "time_start" and "time_end" aren't supplied. The default is 10 items.</param>
        /// <param name="interval">Interval of time to return data points for. If null, defaults to "5m".</param>
        /// <param name="convert">By default market quotes are returned in USD. Optionally calculate market quotes in up to 3 other fiat currencies or cryptocurrencies.</param>
        /// <param name="convertId">Optionally calculate market quotes by CoinMarketCap ID instead of symbol. This option is identical to convert outside of ID format. Ex: convert_id=1,2781 would replace convert=BTC,USD in your query. This parameter cannot be used when convert is used.</param>
        /// <param name="aux">Specify a comma-separated list of supplemental data fields to return. Pass "price, volume, market_cap, quote_timestamp, search_interval" to include all auxiliary fields.</param>
        /// <returns></returns>
        public ApiResponse<CryptocurrencyHistoricalData> QuotesHistoricalBySymbol(
           string symbol, DateTime? time_start = null, DateTime? time_end = null,
           int? count = null, string interval = null, string convert = null,
           string convertId = null, string aux = null)
        {
            return QuotesHistorical(null, symbol, time_start, time_end, count, interval, convert, convertId, aux);
        }

        /// <summary>
        /// Returns an interval of historic market quotes for any cryptocurrency based on time and interval parameters.
        /// <remarks>See https://coinmarketcap.com/api/documentation/v1/#operation/getV1CryptocurrencyQuotesHistorical </remarks>
        /// </summary>
        /// <param name="id">One or more comma-separated cryptocurrency CoinMarketCap IDs. Example: 1,2</param>
        /// <param name="symbol"></param>
        /// <param name="time_start">Timestamp(Unix or ISO 8601) to start returning quotes for. Optional, if not passed, returns quotes calculated in reverse from "time_end".</param>
        /// <param name="time_end">Timestamp (Unix or ISO 8601) to stop returning quotes for (inclusive). Optional, if not passed, defaults to the current time. If no "time_start" is passed, we return quotes in reverse order starting from this time.</param>
        /// <param name="count">The number of interval periods to return results for. Optional, required if both "time_start" and "time_end" aren't supplied. The default is 10 items.</param>
        /// <param name="interval">Interval of time to return data points for. If null, defaults to "5m".</param>
        /// <param name="convert">By default market quotes are returned in USD. Optionally calculate market quotes in up to 3 other fiat currencies or cryptocurrencies.</param>
        /// <param name="convertId">Optionally calculate market quotes by CoinMarketCap ID instead of symbol. This option is identical to convert outside of ID format. Ex: convert_id=1,2781 would replace convert=BTC,USD in your query. This parameter cannot be used when convert is used.</param>
        /// <param name="aux">Specify a comma-separated list of supplemental data fields to return. Pass "price, volume, market_cap, quote_timestamp, search_interval" to include all auxiliary fields.</param>
        /// <returns>Results of your query returned as an object map.</returns>
        public ApiResponse<CryptocurrencyHistoricalData> QuotesHistorical(
            string id = null, string symbol = null, DateTime? time_start = null,
            DateTime? time_end = null, int? count = null, string interval = null, string convert = null,
            string convertId = null, string aux = null)

        {
            if (string.IsNullOrWhiteSpace(id) &&
                string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException($"Must specify one of: {nameof(id)}, or {nameof(symbol)}",
                    nameof(id));
            }

            return ApiRequest<ApiResponse<CryptocurrencyHistoricalData>>("cryptocurrency/quotes/historical",
                new Dictionary<string, string>
                {
                    ["id"] = id,
                    ["symbol"] = symbol,
                    ["time_start"] = time_start.HasValue ? time_start.Value.ToLongDateString() : string.Empty,
                    ["time_end"] = time_end.HasValue ? time_end.Value.ToLongDateString() : string.Empty,
                    ["count"] = count?.ToString(),
                    ["interval"] = interval,
                    ["convert"] = convert,
                    ["convert_id"] = convertId,
                    ["aux"] = aux
                });

        }
        #endregion Endpoint: /v1/cryptopcurrency/quotes/historical
    }
}
