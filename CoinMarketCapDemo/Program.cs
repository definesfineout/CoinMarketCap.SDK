using CoinMarketCap.Client;
using Newtonsoft.Json;
using System;
using System.Configuration;

namespace CoinMarketCapDemo
{
    internal class Program
    {
        private static readonly string ApiKey = ConfigurationManager.AppSettings["CoinMarketCap.ApiKey"];

        private static readonly bool Sandbox =
            ConfigurationManager.AppSettings["CoinMarketCap.Sandbox"]?.ToLowerInvariant().Equals("true") ?? false;

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
            Console.WriteLine("\t[1] Map");
            Console.WriteLine("\t[2] Metadata");
            Console.WriteLine("\t[3] Listings Latest");
            Console.WriteLine("\t[4] Listings Historical");
            Console.WriteLine("\t[5] Quotes Latest");
            Console.WriteLine("\t[6] Quotes Historical");
            Console.WriteLine("\t[7] Market Pairs Latest");
            Console.WriteLine("\t[8] OHLCV Latest");
            Console.WriteLine("\t[9] OHLCV Historical");
            Console.WriteLine("\t[0] Price Performance Stats Latest");
            Console.WriteLine("\t[x] Back to Main Menu");
            var input = Console.ReadLine();
            switch (input?.Trim().ToLowerInvariant() ?? string.Empty)
            {
                case "1":
                    CryptocurrencyMap();
                    return true;
                case "2":
                    CryptocurrencyMetadata();
                    return true;
                case "3":
                    CryptocurrencyListingsLatest();
                    return true;
                case "4":
                    CryptocurrencyListingsHistorical();
                    return true;
                case "5":
                    CryptocurrencyQuotesLatest();
                    return true;
                case "6":
                    CryptocurrencyQuotesHistorical();
                    return true;
                case "7":
                    CryptocurrencyMarketPairsLatest();
                    return true;
                case "8":
                    CryptocurrencyOhlcvLatest();
                    return true;
                case "9":
                    CryptocurrencyOhlcvHistorical();
                    return true;
                case "0":
                    CryptocurrencyPricePerformanceStatsLatest();
                    return true;
                case "x":
                    return false;
            }
            Console.WriteLine("\nDo what now?");
            return true;
        }

        private static void CryptocurrencyMap()
        {
            Console.WriteLine("\nEnter symbol (separate with comma): ");
            var symbol = Console.ReadLine();

            var client = new CryptocurrencyClient(ApiKey, Sandbox);
            var response = client.Map(null, 1, 10, null, symbol);
            var json = JsonConvert.SerializeObject(response, Formatting.Indented);

            ShowResponseAndWait(json);
        }

        private static void CryptocurrencyMetadata()
        {
            Console.WriteLine("\nEnter symbol: ");
            var symbol = Console.ReadLine();

            var client = new CryptocurrencyClient(ApiKey, Sandbox);
            var response = client.MetadataBySymbol(symbol);
            var json = JsonConvert.SerializeObject(response, Formatting.Indented);

            ShowResponseAndWait(json);
        }

        private static void CryptocurrencyListingsLatest()
        {
            var client = new CryptocurrencyClient(ApiKey, Sandbox);
            var response = client.ListingsLatest(1, 10);
            var json = JsonConvert.SerializeObject(response, Formatting.Indented);

            ShowResponseAndWait(json);
        }

        private static void CryptocurrencyListingsHistorical()
        {
            Console.WriteLine("\nEnter date (YYYY-MM-DD):");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("\nInvalid date. Please enter a date using the format YYYY-MM-DD\nEnter start date: ");
            }

            var client = new CryptocurrencyClient(ApiKey, Sandbox);
            var response = client.ListingsHistorical(date, 1, 1);
            var json = JsonConvert.SerializeObject(response, Formatting.Indented);

            ShowResponseAndWait(json);
        }

        private static void CryptocurrencyQuotesLatest()
        {
            Console.WriteLine("\nEnter symbol: ");
            var symbol = Console.ReadLine();

            var client = new CryptocurrencyClient(ApiKey, Sandbox);
            var response = client.QuotesLatestBySymbol(symbol);
            var json = JsonConvert.SerializeObject(response, Formatting.Indented);

            ShowResponseAndWait(json);
        }

        private static void CryptocurrencyOhlcvLatest()
        {
            Console.WriteLine("\nEnter symbol (separate by comma): ");
            var symbol = Console.ReadLine();

            var client = new CryptocurrencyClient(ApiKey, Sandbox);
            var response = client.OhlcvLatestBySymbol(symbol);
            var json = JsonConvert.SerializeObject(response, Formatting.Indented);

            ShowResponseAndWait(json);
        }

        private static void CryptocurrencyQuotesHistorical()
        {
            Console.WriteLine("\nEnter symbol: ");
            var symbol = Console.ReadLine();

            Console.WriteLine("\nEnter start date (YYYY-MM-DD): ");
            DateTime startDate;

            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine($"\nSorry, {startDate} is not a valid date.\nPlease enter a date using the format YYYY-MM-DD");
                Console.WriteLine("\nEnter start date: ");
            }

            Console.WriteLine("\nEnter end date (YYYY-MM-DD): ");
            DateTime endDate;

            while (!DateTime.TryParse(Console.ReadLine(), out endDate))
            {
                Console.WriteLine($"\nSorry, {endDate} is not a valid date.\nPlease enter a date using the format YYYY-MM-DD");
                Console.WriteLine("\nEnter end date: ");
            }

            var client = new CryptocurrencyClient(ApiKey, Sandbox);
            var response = client.QuotesHistoricalBySymbol(symbol, startDate, endDate);
            var json = JsonConvert.SerializeObject(response, Formatting.Indented);

            ShowResponseAndWait(json);
        }

        private static void CryptocurrencyMarketPairsLatest()
        {
            Console.WriteLine("\nEnter symbol: ");
            var symbol = Console.ReadLine();

            var client = new CryptocurrencyClient(ApiKey, Sandbox);
            var response = client.MarketPairsLatestBySymbol(symbol);
            var json = JsonConvert.SerializeObject(response, Formatting.Indented);

            ShowResponseAndWait(json);
        }

        private static void CryptocurrencyOhlcvHistorical()
        {
            Console.WriteLine("\nEnter symbol: ");
            var symbol = Console.ReadLine();

            Console.WriteLine("\nEnter start date (YYYY-MM-DD):");
            DateTime startDate;
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("\nInvalid date. Please enter a date using the format YYYY-MM-DD\nEnter start date: ");
            }

            Console.WriteLine("\nEnter end date (YYYY-MM-DD):");
            DateTime endDate;
            while (!DateTime.TryParse(Console.ReadLine(), out endDate))
            {
                Console.WriteLine("\nInvalid date. Please enter a date using the format YYYY-MM-DD\nEnter start date: ");
            }

            var client = new CryptocurrencyClient(ApiKey, Sandbox);
            var response = client.OhlcvHistoricalBySymbol(symbol, null, startDate, endDate);
            var json = JsonConvert.SerializeObject(response, Formatting.Indented);

            ShowResponseAndWait(json);
        }

        private static void CryptocurrencyPricePerformanceStatsLatest()
        {
            Console.WriteLine("\nEnter symbol: ");
            var symbol = Console.ReadLine();

            var client = new CryptocurrencyClient();
            var response = client.PricePerformanceStatsBySymbol(symbol);
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
