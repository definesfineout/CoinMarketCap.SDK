using CoinMarketCap.DataContracts;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net;
using System.Web;

namespace CoinMarketCap.Client
{
    public class CryptocurrencyClient
    {
        //TODO: Move CoinMarketCap.ApiKey to config
        private const string ApiKey = "a7218d97-eefc-44ea-9404-e3a7025f05f2";
        private const string MetadataDefaultAux = "urls,logo,description,tags,platform,date_added,notice";
        private const string QuotesLatestDefaultAux = "num_market_pairs, cmc_rank, date_added, tags, platform, max_supply, circulating_supply, total_supply";

        #region Endpoint: /v1/cryptocurrency/map - CoinMarketCap ID map

        //TODO: Cryptocurrency Endpoint: Map

        #endregion Endpoint: /v1/cryptocurrency/map - CoinMarketCap ID map

        #region Endpoint: /v1/cryptocurrency/info - Metadata

        public ApiResponseMap<CryptocurrencyMetadata> MetadataById(
            string id, string aux = MetadataDefaultAux)
        {
            return Metadata(id, null, null, aux);
        }
        public ApiResponseMap<CryptocurrencyMetadata> MetadataBySlug(
            string slug, string aux = MetadataDefaultAux)
        {
            return Metadata(null, slug, null, aux);
        }
        public ApiResponseMap<CryptocurrencyMetadata> MetadataBySymbol(
            string symbol, string aux = MetadataDefaultAux)
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
            string id = null, string slug = null, string symbol = null, string aux = MetadataDefaultAux)
        {
            if (string.IsNullOrWhiteSpace(id) &&
                string.IsNullOrWhiteSpace(slug) &&
                string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException($"Must specify one of: {nameof(id)}, {nameof(slug)}, or {nameof(symbol)}",
                    nameof(id));
            }

            var url = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/info");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            if (!string.IsNullOrWhiteSpace(id))
            {
                queryString["id"] = id;
            }
            if (!string.IsNullOrWhiteSpace(slug))
            {
                queryString["slug"] = slug;
            }
            if (!string.IsNullOrWhiteSpace(symbol))
            {
                queryString["symbol"] = symbol;
            }
            if (!string.IsNullOrWhiteSpace(aux) &&
                !aux.Equals(MetadataDefaultAux))
            {
                queryString["aux"] = aux;
            }

            url.Query = queryString.ToString();

            string responseJson;
            using (var client = new WebClient())
            {
                client.Headers.Add("X-CMC_PRO_API_KEY", ApiKey);
                client.Headers.Add("Accepts", "application/json");
                responseJson = client.DownloadString(url.ToString());
            }

            return JsonConvert.DeserializeObject<ApiResponseMap<CryptocurrencyMetadata>>(responseJson);
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
            var url = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);

            if (start.HasValue)
            {
                queryString["start"] = start.Value.ToString();
            }
            if (limit.HasValue)
            {
                queryString["limit"] = limit.Value.ToString();
            }
            if (priceMin.HasValue)
            {
                queryString["price_min"] = priceMin.Value.ToString();
            }
            if (priceMax.HasValue)
            {
                queryString["price_max"] = priceMax.Value.ToString();
            }
            if (marketCapMin.HasValue)
            {
                queryString["market_cap_min"] = marketCapMin.Value.ToString();
            }
            if (marketCapMax.HasValue)
            {
                queryString["market_cap_max"] = marketCapMax.Value.ToString();
            }
            if (volume24HMin.HasValue)
            {
                queryString["volume_24h_min"] = volume24HMin.Value.ToString();
            }
            if (volume24HMax.HasValue)
            {
                queryString["volume_24h_max"] = volume24HMax.Value.ToString();
            }
            if (circulatingSupplyMin.HasValue)
            {
                queryString["circulating_supply_min"] = circulatingSupplyMin.Value.ToString();
            }
            if (circulatingSupplyMax.HasValue)
            {
                queryString["circulating_supply_max"] = circulatingSupplyMax.Value.ToString();
            }
            if (percentChange24HMin.HasValue)
            {
                queryString["percent_change_24h_min"] = percentChange24HMin.Value.ToString(CultureInfo.InvariantCulture);
            }
            if (percentChange24HMax.HasValue)
            {
                queryString["percent_change_24h_max"] = percentChange24HMax.Value.ToString(CultureInfo.InvariantCulture);
            }
            if (!string.IsNullOrWhiteSpace(convert))
            {
                queryString["convert"] = convert;
            }
            if (!string.IsNullOrWhiteSpace(convertId))
            {
                queryString["convert_id"] = convertId;
            }
            if (!string.IsNullOrWhiteSpace(sort))
            {
                queryString["sort"] = sort;
            }
            if (!string.IsNullOrWhiteSpace(sortDir))
            {
                queryString["sort_dir"] = sortDir;
            }
            if (!string.IsNullOrWhiteSpace(cryptocurrencyType))
            {
                queryString["cryptocurrency_type"] = cryptocurrencyType;
            }

            if (!string.IsNullOrWhiteSpace(aux) &&
                !aux.Equals(QuotesLatestDefaultAux))
            {
                queryString["aux"] = aux;
            }

            url.Query = queryString.ToString();

            string responseJson;
            using (var client = new WebClient())
            {
                client.Headers.Add("X-CMC_PRO_API_KEY", ApiKey);
                client.Headers.Add("Accepts", "application/json");
                responseJson = client.DownloadString(url.ToString());
            }

            return JsonConvert.DeserializeObject<ApiResponseList<Cryptocurrency>>(responseJson);
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
            string aux = QuotesLatestDefaultAux, bool skipInvalid = false)
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
            string aux = QuotesLatestDefaultAux, bool skipInvalid = false)
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
            string aux = QuotesLatestDefaultAux, bool skipInvalid = false)
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
            string convert = null, string convertId = null, string aux = QuotesLatestDefaultAux,
            bool skipInvalid = false)
        {
            if (string.IsNullOrWhiteSpace(id) &&
                string.IsNullOrWhiteSpace(slug) &&
                string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException($"Must specify one of: {nameof(id)}, {nameof(slug)}, or {nameof(symbol)}",
                    nameof(id));
            }

            var url = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            if (!string.IsNullOrWhiteSpace(id))
            {
                queryString["id"] = id;
            }
            if (!string.IsNullOrWhiteSpace(slug))
            {
                queryString["slug"] = slug;
            }
            if (!string.IsNullOrWhiteSpace(symbol))
            {
                queryString["symbol"] = symbol;
            }
            if (!string.IsNullOrWhiteSpace(convert))
            {
                queryString["convert"] = convert;
            }
            if (!string.IsNullOrWhiteSpace(convertId))
            {
                queryString["convert_id"] = convertId;
            }
            if (!string.IsNullOrWhiteSpace(aux) &&
                !aux.Equals(QuotesLatestDefaultAux))
            {
                queryString["aux"] = aux;
            }
            if (skipInvalid)
            {
                queryString["skip_invalid"] = "true";
            }

            url.Query = queryString.ToString();

            string responseJson;
            using (var client = new WebClient())
            {
                client.Headers.Add("X-CMC_PRO_API_KEY", ApiKey);
                client.Headers.Add("Accepts", "application/json");
                responseJson = client.DownloadString(url.ToString());
            }

            return JsonConvert.DeserializeObject<ApiResponseMap<Cryptocurrency>>(responseJson);
        }

        #endregion Endpoint: /v1/cryptocurrency/quotes/latest - Latest quotes

    }
}
