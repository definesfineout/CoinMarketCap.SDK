using System.Collections.Generic;
using System.Runtime.Serialization;
using CoinMarketCap.Client;

namespace CoinMarketCap.DataContracts
{
    /// <summary>
    /// OHLCV (Open, High, Low, Close, Volume) market values for a cryptocurrency.
    /// </summary>
    [DataContract]
    public class CryptocurrencyOhlcvQuotes
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
        /// Timestamp (ISO 8601) of the latest market value record included to generate the latest active
        /// day OHLCV values.
        /// </summary>
        [DataMember(Name = "last_updated")]
        public string LastUpdated { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of the start of this OHLCV period.
        /// </summary>
        [DataMember(Name = "time_open")]
        public string TimeOpen { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of the high of this OHLCV period.
        /// </summary>
        [DataMember(Name = "time_high")]
        public string TimeHigh { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of the low of this OHLCV period.
        /// </summary>
        [DataMember(Name = "time_low")]
        public string TimeLow { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of the end of this OHLCV period.
        /// When returned by <see cref="CryptocurrencyClient.OhlcvLatest"/>, always <value>null</value> as
        /// the current day is incomplete.
        /// See <see cref="LastUpdated"/> for the last UTC time included in the current OHLCV calculation
        /// </summary>
        [DataMember(Name = "time_close")]
        public string TimeClose { get; set; }

        /// <summary>
        /// A  map of market quotes in different currency conversions. The default map included is USD.
        /// </summary>
        [DataMember(Name="quote")]
        public Dictionary<string, OhlcvQuote> Quote { get; set; }
    }

    /// <summary>
    ///  A market quote in one or more currency conversion option.
    /// </summary>
    [DataContract]
    public class OhlcvQuote
    {
        /// <summary>
        /// Price from first datapoint of today in UTC time for the convert option requested.
        /// </summary>
        [DataMember(Name="open")]
        public double Open { get; set; }

        /// <summary>
        /// Highest price so far today in UTC time for the convert option requested.
        /// </summary>
        [DataMember(Name="high")]
        public double High { get; set; }

        /// <summary>
        /// Lowest price today in UTC time for the convert option requested.
        /// </summary>
        [DataMember(Name="low")]
        public double Low { get; set; }

        /// <summary>
        /// Latest price today in UTC time for the convert option requested. This is not the final price
        /// during close as the current day period is not over.
        /// </summary>
        [DataMember(Name="close")]
        public double Close { get; set; }

        /// <summary>
        /// Aggregate 24 hour adjusted volume for the convert option requested. Please note, this is a
        /// rolling 24 hours back from the current time.
        /// </summary>
        [DataMember(Name="volume")]
        public double Volume { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of when the conversion currency's current value was last updated when
        /// referenced for this conversion.
        /// </summary>
        [DataMember(Name="last_updated")]
        public string LastUpdated { get; set; }
    }

}
