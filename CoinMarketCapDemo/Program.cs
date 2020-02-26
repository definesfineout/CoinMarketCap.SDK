using CoinMarketCap.Client;
using Newtonsoft.Json;
using System;

namespace CoinMarketCapDemo
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
            Console.WriteLine("\t[6] Quotes Historical");
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
                case "6":
                    CryptocurrencyQuotesHistorical();
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

        private static void CryptocurrencyQuotesHistorical()
        {
            Console.WriteLine("\nEnter symbol: ");
            var symbol = Console.ReadLine();

            //seed date interval that conforms with test-env parameters
            var startDate = new DateTime(2019, 08, 01, 00, 04, 01);
            var endDate = new DateTime(2019, 08, 30, 18, 49, 02);

            var client = new CryptocurrencyClient();
            var response = client.QuotesHistoricalBySymbol(symbol, startDate, endDate);
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
    }
}
