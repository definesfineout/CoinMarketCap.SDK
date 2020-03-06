using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CoinMarketCap.DataContracts
{
    /// <summary>
    /// A cryptocurrency object.
    /// </summary>
    [DataContract]
    public class CryptocurrencyPricePerformanceStats
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
        /// The web URL friendly shorthand version of this cryptocurrency name.
        /// </summary>
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of the last time this cryptocurrency's market data was updated.
        /// </summary>
        [DataMember(Name = "last_updated")]
        public string LastUpdated { get; set; }

        /// <summary>
        /// An object map of time periods by period requested.
        /// </summary>
        [DataMember(Name = "periods")]
        public Dictionary<string, TimePeriods> Periods { get; set; }
    }

    /// <summary>
    /// Quotes for a specified time period for a cryptocurrency
    /// </summary>
    [DataContract]
    public class TimePeriods
    {
        /// <summary>
        /// Timestamp (ISO 8601) of the start of this time period. Please note that this is a rolling period back from current time
        /// for time periods outside of <value>yesterday</value>.
        /// </summary>
        [DataMember(Name = "open_timestamp")]
        public string OpenTimestamp { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of when this cryptocurrency achieved it's highest USD price during the requested time period. 
        /// Note: The <value>yesterday</value> period currently doesn't support this field and will return null.
        /// </summary>
        [DataMember(Name = "high_timestamp")]
        public string HighTimestamp { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of when this cryptocurrency achieved it's lowest USD price during the requested time period. 
        /// Note: The <value>yesterday</value> period currently doesn't support this field and will return null.
        /// </summary>
        [DataMember(Name = "low_timestamp")]
        public string LowTimestamp { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of the end of this time period. Please note that this is a rolling period back from current time
        /// for time periods outside of <value>yesterday</value>.
        /// </summary>
        [DataMember(Name = "close_timestamp")]
        public string CloseTimestamp { get; set; }

        /// <summary>
        /// An object map of time period quotes for each convert option requested. The default map included is <value>USD</value>.
        /// </summary>
        [DataMember(Name = "quote")]
        public Dictionary<string, TimePeriodQuote> Quote { get; set; }
    }

    /// <summary>
    /// A time period quote in the currency conversion option.
    /// </summary>
    [DataContract]
    public class TimePeriodQuote
    {
        /// <summary>
        /// Cryptocurrency price at the start of the requested time period historically converted into units of the convert
        /// currency.
        /// </summary>
        [DataMember(Name = "open")]
        public double Open { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of the closest convert currency reference price used during <value>open</value> price conversion.
        /// </summary>
        [DataMember(Name = "open_timestamp")]
        public string OpenTimestamp { get; set; }

        /// <summary>
        /// Highest USD price achieved within the requested time period historically converted into units of the convert currency.
        /// </summary>
        [DataMember(Name = "high")]
        public double High { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of the closest convert currency reference price used during <value>high</value> price conversion.
        /// For <value>yesterday</value> UTC close will be used.
        /// </summary>
        [DataMember(Name = "high_timestamp")]
        public string HighTimestamp { get; set; }

        /// <summary>
        /// Lowest USD price achieved within the requested time period historically converted into units of the convert currency.
        /// </summary>
        [DataMember(Name = "low")]
        public double Low { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of the closest convert currency reference price used during <value>low</value> price conversion.
        /// For <value>yesterday</value> UTC close will be used.
        /// </summary>
        [DataMember(Name = "low_timestamp")]
        public string LowTimestamp { get; set; }

        /// <summary>
        /// Cryptocurrency price at the end of the requested time period historically converted into units of the convert currency.
        /// </summary>
        [DataMember(Name = "close")]
        public double Close { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of the closest convert currency reference price used during <value>close</value> price conversion.
        /// </summary>
        [DataMember(Name = "close_timestamp")]
        public string CloseTimestamp { get; set; }

        /// <summary>
        /// The approximate percentage change (ROI) if purchased at the start of the time period. This is the time of launch or
        /// earliest known price for the <value>all_time</value> period. This value includes historical change in market rate for
        /// the specified convert currency.
        /// </summary>
        [DataMember(Name = "percent_change")]
        public double PercentChange { get; set; }

        /// <summary>
        /// The actual price change between the start of the time period and end. This is the time of launch or earliest known price
        /// for the <value>all_time</value> period. This value includes historical change in market rate for the specified convert
        /// currency.
        /// </summary>
        [DataMember(Name = "price_change")]
        public double PriceChange { get; set; }
    }
}
