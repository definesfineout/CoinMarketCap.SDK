using System.ComponentModel;

namespace CoinMarketCap.Enumerations
{
    public enum eSortCryptocurrencyMarketPairsLatest
    {
        [Description("volume_24h_strict")]
        Volume24HStrict,
        [Description("cmc_rank")]
        CmcRank,
        [Description("effective_liquidity")]
        EffectiveLiquidity
    }
}