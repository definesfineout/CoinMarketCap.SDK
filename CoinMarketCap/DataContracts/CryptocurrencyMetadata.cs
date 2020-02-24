using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CoinMarketCap.DataContracts
{
    [DataContract]
    public class CryptocurrencyMetadata
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
        /// The category for this cryptocurrency.
        /// Valid values: "coin", "token"
        /// </summary>
        [DataMember(Name = "category")]
        public string Category { get; set; }

        /// <summary>
        /// The web URL friendly shorthand version of this cryptocurrency name.
        /// </summary>
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Link to a CoinMarketCap hosted logo png for this cryptocurrency. 64px is default size returned.
        /// Replace "64x64" in the image path with these alternative sizes: 16, 32, 64, 128, 200
        /// </summary>
        [DataMember(Name = "logo")]
        public string Logo { get; set; }

        /// <summary>
        /// A CoinMarketCap supplied brief description of this cryptocurrency. This field will return null
        /// if a description is not available.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of when this cryptocurrency was added to CoinMarketCap.
        /// </summary>
        [DataMember(Name = "date_added")]
        public string DateAdded { get; set; }

        /// <summary>
        /// A Markdown [https://commonmark.org/help/] formatted notice that may highlight a significant
        /// event or condition that is impacting the cryptocurrency or how it is displayed, otherwise null.
        /// A notice may highlight a recent or upcoming mainnet swap, symbol change, exploit event, or known
        /// issue with a particular exchange or market, for example. If present, this notice is also
        /// displayed in an alert banner at the top of the cryptocurrency's page on coinmarketcap.com.
        /// </summary>
        [DataMember(Name = "notice")]
        public string Notice { get; set; }

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

    [DataContract]
    public class CryptocurrencyUrls
    {
        /// <summary>
        /// Array of website URLs.
        /// </summary>
        [DataMember(Name="website")]
        public List<string> Website { get; set; }

        /// <summary>
        /// Array of white paper or technical documentation URLs.
        /// </summary>
        [DataMember(Name = "technical_doc")]
        public List<string> TechnicalDoc { get; set; }

        /// <summary>
        /// Array of block explorer URLs.
        /// </summary>
        [DataMember(Name = "explorer")]
        public List<string> Explorer { get; set; }

        /// <summary>
        /// Array of source code URLs.
        /// </summary>
        [DataMember(Name = "source_code")]
        public List<string> SourceCode { get; set; }

        /// <summary>
        /// Array of message board URLs.
        /// </summary>
        [DataMember(Name = "message_board")]
        public List<string> MessageBoard { get; set; }

        /// <summary>
        /// Array of chat service URLs.
        /// </summary>
        [DataMember(Name = "chat")]
        public List<string> Chat { get; set; }

        /// <summary>
        /// Array of announcement URLs.
        /// </summary>
        [DataMember(Name = "announcement")]
        public List<string> Announcement { get; set; }

        /// <summary>
        /// Array of Reddit community page URLs.
        /// </summary>
        [DataMember(Name = "reddit")]
        public List<string> Reddit { get; set; }

        /// <summary>
        /// Array of official twitter profile URLs.
        /// </summary>
        [DataMember(Name = "twitter")]
        public List<string> Twitter { get; set; }
    }
}
