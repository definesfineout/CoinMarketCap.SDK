using System.Collections.Generic;
using System.Runtime.Serialization;


namespace CoinMarketCap.DataContracts
{

    [DataContract]
    public class CryptocurrencyMarketPairs
    {
        /// <summary>
        /// The CoinMarketCap ID for this cryptocurrency.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of this cryptocurrency.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The symbol for this cryptocurrency.
        /// </summary>
        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// The number of active market pairs listed for this cryptocurrency. This number is filtered down to only matching markets if a matched parameter is used.
        /// </summary>
        [DataMember(Name = "num_market_pairs")]
        public int Num_Market_Pairs { get; set; }

        /// <summary>
        /// Array of all market pairs for this cryptocurrency.
        /// </summary>
        [DataMember(Name = "market_pairs")]
        public List<MarketPair> MarketPairs { get; set; }
    }

    /// <summary>
    /// Market pair for the specified cryptocurrency.
    /// </summary>
    [DataContract]
    public class MarketPair
    {
        /// <summary>
        /// Exchange details for this market pair.
        /// </summary>
        [DataMember(Name = "exchange")]
        public Exchange Exchange { get; set; }

        /// <summary>
        /// The CoinMarketCap ID for this market pair. This ID can reliably be used to identify this unique market as the ID never changes.
        /// </summary>
        [DataMember(Name = "market_id")]
        public int MarketId { get; set; }

        /// <summary>
        /// The name of this market pair. Example: "BTC/USD"
        /// </summary>
        [DataMember(Name = "market_pair")]
        public string MarketPairName { get; set; }

        /// <summary>
        /// The category of trading this market falls under. "Spot" markets are the most common, but options include "derivatives" and "OTC".
        /// </summary>
        [DataMember(Name = "category")]
        public string Category { get; set; }

