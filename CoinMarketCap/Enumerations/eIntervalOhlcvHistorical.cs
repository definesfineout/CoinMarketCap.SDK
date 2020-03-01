using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoinMarketCap.Enumerations
{
    public enum eIntervalOhlcvHistorical
    {
        [Description("daily")]
        Daily,
        [Description("yearly")]
        Yearly,
        [Description("monthly")]
        Monthly,
        [Description("weekly")]
        Weekly,
        [Description("hourly")]
        Hourly,
        [Description("1h")]
        Hours1,
        [Description("2h")]
        Hours2,
        [Description("3h")]
        Hours3,
        [Description("4h")]
        Hours4,
        [Description("6h")]
        Hours6,
        [Description("12h")]
        Hours12,
        [Description("1d")]
        Days1,
        [Description("2d")]
        Days2,
        [Description("3d")]
        Days3,
        [Description("7d")]
        Days7,
        [Description("14d")]
        Days14,
        [Description("15d")]
        Days15,
        [Description("30d")]
        Days30,
        [Description("60d")]
        Days60,
        [Description("90d")]
        Days90,
        [Description("365d")]
        Days365
    }
}
