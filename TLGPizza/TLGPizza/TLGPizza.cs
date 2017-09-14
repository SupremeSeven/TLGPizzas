using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
        Stores stores;
        private decimal totalSales;


        public Stores()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string StoreSales = @"SELECT s.Name, pd.Amount, p.PurchaseTotal
                                        FROM TLGPizza.Store s
                                        JOIN TLGPizza.Payment p
                                        ON s.StoreId = p.StoreId
                                        JOIN TLGPizza.PaymentDue pd
                                        ON pd.PaymentDueId = p.PaymentDueId
                                        ORDER BY s.Name;";

                using (SqlCommand cmd = new SqlCommand(StoreSales, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        //   for (int)
                    }
                    connection.Close();
                }
            }

        }
    }

    class Store
    {

    }
}
