using CoinMarketCap.Client;
using Newtonsoft.Json;
using System;
using System.Net;

namespace CoinMarketCapTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("CoinMarketCap.NET Demo\n");
            try
            {
                var swim = true;
                while (swim)
                {
                    swim = MainMenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\n[Enter] to exit...");
                Console.ReadLine();
            }
        }

        private static bool MainMenu()
        {
            Console.WriteLine("\nSelect category:");
            Console.WriteLine("\t[1] Cryptocurrency");
            Console.WriteLine("\t[x] Exit");
            var input = Console.ReadLine();
            switch (input?.Trim().ToLowerInvariant() ?? string.Empty)
            {
                case "1":
                    var swim = true;
                    while (swim)
                    {
                        swim = CryptocurrencyMenu();
                    }
                    return true;
                case "x":
                    return false;
            }
            Console.WriteLine("\nDo what now?");
            return true;
        }

        private static bool CryptocurrencyMenu()
        {
            Console.WriteLine("\nSelect Cryptocurrency Endpoint:\n");
            Console.WriteLine("\t[1] [TODO] Map");
            Console.WriteLine("\t[2] Metadata");
            Console.WriteLine("\t[3] Listings Latest");
            Console.WriteLine("\t[4] [TODO] Listings Historical");
            Console.WriteLine("\t[5] Quotes Latest");
            Console.WriteLine("\t[6] [TODO] Quotes Historical");
            Console.WriteLine("\t[7] [TODO] Market Pairs Latest");
            Console.WriteLine("\t[8] [TODO] OHLCV Latest");
            Console.WriteLine("\t[9] [TODO] OHLCV Historical");
            Console.WriteLine("\t[0] [TODO] Price Performance Stats Latest");
            Console.WriteLine("\t[x] Back to Main Menu");
            var input = Console.ReadLine();
            switch (input?.Trim().ToLowerInvariant() ?? string.Empty)
            {
                case "1":
                case "4":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    Console.WriteLine("\nComing soon...");
                    return true;
                case "2":
                    CryptocurrencyMetadata();
                    return true;
                case "3":
                    CryptocurrencyListingsLatest();
                    return true;
                case "5":
                    CryptocurrencyQuotesLatest();
                    return true;
                case "x":
                    return false;
            }
            Console.WriteLine("\nDo what now?");
            return true;
        }

        private static void CryptocurrencyMetadata()
        {
            Console.WriteLine("\nEnter symbol: ");
            var symbol = Console.ReadLine();

            var client = new CryptocurrencyClient();
            var response = client.MetadataBySymbol(symbol);
            var json = JsonConvert.SerializeObject(response, Formatting.Indented);

            ShowResponseAndWait(json);
        }

        private static void CryptocurrencyListingsLatest()
        {
            var client = new CryptocurrencyClient();
            var response = client.ListingsLatest(1, 10);
            var json = JsonConvert.SerializeObject(response, Formatting.Indented);

            ShowResponseAndWait(json);
        }

        private static void CryptocurrencyQuotesLatest()
        {
            Console.WriteLine("\nEnter symbol: ");
            var symbol = Console.ReadLine();

            var client = new CryptocurrencyClient();
            var response = client.QuotesLatestBySymbol(symbol);
            var json = JsonConvert.SerializeObject(response, Formatting.Indented);

            ShowResponseAndWait(json);
        }

        private static void ShowResponseAndWait(string json)
        {
            Console.WriteLine("Response:");
            Console.WriteLine(json);
            Console.WriteLine("[Enter] to continue...");
            Console.ReadLine();
        }

        private static void WatchTriggerTest()
        {
            var trigger = new WatchTrigger
            {
                Amount = 3.28,
                Symbol = "XTZ",
                TriggerType = eWatchTriggerType.Under
            };
            double lastPrice = 0;
            while (true)
            {
                try
                {
                    var client = new CryptocurrencyClient();
                    var xtz = client.QuotesLatestBySymbol("XTZ");
                    foreach (var coin in xtz.Data)
                    {
                        Console.WriteLine($"Retrieved quote for {coin.Key}:");
                        foreach (var quote in coin.Value.Quote)
                        {
                            Console.Write($"\t{quote.Key}:\t{quote.Value.Price:C6}");
                        }
                    }

                    // Show change for XTZ
                    var price = xtz.Data["XTZ"].Quote["USD"].Price;
                    if (lastPrice <= 0)
                    {
                        // first iteration
                    }
                    else if (Math.Abs(price - lastPrice) < 1e-11)
                    {
                        Console.Write("\t==");
                    }
                    else if (price > lastPrice)
                    {
                        Console.Write($"\tUP +{price - lastPrice}");
                    }
                    else
                    {
                        Console.Write($"\tDOWN {lastPrice - price}");
                    }

                    // Check the trigger
                    if (trigger.Eval(price))
                    {
                        Console.Write("\t!!! TRIGGER !!!");
                    }

                    lastPrice = price;
                    Console.WriteLine();
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("\n[Enter] to refresh; [x] to quit...");
                var input = Console.ReadLine() ?? string.Empty;
                if (input.Equals("x", StringComparison.InvariantCultureIgnoreCase))
                {
                    return;
                }
            }
        }
    }


    internal class WatchTrigger
    {
        public string Symbol { get; set; }
        public eWatchTriggerType TriggerType { get; set; }
        public double Amount { get; set; }

        public bool Eval(double price)
        {
            switch (TriggerType)
            {
                case eWatchTriggerType.Over:
                    return price > Amount;
                case eWatchTriggerType.Under:
                    return price < Amount;
                default:
                    return false;
            }
        }
    }

    internal enum eWatchTriggerType
    {
        Over,
        Under
    }
}
