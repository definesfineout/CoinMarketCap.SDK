using CoinMarketCap.DataContracts;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CoinMarketCap.Client
{
    // ReSharper disable once UnusedMember.Global
    public class CryptocurrencyClient : ApiClientBase
    {
        //TODO: ApiClientBase with initialization and shared members

        #region Endpoint: /v1/cryptocurrency/map - CoinMarketCap ID map

        //TODO: Cryptocurrency Endpoint: Map

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

    }
}
