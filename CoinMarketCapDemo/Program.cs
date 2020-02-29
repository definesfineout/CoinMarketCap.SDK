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
            Console.WriteLine("\t[1] Map");
            Console.WriteLine("\t[2] Metadata");
            Console.WriteLine("\t[3] Listings Latest");
            Console.WriteLine("\t[4] Listings Historical");
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
                case "7":
                case "8":
                case "9":
                case "0":
                    Console.WriteLine("\nComing soon...");
                    return true;
                case "1":
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

            var client = new CryptocurrencyClient();
            var response = client.Map(null, 1, 10, null, symbol);
            var json = JsonConvert.SerializeObject(response, Formatting.Indented);

            ShowResponseAndWait(json);
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

        private static void CryptocurrencyListingsHistorical()
        {
            Console.WriteLine("\nEnter date (YYYY-MM-DD):");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("\nInvalid date. Please enter a date using the format YYYY-MM-DD\nEnter start date: ");
            }

            var client = new CryptocurrencyClient();
            var response = client.ListingsHistorical(date, 1, 1);
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

            Console.WriteLine("\nEnter start date: ");
            var startDate = new DateTime();

            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine($"\nSorry, {startDate} is not a valid date.\nPlease enter a date using the format YYYY-MM-DD");
                Console.WriteLine("\nEnter start date: ");
            }

            Console.WriteLine("\nEnter end date: ");
            var endDate = new DateTime();

            while (!DateTime.TryParse(Console.ReadLine(), out endDate))
            {
                Console.WriteLine($"\nSorry, {endDate} is not a valid date.\nPlease enter a date using the format YYYY-MM-DD");
                Console.WriteLine("\nEnter end date: ");
            }

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
