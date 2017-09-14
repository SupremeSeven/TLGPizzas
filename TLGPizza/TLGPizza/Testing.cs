using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Data;
using System.Data.SqlClient;

namespace DatagramTest
{
    class Program
    {
        static Datagram data;

        static void Main()
        {
            // using (StreamReader datagramReader = new StreamReader(@"..\..\Datagramv1.1.xml"))
            using (StreamReader datagramReader = new StreamReader(@"..\..\TestDatagram.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Datagram));
                data = (Datagram)serializer.Deserialize(datagramReader);
            }

            Console.WriteLine("Woohoo!");

            PrintData();

            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = connection.GetSchema("Columns");
                connection.Close();
                Console.WriteLine(DumpDataTable(dt));
            }
        }

        public static string DumpDataTable(DataTable table)
        {
            string data = string.Empty;
            StringBuilder sb = new StringBuilder();

            if (null != table && null != table.Rows)
            {
                foreach (DataRow dataRow in table.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        sb.Append(item);
                        sb.Append(',');
                    }
                    sb.AppendLine();
                }

                data = sb.ToString();
            }
            return data;
        }

        static void PrintData()
        {
            Console.WriteLine($"{data.Id}");
            Console.WriteLine($"{data.Timestamp}");
            Console.WriteLine($"{data.Transaction.Customer}");
            Console.WriteLine($"{data.Transaction.Order}");
        }

    }
}
