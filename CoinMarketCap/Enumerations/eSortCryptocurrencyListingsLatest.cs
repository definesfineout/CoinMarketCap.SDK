using System.ComponentModel;

namespace CoinMarketCap.Enumerations
{
    public enum eSortCryptocurrencyListingsLatest
    {
        [Description("market_cap")]
        MarketCap,
        [Description("name")]
        Name,
        [Description("symbol")]
        Symbol,
        [Description("date_added")]
        DateAdded,
        [Description("market_cap_strict")]
        MarketCapStrict,
        [Description("price")]
        Price,
        [Description("circulating_supply")]
        CirculatingSupply,
        [Description("total_supply")]
        TotalSupply,
        [Description("max_supply")]
        MaxSupply,
        [Description("num_market_pairs")]
        NumMarketPairs,
        [Description("volume_24h")]
        Volume24H,
        [Description("percent_change_1h")]
        PercentChange1H,
        [Description("percent_change_24h")]
        PercentChange24H,
        [Description("percent_change_7d")]
        PercentChange7D,
        [Description("market_cap_by_total_supply_strict")]
        MarketCapByTotalSupplyStrict,
        [Description("volume_7d")]
        Volume7D,
        [Description("volume_30d")]
        Volume30D
    }
}
