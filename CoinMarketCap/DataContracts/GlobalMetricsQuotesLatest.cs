using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CoinMarketCap.DataContracts
{
    [DataContract]
    public class GlobalMetricsQuotesLatest
    {
        /// <summary>
        /// Bitcoin's market dominance percentage by market cap.
        /// </summary>
        [DataMember(Name = "btc_dominance")]
        public double BtcDominance { get; set; }

        /// <summary>
        /// Ethereum's market dominance percentage by market cap.
        /// </summary>
        [DataMember(Name = "eth_dominance")]
        public double EthDominance { get; set; }

        /// <summary>
        /// Number of active cryptocurrencies tracked by CoinMarketCap. This includes all cryptocurrencies with a 
        /// <see cref="listingStatus"/> of <value>active</value> or <value>listed</value> as returned from our 
        /// <see cref="CryptocurrencyIdMapping" /> call.
        /// </summary>
        [DataMember(Name = "active_cryptocurrencies")]
        public double ActiveCryptocurrencies { get; set; }

        /// <summary>
        /// Number of active market pairs tracked by CoinMarketCap across all exchanges.
        /// </summary>
        [DataMember(Name = "active_market_pairs")]
        public double ActiveMarketPairs { get; set; }

        /// <summary>
        /// Number of active exchanges tracked by CoinMarketCap. This includes all exchanges with a 
        /// <see cref="listingStatus"/> of <value>active</value> or <value>listed</value> as returned by the 
        /// <see cref="ExchangeMap"/> /exchange/map call.
        /// </summary>
        [DataMember(Name= "active_exchanges")]
        public double ActiveExchanges { get; set; }

        /// <summary>
        /// Timestamp of when this record was last updated.
        /// </summary>
        [DataMember(Name = "last_updated")]
        public string LastUpdated { get; set; }

        /// <summary>
        /// A map of market quotes in different currency conversions.The default map included is <value>USD</value>.
        /// </summary>
        [DataMember(Name = "quote")]
        public Dictionary<string, MarketQuote> MarketQuotes { get; set; }
    }

    /// <summary>
    /// A market quote in the specified currency conversion.
    /// </summary>
    [DataContract]
    public class MarketQuote
    {
        /// <summary>
        /// The sum of all individual cryptocurrency market capitalizations in the requested currency.
        /// </summary>
        [DataMember(Name = "total_market_cap")]
        public double TotalMarketCap { get; set; }

        /// <summary>
        /// The sum of rolling 24 hour adjusted volume as seen here: 
        /// https://support.coinmarketcap.com/hc/en-us/articles/360034116491-Market-Data-Cryptoasset-Rank 
        /// for all cryptocurrencies in the requested currency.
        /// </summary>
        [DataMember(Name = "total_volume_24h")]
        public double TotalVolume24H { get; set; }

        /// <summary>
        /// The sum of rolling 24 hour reported volume for all cryptocurrencies in the requested currency.
        /// </summary>
        [DataMember(Name = "total_volume_24h_reported")]
        public double TotalVolume24HReported { get; set; }

        /// <summary>
        /// The sum of rolling 24 hour adjusted volume as seen here:
        /// https://support.coinmarketcap.com/hc/en-us/articles/360034116491-Market-Data-Cryptoasset-Rank
        /// for all cryptocurrencies excluding Bitcoin in the requested currency.
        /// </summary>
        [DataMember(Name = "altcoin_volume_24h")]
        public double AltcoinVolume24H { get; set; }

        /// <summary>
        /// The sum of rolling 24 hour reported volume for all cryptocurrencies excluding Bitcoin in the requested currency.
        /// </summary>
        [DataMember(Name = "altcoin_volume_24h_reported")]
        public double AltcoinVolume24HReported { get; set; }

        /// <summary>
        /// The sum of all individual cryptocurrency market capitalizations excluding Bitcoin in the requested currency.
        /// </summary>
        [DataMember(Name = "altcoin_market_cap")]
        public double AltcoinMarketCap { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of when the conversion currency's current value was referenced.
        /// </summary>
        [DataMember(Name = "last_updated")]
        public string LastUpdated { get; set; }
    }
}
