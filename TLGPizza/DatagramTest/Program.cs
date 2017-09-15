using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;

namespace TLGPizza
{
    class Program
    {
        static Datagram data;

        static void Main()
        {
            TruncateTables();

            for (int i = 0; i < 10; i++)
            {
                using (StreamReader datagramReader = new StreamReader($"..\\..\\dataTest0{i}.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Datagram));
                    data = (Datagram)serializer.Deserialize(datagramReader);
                }

                data.InsertIntoDB();
            }



        }

        static void PrintData()
        {
            Console.WriteLine($"{data.Id}");
            Console.WriteLine($"{data.Timestamp}");
            Console.WriteLine($"{data.Transaction.Customer.Name}");
            Console.WriteLine($"{data.Transaction.Customer.Address[0].AddressLine1}");
            Console.WriteLine($"{data.Transaction.Customer.Name}");
            Console.WriteLine($"{data.Transaction.Order}");
        }

        static public void PrintProperties(object obj)
        {
            PrintProperties(obj, 0);
        }

        static public void PrintProperties(object obj, int indent)
        {
            if (obj == null) return;
            string indentString = new string(' ', indent);
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj, null);
                if (property.PropertyType.Assembly == objType.Assembly && !property.PropertyType.IsEnum)
                {
                    Console.WriteLine("{0}{1}:", indentString, property.Name);
                    PrintProperties(propValue, indent + 2);
                }
                else
                {
                    Console.WriteLine("{0}{1}: {2}", indentString, property.Name, propValue);
                }
            }
        }

        static void TruncateTables()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string truncateStmt = "TRUNCATE TABLE[TLGPizza].[Datagram];";
                using (SqlCommand cmd = new SqlCommand(truncateStmt, connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "TRUNCATE TABLE[TLGPizza].[Address];";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "TRUNCATE TABLE[TLGPizza].[Assembly];";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "TRUNCATE TABLE[TLGPizza].[Component];";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "TRUNCATE TABLE[TLGPizza].[Customer];";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "TRUNCATE TABLE[TLGPizza].[Item];";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "TRUNCATE TABLE[TLGPizza].[Order];";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "TRUNCATE TABLE[TLGPizza].[Payment];";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "TRUNCATE TABLE[TLGPizza].[PaymentDue];";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "TRUNCATE TABLE[TLGPizza].[Prepayment];";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "TRUNCATE TABLE[TLGPizza].[Store];";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "TRUNCATE TABLE[TLGPizza].[Tax];";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "TRUNCATE TABLE[TLGPizza].[Transaction];";
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

    }
}
