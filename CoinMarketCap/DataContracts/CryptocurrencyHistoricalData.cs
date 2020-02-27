using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CoinMarketCap.DataContracts
{
    [DataContract]
    public class CryptocurrencyHistoricalData
    {
        /// <summary>
        /// The CoinMarketCap cryptocurrency ID.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// The cryptocurrency name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The cryptocurrency symbol.
        /// </summary>
        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// An array of quotes for each interval for this cryptocurrency.
        /// </summary>
        [DataMember(Name = "quotes")]
        public List<HistoricalQuote> Quotes { get; set; }

    }

    /// <summary>
    /// An array of quotes for each interval for a specified cryptocurrency.
    /// </summary>
    [DataContract]
    public class HistoricalQuote
    {
        /// <summary>
        /// Timestamp of when this historical quote was recorded.
        /// </summary>
        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// The interval timestamp for the search period that this historical quote was located against.
        /// </summary>
        [DataMember(Name = "search_interval", EmitDefaultValue = false)]
        public string SearchInterval { get; set; }

        /// <summary>
        /// A map of market details for the specified quote in different currency conversions. The default map included is USD.
        /// </summary>
        [DataMember(Name = "quote")]
        public Dictionary<string, HistoricalQuoteMarketDetails> Quote { get; set; }
    }

    /// <summary>
    /// The market details for the current interval and currency conversion option.The map key being the currency symbol.
    /// </summary>
    [DataContract]
    public class HistoricalQuoteMarketDetails
    {
        /// <summary>
        /// Price at this interval quote.
        /// </summary>
        [DataMember(Name = "price")]
        public double Price { get; set; }

        /// <summary>
        /// Aggregate 24 hour adjusted volume for all market pairs tracked for this cryptocurrency at the current historical interval.
        /// </summary>
        [DataMember(Name = "volume_24h")]
        public long Volume24H { get; set; }

        /// <summary>
        /// Aggregate 24 hour adjusted volume for all market pairs tracked for this cryptocurrency at the current historical interval.
        /// </summary>
        [DataMember(Name = "market_cap")]
        public double MarketCap { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of when the conversion currency's current value was referenced for this conversion.
        /// </summary>
        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

    }
}
