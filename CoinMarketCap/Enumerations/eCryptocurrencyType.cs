using System.ComponentModel;

namespace CoinMarketCap.Enumerations
{
    public enum eCryptocurrencyType
    {
        [Description("all")]
        All,
        [Description("coins")]
        Coins,
        [Description("tokens")]
        Tokens
    }
}