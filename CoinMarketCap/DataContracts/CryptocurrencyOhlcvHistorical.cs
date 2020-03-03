using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CoinMarketCap.DataContracts
{
    public class CryptocurrencyOhlcvHistorical
    {
        /// <summary>
        /// The unique CoinMarketCap ID for this cryptocurrency.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of this cryptocurrency.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The ticker symbol for this cryptocurrency.
        /// </summary>
        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// An array of OHLCV quotes for the supplied interval.
        /// </summary>
        [DataMember(Name = "quotes")]
        public List<OhlcvHistoricalQuotes> Quotes { get; set; }
    }

    /// <summary>
    /// An array of OHLCV quotes for the specified interval.
    /// </summary>
    [DataContract]
    public class OhlcvHistoricalQuotes
    {
        /// <summary>
        /// Timestamp (ISO 8601) of the start of this time series interval.
        /// </summary>
        [DataMember(Name = "time_open")]
        public string TimeOpen { get; set; }

        /// <summary>
        /// imestamp (ISO 8601) of the start of this time series interval.
        /// </summary>
        [DataMember(Name = "time_close")]
        public string TimeClose { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of the high of this time series interval.
        /// <remark>This data member is only returned in the 
        /// https://coinmarketcap.com/api/v1/#operation/getV1CryptocurrencyOhlcvHistorical version.
        /// </remark>
        /// </summary>
        [DataMember(Name = "time_high")]
        public string TimeHigh { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of the low of this time series interval. 
        /// <remark>This data member is only returned in the 
        /// https://coinmarketcap.com/api/v1/#operation/getV1CryptocurrencyOhlcvHistorical version.
        /// </remark>
        /// </summary>
        [DataMember(Name = "time_low")]
        public string TimeLow { get; set; }

        /// <summary>
        ///  A map of market quotes in different currency conversions.The default map included is <value>USD</value>
        /// </summary>
        [DataMember(Name = "quote")]
        public Dictionary<string, OhlcvHistoricalQuote> Quotes { get; set; }

    }

    /// <summary>
    /// A market quote in each currency conversion option.
    /// </summary>
    [DataContract]
    public class OhlcvHistoricalQuote
    {
        /// <summary>
        /// Opening price for time series interval.
        /// </summary>
        [DataMember(Name = "open")]
        public double Open { get; set; }

        /// <summary>
        /// Highest price during this time series interval.
        /// </summary>
        [DataMember(Name = "high")]
        public double High { get; set; }

        /// <summary>
        /// Lowest price during this time series interval.
        /// </summary>
        [DataMember(Name = "low")]
        public double Low { get; set; }

        /// <summary>
        /// Closing price for this time series interval.
        /// </summary>
        [DataMember(Name = "close")]
        public double Close { get; set; }

        /// <summary>
        /// Adjusted volume for this time series interval. Volume is not currently supported for hourly OHLCV intervals.
        /// </summary>
        [DataMember(Name = "volume")]
        public double Volume { get; set; }

        /// <summary>
        /// Market cap by circulating supply for this time series interval.
        /// </summary>
        [DataMember(Name = "market_cap")]
        public double MarketCap { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of when the conversion currency's current value was referenced for this conversion.
        /// </summary>
        [DataMember(Name = "timestamp")]
        public string TimeStamp { get; set; }
    }
}
