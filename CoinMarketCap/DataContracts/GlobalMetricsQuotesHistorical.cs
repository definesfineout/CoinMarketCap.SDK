using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CoinMarketCap.DataContracts
{
    [DataContract]
    public class GlobalMetricsQuotesHistorical
    {
        [DataMember(Name = "quotes")]
        public List<HistoricalMarketQuote> Quotes { get; set; }
    }

    /// <summary>
    /// Aggregate market quote for a specified interval.
    /// </summary>
    [DataContract]
    public class HistoricalMarketQuote
    {
        /// <summary>
        /// Timestamp (ISO 8601) of when this historical quote was recorded.
        /// </summary>
        [DataMember(Name = "timestamp")]
        public string TimeStamp { get; set; }

        /// <summary>
        /// The interval timestamp for the search period that this historical quote was located against.
        /// <remark>
        /// This field is only returned if requested through the <value>aux</value> request parameter.
        /// </remark>
        /// </summary>
        [DataMember(Name = "search_interval", EmitDefaultValue = false)]
        public string SearchInterval { get; set; }

        /// <summary>
        /// Percent of BTC market dominance by marketcap at this interval.
        /// </summary>
        [DataMember(Name = "btc_dominance")]
        public double BtcDominance { get; set; }

        /// <summary>
        /// Number of active cryptocurrencies tracked by CoinMarketCap at the given point in time. This includes all
        /// cryptocurrencies with a <see cref="CryptocurrencyIdMapping.Status"/> of <value>active</value> or
        /// <value>untracked</value> as returned from the <see cref="CryptocurrencyIdMapping"/> call.
        /// <remark>
        /// This field is only available after 2019-05-10 and will return <value>null</value> prior to that time.
        /// </remark>
        /// </summary>
        [DataMember(Name = "active_cryptocurrencies")]
        public int ActiveCryptocurrencies { get; set; }

        /// <summary>
        /// Number of active exchanges tracked by CoinMarketCap at the given point in time. This includes all exchanges
        /// with a <see cref="listingStatus" /> of <value>active</value> or <value>untracked</value> as
        /// returned by the <see cref="ExchangeMap"/> call.
        /// <remark>
        /// This field is only available after 2019-06-18 and will return <value>null</value> prior to that time.
        /// </remark>
        /// </summary>
        [DataMember(Name = "active_exchanges")]
        public int ActiveExchanges { get; set; }

        /// <summary>
        /// Number of active market pairs tracked by CoinMarketCap across all exchanges at the given point in time.
        /// <remark>
        /// This field is only available after 2019-05-10 and will return <value>null</value> prior to that time.
        /// </remark>
        /// </summary>
        [DataMember(Name = "active_market_pairs")]
        public int ActiveMarketPairs { get; set; }

        /// <summary>
        ///An object containing market data for this interval by currency option.The default currency mapped is
        ///<value>USD</value>.
        /// </summary>
        [DataMember(Name = "quote")]
        public Dictionary<string, MarketData> MarketDataQuote { get; set; }

    }

    /// <summary>
    /// The market details for the current interval and currency conversion option.
    /// </summary>
    [DataContract]
    public class MarketData
    {
        /// <summary>
        /// The sum of all individual cryptocurrency market capitalizations at the given point in time, historically
        /// converted into units of the requested currency.
        /// </summary>
        [DataMember(Name = "total_market_cap")]
        public double TotalMarketCap { get; set; }

        /// <summary>
        /// The sum of rolling 24 hour adjusted volume (as outlined here:
        /// https://support.coinmarketcap.com/hc/en-us/articles/360034116491-Market-Data-Cryptoasset-Rank) for all
        /// cryptocurrencies at the given point in time, historically converted into units of the requested currency.
        /// </summary>
        [DataMember(Name = "total_volume_24h")]
        public double TotalVolume24H { get; set; }

        /// <summary>
        /// The sum of rolling 24 hour reported volume for all cryptocurrencies at the given point in time, historically
        /// converted into units of the requested currency.
        /// <remark>
        /// This field is only available after 2019-05-10 and will return <value>null</value> prior to that time.
        /// </remark>
        /// </summary>
        [DataMember(Name = "total_volume_24h_reported")]
        public double TotalVolume24HReported { get; set; }

        /// <summary>
        /// The sum of rolling 24 hour adjusted volume (as outlined here: 
        /// https://support.coinmarketcap.com/hc/en-us/articles/360034116491-Market-Data-Cryptoasset-Rank) for all
        /// cryptocurrencies excluding Bitcoin at the given point in time, historically converted into units of the
        /// requested currency.
        /// </summary>
        [DataMember(Name = "altcoin_market_cap")]
        public double AltcoinMarketCap { get; set; }

        /// <summary>
        /// The sum of all individual cryptocurrency market capitalizations excluding Bitcoin at the given point in time,
        /// historically converted into units of the requested currency.
        /// </summary>
        [DataMember(Name = "altcoin_volume_24h")]
        public double AltcoinVolume24H { get; set; }

        /// <summary>
        /// The sum of rolling 24 hour reported volume for all cryptocurrencies excluding Bitcoin at the given point in
        /// time, historically converted into units of the requested currency.
        /// <remark>
        /// This field is only available after 2019-05-10 and will return <value>null</value> prior to that time.
        /// </remark>
        /// </summary>
        [DataMember(Name = "altcoin_volume_24h_reported")]
        public double AltcoinVolume24HReported { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of when the conversion currency's current value was referenced for this conversion.
        /// </summary>
        [DataMember(Name = "timestamp")]
        public string TimeStamp { get; set; }
    }

   
}
