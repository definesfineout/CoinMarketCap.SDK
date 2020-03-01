using System.ComponentModel;

namespace CoinMarketCap.Enumerations
{
    public enum eSortCryptocurrencyListingsHistorical
    {
        [Description("cmc_rank")]
        CmcRank,
        [Description("name")]
        Name,
        [Description("symbol")]
        Symbol,
        [Description("date_added")]
        DateAdded,
        [Description("market_cap")]
        MarketCap,
        [Description("price")]
        Price,
        [Description("circulating_supply")]
        CirculatingSupply,
        [Description("total_supply")]
        TotalSupply,
        [Description("max_supply")]
        MaxSupply,
        [Description("volume_24h")]
        Volume24H,
        [Description("percent_change_1h")]
        PercentChange1H,
        [Description("percent_change_24h")]
        PercentChange24H,
        [Description("percent_change_7d")]
        PercentChange7D
    }
}
