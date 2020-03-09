using CoinMarketCap.DataContracts;
using CoinMarketCap.Enumerations;
using System;
using System.Collections.Generic;

namespace CoinMarketCap.Client
{
    public class FiatClient : ApiClientBase
    {
        public FiatClient(string apiKey, bool sandbox = false)
            : base(apiKey, sandbox)
        { }

        #region Endpoint: /v1/fiat/map - CoinMarketCap ID map

        /// <summary>
        /// Returns a mapping of all supported fiat currencies to unique CoinMarketCap IDs.
        /// <remarks>See https://coinmarketcap.com/api/documentation/v1/#operation/getV1FiatMap</remarks>
        /// </summary>
        /// <param name="start">
        /// Optionally offset the start (1-based index) of the paginated list of items to return.
        ///     Valid values: <value>&gt;= 1</value>
        ///     Default: <value>1</value>
        /// </param>
        /// <param name="limit">
        /// Optionally specify the number of results to return. Use this parameter and the "start" parameter
        /// to determine your own pagination size.
        ///     Valid values: <value>[ 1 .. 5000 ]</value>
        /// </param>
        /// <param name="sort">
        /// <see cref="eSortFiatMap"/> specifying What field to sort the list by.
        ///     Default: <see cref="eSortFiatMap.Id"/>
        /// </param>
        /// <param name="includeMetals">
        /// Pass <value>true</value> to include precious metals.
        /// Default: <value>false</value>
        /// </param>
        /// <returns></returns>
        public ApiResponseList<FiatIdMapping> Map(int? start = null, int? limit = null, eSortFiatMap? sort = null,
            bool? includeMetals = null)
        {
            if (start.HasValue && start < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(start), start.Value,
                    $"{nameof(start)} must be greater than or equal to 1.");
            }

            if (limit.HasValue && (limit < 1 || limit > 5000))
            {
                throw new ArgumentOutOfRangeException(nameof(limit), limit.Value,
                    $"{nameof(limit)} must be between 1 and 5000.");
            }

            return ApiRequest<ApiResponseList<FiatIdMapping>>("fiat/map",
                new Dictionary<string, string>
                {
                    ["start"] = start?.ToString(),
                    ["limit"] = limit?.ToString(),
                    ["sort"] = sort?.GetDescription(),
                    ["include_metals"] = includeMetals.HasValue && includeMetals.Value ? "true" : string.Empty
                });
        }

        #endregion Endpoint: /v1/fiat/map - CoinMarketCap ID map
    }
}
