using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;

namespace TLGPizza
{
    class Pizza
    {
        private List<Store> stores = new List<Store>();

        public Pizza()
        {
            string constring = ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString;

            Console.WriteLine(constring);

            string StoreSales = @"SELECT s.Name, p.PurchaseTotal
                                        FROM TLGPizza.Store s
                                        JOIN TLGPizza.Payment p
                                        ON s.StoreId = p.StoreId
                                        ORDER BY s.Name;";

            var table = new DataTable();
            using (var da = new SqlDataAdapter(StoreSales, constring))
            {
                da.Fill(table);
            }

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine("{0}:{1}", row[0], row[1]);
            }
            Console.WriteLine();
            Console.WriteLine();

            Dictionary<string, List<decimal>> pizzaData = new Dictionary<string, List<decimal>>();

            foreach (DataRow row in table.Rows)
            {
                if (pizzaData.ContainsKey((string)row[0]))
                {
                    pizzaData[(string)row[0]].Add((decimal)row[1]);
                }
                else
                {
                    pizzaData[(string)row[0]] = new List<decimal>();
                    pizzaData[(string)row[0]].Add((decimal)row[1]);
                }
            }

            foreach (var storeName in pizzaData.Keys)
            {
                stores.Add(new Store(storeName, pizzaData[storeName]));
            }
        }

        public void PrintPizzaStats()
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!The Pizza Stats!!!!!!!!!!!!!!!!!!!!!");
            for (int i = 0; i < stores.Count; i++)
            {
                Console.WriteLine("{0}: {1}", stores[i].name, stores[i].TotalSales);
            }
        }
    }

    class Ingredient
    {
        public string name;
        private decimal cost;

        public Ingredient(string name, decimal cost)
        {
            this.name = name;
            this.cost = cost;
        }

        public decimal TotalSales
        {
            get
            {
                decimal sum = 0.00m;
                for (int i = 0; i < sales.Count; i++)
                {
                    sum += sales[i];
                }
                return sum;
            }
        }
    }
}
