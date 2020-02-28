using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

[assembly: InternalsVisibleTo("Newtonsoft.Json")]
namespace CoinMarketCap.DataContracts
{
    /// <summary>
    /// Mapping of Cryptocurrency to CoinMarketCap ID.
    /// </summary>
    [DataContract]
    public class CryptocurrencyIdMapping
    {
        /// <summary>
        /// The unique cryptocurrency ID for this cryptocurrency.
        /// </summary>
        [DataMember(Name="id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of this cryptocurrency.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The ticker symbol for this cryptocurrency, always in all caps.
        /// </summary>
        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// The web URL friendly shorthand version of this cryptocurrency name.
        /// </summary>
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        /// <summary>
        /// <value>true</value> if this cryptocurrency has at least 1 active market currently being tracked by
        /// the platform, otherwise <value>false</value>. A value of <value>true</value> is analogous with
        /// <value>listing_status=active</value>.
        /// </summary>
        public bool IsActive
        {
            get => IsActiveInt == 1;
            set => IsActiveInt = value ? 1 : 0;
        }

        /// <summary>
        /// <value>1</value> if this cryptocurrency has at least 1 active market currently being tracked by
        /// the platform, otherwise <value>0</value>. A value of <value>1</value> is analogous with
        /// <value>listing_status=active</value>.
        /// </summary>
        [DataMember(Name = "is_active")]
        internal int IsActiveInt { get; set; }

        /// <summary>
        /// Valid values: <value>"active"</value>, <value>"inactive"</value>, <value>"untracked"</value>
        /// The listing status of the cryptocurrency. This field is only returned if requested through the
        /// aux request parameter.
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of the date this cryptocurrency was first available on the platform.
        /// </summary>
        [DataMember(Name = "first_historical_data")]
        public int FirstHistoricalData { get; set; }

        /// <summary>
        /// Timestamp (ISO 8601) of the last time this cryptocurrency's market data was updated.
        /// </summary>
        [DataMember(Name = "last_historical_data")]
        public int LastHistoricalData { get; set; }

        /// <summary>
        /// Metadata about the parent cryptocurrency platform this cryptocurrency belongs to if it is a
        /// token, otherwise <value>null</value>.
        /// </summary>
        [DataMember(Name = "platform")]
        public ParentPlatform Platform { get; set; }
    }
}
