using SafeAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeAppDemo.DataStore
{
    public static class Table
    {
        public static IList<Product> Products;
        private static int productCount = 0;
        public static int ProductCount { get { return ++productCount; } }

        public static IList<WatchListEntry> WatchListEntries;
        private static int watchListEntryCount = 0;
        public static int WatchListEntryCount { get { return ++watchListEntryCount; } }

        public static void Initialize()
        {
            Products = new List<Product>
            {
                new Product(ProductCount, "Ibanez", "Prestige RG Frozen Ocean", 1500.00d, 3),
                new Product(ProductCount, "ESP", "LTD Horizon Evertune", 1100.00d, 2),
                new Product(ProductCount, "Bogner", "Uberschall", 2200.00d, 1),
                new Product(ProductCount, "Diezel", "Herbert", 3500.00d, 3),
                new Product(ProductCount, "Alienware", "17 R5", 999.00, 2),
                new Product(ProductCount, "Tesla", "Model 3", 37000.00, 1)
            };
            WatchListEntries = new List<WatchListEntry>
            {
                new WatchListEntry(WatchListEntryCount, "ESP", "LTD Horizon Evertune"),
                new WatchListEntry(WatchListEntryCount, "Tesla", "Model S"),
                new WatchListEntry(WatchListEntryCount, "EVH", "212 Combo")
            };
        }

    }
}
