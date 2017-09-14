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
    class TLGPizza
    {
        static void Main()
        {
            Stores stores = new Stores();
            stores.PrintStoreStats();
        }
    }

    class Stores
    {
        private List<Store> stores = new List<Store>();

        public Stores()
        {

            //string StoreSales = @"SELECT s.Name, pd.Amount, p.PurchaseTotal
            //                            FROM TLGPizza.Store s
            //                            JOIN TLGPizza.Payment p
            //                            ON s.StoreId = p.StoreId
            //                            JOIN TLGPizza.PaymentDue pd
            //                            ON pd.PaymentDueId = p.PaymentDueId
            //                            ORDER BY s.Name;";

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

            Dictionary <string, List<decimal>> storeData = new Dictionary<string, List<decimal>>();

            foreach (DataRow row in table.Rows)
            {
                if (storeData.ContainsKey((string)row[0]))
                {
                    storeData[(string)row[0]].Add((decimal)row[1]);
                }
                else
                {
                    storeData[(string)row[0]] = new List<decimal>();
                    storeData[(string)row[0]].Add((decimal)row[1]);
                }
            }
            
            foreach (var storeName in storeData.Keys)
            {
                stores.Add(new Store(storeName, storeData[storeName]));
            }
        }

        public void PrintStoreStats()
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!The Store Stats!!!!!!!!!!!!!!!!!!!!!");
            for (int i = 0; i < stores.Count; i++)
            {
                Console.WriteLine("{0}: {1}", stores[i].name, stores[i].TotalSales);
            }
        }
    }

    class Store
    {
        public string name;
        private List<decimal> sales;

        public Store(string name, List<decimal> sales)
        {
            this.name = name;
            this.sales = sales;
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
