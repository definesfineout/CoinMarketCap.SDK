using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CoinMarketCap.DataContracts
{
    [DataContract]
    public class Cryptocurrency
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
        /// The cryptocurrency's historic CoinMarketCap rank at the end of the requested UTC day.
        /// </summary>
        [DataMember(Name = "cmc_rank")]
        public int CmcRank { get; set; }

        /// <summary>
        /// The number of active trading pairs available for this cryptocurrency across supported exchanges.
        /// </summary>
        [DataMember(Name = "num_market_pairs", EmitDefaultValue = false)]
        public int? NumMarketPairs { get; set; }

        /// <summary>
        /// The approximate number of coins circulating for this cryptocurrency at the end of the requested UTC day.
        /// </summary>
        [DataMember(Name = "circulating_supply")]
        public long? CirculatingSupply { get; set; }

        /// <summary>
        /// The approximate total amount of coins in existence right now (minus any coins that have been verifiably burned) at the end of the requested UTC day.
        /// </summary>
        [DataMember(Name = "total_supply")]
        public long? TotalSupply { get; set; }

        /// <summary>
        /// The market cap by total supply.
        /// <remarks>This field is only returned if requested through the aux request parameter.</remarks>
        /// </summary>
        [DataMember(Name = "market_cap_by_total_supply",EmitDefaultValue = false)]
        public long? MarketCapByTotalSupply { get; set; }

        /// <summary>
        /// The expected maximum limit of coins ever to be available for this cryptocurrency.
        /// </summary>
        [DataMember(Name = "max_supply")]
        public long? MaxSupply { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of when this cryptocurrency's market data was referenced for this UTC date snapshot. This is always the last update available during the UTC date requested.
        /// </summary>
        [DataMember(Name = "last_updated")]
        public string LastUpdated { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of when this cryptocurrency was added to CoinMarketCap.
        /// </summary>
        [DataMember(Name = "date_added")]
        public string DateAdded { get; set; }

        /// <summary>
        /// Array of tags associated with this cryptocurrency. Currently only a mineable tag will be returned if the cryptocurrency is mineable. Additional tags will be returned in the future.
        /// </summary>
        [DataMember(Name = "tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Metadata about the parent cryptocurrency platform this cryptocurrency belongs to if it is a token, otherwise null.
        /// </summary>
        [DataMember(Name = "platform")]
        public ParentPlatform Platform { get; set; }

        /// <summary>
        /// A market quote in the currency conversion option.
        /// </summary>
        [DataMember(Name = "quote")]
        public Dictionary<string, Quote> Quote { get; set; }
    }

    /// <summary>
    /// Metadata about the parent cryptocurrency platform a cryptocurrency belongs to.
    /// </summary>
    [DataContract]
    public class ParentPlatform
    {
        /// <summary>
        /// The unique CoinMarketCap ID for the parent platform cryptocurrency.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the parent platform cryptocurrency.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The ticker symbol for the parent platform cryptocurrency.
        /// </summary>
        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// The web URL friendly shorthand version of the parent platform cryptocurrency name.
        /// </summary>
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        /// <summary>
        /// The token address on the parent platform cryptocurrency.
        /// </summary>
        [DataMember(Name = "token_address")]
        public string TokenAddress { get; set; }
    }

    /// <summary>
    /// Market quote for a cryptocurrency in a specific currency conversion option.
    /// </summary>
    [DataContract]
    public class Quote
    {
        /// <summary>
        /// Price in the specified currency at the end of the requested UTC day.
        /// </summary>
        [DataMember(Name = "price")]
        public double Price { get; set; }

        /// <summary>
        /// 24 hour adjusted volume in the specified currency at the end of the requested UTC day.
        /// </summary>
        [DataMember(Name = "volume_24h")]
        public double Volume24H { get; set; }

        /// <summary>
        /// Market cap in the specified currency at the end of the requested UTC day.
        /// </summary>
        [DataMember(Name = "market_cap")]
        public double MarketCap { get; set; }

        /// <summary>
        /// 1 hour change in the specified currency at the end of the requested UTC day.
        /// </summary>
        [DataMember(Name = "percent_change_1h")]
        public double PercentChange1H { get; set; }

        /// <summary>
        /// 24 hour change in the specified currency at the end of the requested UTC day.
        /// </summary>
        [DataMember(Name = "percent_change_24h")]
        public double PrPercentChange24H { get; set; }

        /// <summary>
        /// 7 day change in the specified currency at the end of the requested UTC day.
        /// </summary>
        [DataMember(Name = "percent_change_7d")]
        public double PrPercentChange7D { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of when the conversion currency's current value was referenced.
        /// </summary>
        [DataMember(Name = "last_updated")]
        public string LastUpdated { get; set; }
    }
}
