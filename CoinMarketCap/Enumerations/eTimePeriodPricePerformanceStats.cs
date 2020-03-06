using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoinMarketCap.Enumerations
{
    public enum eTimePeriodPricePerformanceStats
    {
        [Description("all_time")]
        AllTime,
        [Description("yesterday")]
        Yesterday,
        [Description("24h")]
        Hours24,
        [Description("7d")]
        Days7,
        [Description("30d")]
        Days30,
        [Description("90d")]
        Days90,
        [Description("365d")]
        Days365
    }
}