        /// <summary>
        /// The fee type the exchange enforces for this market.
        /// </summary>
        [DataMember(Name = "fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        /// The URL to this market's trading page on the exchange if available. If not available the exchange's homepage URL is returned. This field is only returned if requested through the aux request parameter.
        /// </summary>
        [DataMember(Name = "market_url", EmitDefaultValue = false)]
        public string MarketUrl { get; set; }

        /// <summary>
        /// Base currency details object for this market pair.
        /// </summary>
        [DataMember(Name = "market_pair_base")]
        public MarketPairBase MarketPairBase { get; set; }

        /// <summary>
        /// Quote (secondary) currency details object for this market pair.
        /// </summary>
        [DataMember(Name = "market_pair_quote")]
        public MarketPairQuote MarketPairQuote { get; set; }

        ///// <summary>
        ///// One or more market quotes where $key is the conversion currency requested, ex. USD
        ///// </summary>
        //[DataMember(Name = "quote")]
        //public MarketPairQuotesObject Quote { get; set; }

        [DataMember(Name = "quote")]
        public Dictionary<string, MarketPairQuotesObject> Quote { get; set; }

    }

    /// <summary>
    /// Exchange details for the specified market pair.
    /// </summary>
    [DataContract]
    public class Exchange
    {
        /// <summary>
        /// The id of the exchange this market pair is under.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// The slug of the exchange this market pair is under.
        /// </summary>
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        /// <summary>
        /// The name of the exchange this market pair is under.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A Markdown formatted message outlining a condition that is impacting the availability of this exchange's market data or the secure use of the exchange, otherwise null. This may include a maintenance event on the exchange's end or CoinMarketCap's end, an alert about reported issues with withdrawls from this exchange, or another condition that may be impacting this exchange and it's markets. If present, this notice is also displayed in an alert banner at the top of the exchange's page on coinmarketcap.com. This field is only returned if requested through the aux request parameter.
        /// </summary>
        [DataMember(Name = "notice", EmitDefaultValue = false)]
        public string Notice { get; set; }

    }

    /// <summary>
    /// Base currency details for the specified market pair.
    /// </summary>
    [DataContract]
    public class MarketPairBase
    {
        /// <summary>
        /// The CoinMarketCap ID for the base currency in this market pair.
        /// </summary>
        [DataMember(Name = "currency_id")]
        public int CurrencyId { get; set; }

        /// <summary>
        /// The name of this cryptocurrency. This field is only returned if requested through the aux request parameter.
        /// </summary>
        [DataMember(Name = "currency_name", EmitDefaultValue = false)]
        public string CurrencyName { get; set; }

        /// <summary>
        /// The CoinMarketCap identified symbol for the base currency in this market pair.
        /// </summary>
        [DataMember(Name = "currency_symbol")]
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// The web URL friendly shorthand version of this cryptocurrency name. This field is only returned if requested through the aux request parameter.
        /// </summary>
        [DataMember(Name = "currency_slug", EmitDefaultValue = false)]
        public string CurrencySlug { get; set; }

        /// <summary>
        /// The exchange reported symbol for the base currency in this market pair. In most cases this is identical to CoinMarketCap's symbol but it may differ if the exchange uses an outdated or contentious symbol that contrasts with the majority of other markets.
        /// </summary>
        [DataMember(Name = "exchange_symbol")]
        public string ExchangeSymbol { get; set; }

        /// <summary>
        /// The currency type for the base currency in this market pair ("cryptocurrency", "fiat").
        /// </summary>
        [DataMember(Name = "currency_type")]
        public string CurrencyType { get; set; }
    }

    /// <summary>
    /// Quote(secondary) currency details object for the specified market pair.
    /// </summary>
    [DataContract]
    public class MarketPairQuote
    {
        /// <summary>
        /// The CoinMarketCap ID for the quote (secondary) currency in this market pair.
        /// </summary>
        [DataMember(Name = "currency_id")]
        public int CurrencyId { get; set; }

        /// <summary>
        /// The name of this cryptocurrency. This field is only returned if requested through the aux request parameter.
        /// </summary>
        [DataMember(Name = "currency_name", EmitDefaultValue = false)]
        public string CurrencyName { get; set; }

        /// <summary>
        /// The symbol for the quote (secondary) currency in this market pair.
        /// </summary>
        [DataMember(Name = "currency_symbol")]
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// The web URL friendly shorthand version of this cryptocurrency name. This field is only returned if requested through the aux request parameter.
        /// </summary>
        [DataMember(Name = "currency_slug", EmitDefaultValue = false)]
        public string CurrencySlug { get; set; }

        /// <summary>
        /// The exchange reported symbol for the quote (secondary) currency in this market pair. In most cases this is identical to CoinMarketCap's symbol but it may differ if the exchange uses an outdated or contentious symbol that contrasts with the majority of other markets.
        /// </summary>
        [DataMember(Name = "exchange_symbol")]
        public string ExchangeSymbol { get; set; }

        /// <summary>
        /// The currency type for the quote (secondary) currency in this market pair ("cryptocurrency", "fiat").
        /// </summary>
        [DataMember(Name = "currency_type")]
        public string CurrencyType { get; set; }
    }

    /// <summary>
    /// Market Pair quotes object containing key->quote objects for each convert option requested. "USD" and "exchange_reported" are defaults.
    /// </summary>
    [DataContract]
    public class MarketPairQuotesObject
    {
        /// <summary>
        /// "Exhange_Reported" - The latest exchange reported price for this market pair in quote currency units.
        /// "$Key" - The latest exchange reported price for this market pair converted into the requested convert currency.
        /// </summary>
        [DataMember(Name = "price")]
        public double Price { get; set; }

        /// <summary>
        /// The latest exchange reported 24 hour rolling volume for this market pair in base cryptocurrency units.
        /// </summary>
        [DataMember(Name = "volume_24h_base", EmitDefaultValue = false)]
        public double Volume24HBase { get; set; }

        /// <summary>
        /// The latest exchange reported 24 hour rolling volume for this market pair in quote cryptocurrency units.
        /// </summary>
        [DataMember(Name = "volume_24h_quote", EmitDefaultValue = false)]
        public double Volume24HQuote { get; set; }    

        /// <summary>
        /// The latest exchange reported price in base units converted into the requested convert currency. This field is only returned if requested through the aux request parameter.
        /// </summary>
        [DataMember(Name = "price_quote", EmitDefaultValue = false)]
        public double PriceQuote { get; set; }

        /// <summary>
        /// The latest exchange reported 24 hour rolling volume in quote units for this market pair converted into the requested convert currency.
        /// </summary>
        [DataMember(Name = "volume_24h", EmitDefaultValue = false)]
        public double Volume24H { get; set; }

        /// <summary>
        /// "Exchange_Reported" - Timestamp (ISO 8601) of the last time this market data was updated.
        /// "$Key" - Timestamp (ISO 8601) of when the conversion currency's current value was referenced for this conversion.
        /// </summary>
        [DataMember(Name = "last_updated")]
        public string LastUpdated { get; set; }
    }
    
}
