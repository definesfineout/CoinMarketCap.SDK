# CoinMarketCap .NET
A free, open-source .NET client SDK for the [CoinMarketCap API](https://coinmarketcap.com/api/).

## Quick Start
Add your CoinMarketCap API key to your application's settings:

```xml
TODO
```

Then, simply new up a client for your desired endpoint and call any of the endpoint's methods:

```c#
using CoinMarketCap;

var client = new CryptocurrencyClient();
var response = client.Metadata("XTZ");
```

## Contribute
You are welcome to fork and send pull requests. Code reviews and suggestions are always appreciated!

* [How To: Fork a GitHub Repository & Submit a Pull Request](https://jarv.is/notes/how-to-pull-request-fork-github/)
* [How to keep your fork up to date with its origin](https://about.gitlab.com/blog/2016/12/01/how-to-keep-your-fork-up-to-date-with-its-origin/)

To get in touch, [email Defines Fineout](mailto:dustin.fineout@gmail.com).

### Tips
CoinMarketCap .NET will always be free.

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

* Newtonsoft Json.NET by James Newton-King
