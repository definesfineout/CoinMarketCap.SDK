using System.Runtime.Serialization;

namespace CoinMarketCap.DataContracts
{
    /// <summary>
    /// Mapping of Fiat asset to CoinMarketCap ID.
    /// </summary>
    [DataContract]
    public class FiatIdMapping
    {
        /// <summary>
        /// The unique CoinMarketCap ID for this asset.
        /// </summary>
        [DataMember(Name="id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of this asset.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The currency sign for this asset.
        /// </summary>
        [DataMember(Name = "sign")]
        public string Sign { get; set; }

        /// <summary>
        /// The ticker symbol for this asset, always in all caps.
        /// </summary>
        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }
    }
}
