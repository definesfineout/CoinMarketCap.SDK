# CoinMarketCap.SDK
A free, open-source .NET client SDK for the [CoinMarketCap API](https://coinmarketcap.com/api/).

CoinMarketCap.SDK targets [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) and is supported by the following platforms: .NET Core, .NET Framework, Mono, Xamarin.iOS, Xamarin.Mac, Xamarin.Android, Universal Windows Platform, and Unity.

![.NET Core](https://github.com/definesfineout/CoinMarketCap.SDK/workflows/.NET%20Core/badge.svg?branch=master) 

## Quick Start
Simply grab your [CoinMarketCap API](https://coinmarketcap.com/api/) key, and new up a client for your desired endpoint category. Then, call any of the client's methods:

```c#
using CoinMarketCap;

var client = new CryptocurrencyClient(apiKey:"YOUR API KEY HERE", sandbox:true);
var response = client.Metadata("XTZ");
```

The `sandbox` parameter specifies whether to use the `sandbox-api.coinmarketcap.com` host, instead of the default `pro-api.coinmarketcap.com`.

## Demo Application

There is a `CoinMarketCapDemo` console application project included in the solution's `Demo` folder. This demo presents interactive, menu-driven examples of each API endpoint method implemented in the SDK. Be sure to add your API key to `CoinMarketCapDemo/App.config` before building and running or debugging.

## Contribute

You are welcome to fork and send pull requests. Code reviews and suggestions are always appreciated! See the [Contributor Guide](https://github.com/definesfineout/CoinMarketCap.SDK/wiki/Contributor-Guide) to get started.

To get in touch, [email Defines Fineout](mailto:dustin.fineout@gmail.com).

### Tips
CoinMarketCap.SDK will always be free.

Tips are lovely via [Brave Rewards](https://brave.com/dus347), or to the following addresses:

| Coin | Address                                    |
| ---- | ------------------------------------------ |
| USDC | 0x9f8C89B66D7E092a72601Db336464d68e158f2b7 |
| BTC  | 1Ey4urjTbopoZxYkpgZvx9Edsq7PSkJq4          |
| BCH  | qq4ksxsakyjajp7mgz6lxxytgap0z5k5l5cgxjq2ev |
| ETH  | 0x4288Ae6f1Be205fcD57D189619633C8279517F9A |
| LTC  | MA8oPZA83hHfB1SU5VgGkzLMoyJ76XdWP5         |
| DASH | XmFk4zRyaC7hhURni1fkqyHq3hATv1WCu4         |
| BAT  | 0x4a871EdE7b586Dc00B5fE80dA49fEd5593Fb3F5F |
| DAI  | 0xD0670A2ab1Ed006f4cfD10d5adb404Cad84c5Baf |


## Acknowledgments

### Dependencies

* [Newtonsoft Json.NET](https://www.newtonsoft.com/json) by James Newton-King
