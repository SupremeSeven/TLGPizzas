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
        static void Main(string[] args)
        {
        }
    }

    class Stores
    {
        private List<Store> stores = new List<Stores>();

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

            string StoreSales = @"SELECT s.Name, p.PurchaseTotal
                                        FROM TLGPizza.Store s
                                        JOIN TLGPizza.Payment p
                                        ON s.StoreId = p.StoreId
                                        ORDER BY s.Name;";

            var table = new DataTable();
            using (var da = new SqlDataAdapter(StoreSales, "connection string"))
            {
                da.Fill(table);
            }

            NameValueCollection storeData = new NameValueCollection();

            foreach(DataRow row in table.Rows)
            {
                storeData.Add((string)row[0], (string)row[1]);
            }

            foreach(string storeName in storeData)
            {
                List<decimal> sales = new List<decimal>();
                var values = storeData.GetValues(storeName);
                foreach (var numStr in values)
                {
                    decimal sale = Convert.ToDecimal(numStr);
                    sales.Add(sale);
                }
                stores.Add(new Store(storeName, sales));
            }
        }
    }

    class Store
    {
        private string name;
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
