using System.Collections.Generic;

namespace CoinMarketCap.DataContracts
{
    public class ApiResponseMap<T> : ApiResponse<Dictionary<string, T>>
    { }
}
