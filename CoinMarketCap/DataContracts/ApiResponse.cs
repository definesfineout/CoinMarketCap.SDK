using System.Runtime.Serialization;

namespace CoinMarketCap.DataContracts
{
    [DataContract]
    public class ApiResponse<T>
    {
        /// <summary>
        /// <see cref="ApiResponseStatus"/> including details about the status of this request.
        /// </summary>
        [DataMember(Name="status")]
        public ApiResponseStatus Status { get; set; }

        /// <summary>
        /// The results of the requested query, if successful.
        /// </summary>
        [DataMember(Name="data")]
        public T Data { get; set; }
    }

    /// <summary>
    /// Standardized status object for API calls.
    /// <remarks>See https://coinmarketcap.com/api/documentation/v1/#section/Standards-and-Conventions </remarks>
    /// </summary>
    [DataContract]
    public class ApiResponseStatus
    {
        /// <summary>
        /// The current time on the server when the call was executed.
        /// timestamp
        /// </summary>
        [DataMember(Name="timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// Code for error encountered, if any.
        /// timestamp
        /// </summary>
        [DataMember(Name = "error_code")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// Message for error encountered, if any.
        /// timestamp
        /// </summary>
        [DataMember(Name = "error_message")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The number of milliseconds it took to process the request.
        /// timestamp
        /// </summary>
        [DataMember(Name = "elapsed")]
        public int Elapsed { get; set; }

        /// <summary>
        /// The number of API call credits this call utilized.
        /// timestamp
        /// </summary>
        [DataMember(Name = "credit_count")]
        public int CreditCount { get; set; }
    }
}
