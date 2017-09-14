using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;

namespace DatagramTest
{
    public class GenericEntity<T>
    {
        private T obj;

        private static Dictionary<string, string> tableDict = new Dictionary<string, string>
        {
            {"Datagram", "Datagram"},
            {"DatagramTransaction", "Transaction"},
            {"DatagramTransactionCustomer", "Customer"},
            {"DatagramTransactionCustomerAddress", "Address"},
            {"DatagramTransactionOrderAssembly", "Assembly"}
        };

        private string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";

        public GenericEntity(T obj)
        {
            this.obj = obj;
        }
        public string InsertString()
        {
            StringBuilder insertValues = new StringBuilder();
            StringBuilder columnNames = new StringBuilder();

            Type type = typeof(T);
            PropertyInfo[] propInfo = type.GetProperties();

            foreach (PropertyInfo property in propInfo)
            {
                if (columnNames.ToString() == string.Empty)
                    columnNames.AppendFormat($"INSERT INTO [TLGPizza].[{tableDict[type.Name]}] ({property.Name}");
                else
                {
                    columnNames.AppendFormat($", {property.Name}");
                    insertValues.Append(", ");
                }
                insertValues.Append($"@{property.Name}");
            }

            if (columnNames.ToString() != string.Empty)
                columnNames.AppendFormat($") VALUES({insertValues.ToString()});");

            return columnNames.ToString();
        }

        public void InsertDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertStmt = InsertString();
                Type type = typeof(T);

                using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
                {
                    connection.Open();

                    //PropertyInfo[] propInfo = type.GetProperties();

                    //foreach (PropertyInfo property in propInfo)
                    //{
                    //    cmd.Parameters.Add($"@{property.Name}");
                    //    cmd.Parameters[$"@{property.Name}"].Value = property.GetValue(obj);
                    //}
                    //cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT[TABLE_NAME],[COLUMN_NAME],[DATA_TYPE] FROM[TLGPizza].[INFORMATION_SCHEMA].[COLUMNS];";

                    var test = cmd.ExecuteNonQuery();

                    Console.WriteLine(test);

                    connection.Close();
                }
            }
        }
    }
}

    //    public void GetDatabaseSchema()
    //    {
    //        using (SqlConnection connection = new SqlConnection(connectionString))
    //        {
    //            connection.Open();
    //            DataTable table = connection.GetSchema("Columns");

    //            // Display the contents of the table.  
    //            DisplayData(table);
    //            //Console.WriteLine(table.Columns.GetType());
                
    //            Console.WriteLine("Press any key to continue.");
    //            Console.ReadKey();

                
    //            connection.Close();
    //        }
    //    }

    //    private static void DisplayData(System.Data.DataTable table)
    //    {
    //        foreach (System.Data.DataRow row in table.Rows)
    //        {
    //            foreach (System.Data.DataColumn col in table.Columns)
    //            {
    //                Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
    //                //Console.WriteLine($"{col.ColumnName} = {col.DefaultValue}");
    //            }
    //            Console.WriteLine("============================");
    //        }
    //    }
    //}




        // using (SqlConnection connection = new SqlConnection(connectionString))

        //            string insertStmt = "INSERT INTO [AChristmasCarol].[WordRefs] (Word, ParagraphIndex, SentenceIndex, WordPositionIndex) VALUES(@word, @paragraph, @sentence, @wordPosition);";
        //// Statements to clear previous run from tables
        //string truncateStmtRefs = "TRUNCATE TABLE [AChristmasCarol].[WordRefs];";
        //string truncateStmtWords = "TRUNCATE TABLE [AChristmasCarol].[UniqueWords];";
        //string truncateStmtParas = "TRUNCATE TABLE [AChristmasCarol].[Paragraphs];";
        //string truncateStmtSents = "TRUNCATE TABLE [AChristmasCarol].[Sentences];";
        //// Statement to build unique word table
        //string uniqueWordStmt = "INSERT INTO [AChristmasCarol].[UniqueWords] SELECT DISTINCT [Word] FROM [AChristmasCarol].[WordRefs];";

        //// Paragraph table insert
        //string paragraphInsertStmt = "INSERT INTO [AChristmasCarol].[Paragraphs] (ParagraphIndex, Paragraph) VALUES(@paragraphIndex, @paragraph);";

        //// Paragraph table insert
        //string sentenceInsertStmt = "INSERT INTO [AChristmasCarol].[Sentences] (ParagraphIndex, SentenceIndex, Sentence) VALUES(@paragraphIndex, @sentenceIndex, @sentence);";

        //            // Set up a command object
        //            using (SqlCommand cmd = new SqlCommand(truncateStmtRefs, connection))
        //            {
        //                connection.Open();

        //                // Execute the truncations
        //                cmd.ExecuteNonQuery();

        //                cmd.CommandText = truncateStmtWords;
        //                cmd.ExecuteNonQuery();

        //                cmd.CommandText = truncateStmtParas;
        //                cmd.ExecuteNonQuery();

        //                cmd.CommandText = truncateStmtSents;
        //                cmd.ExecuteNonQuery();

        //                // Set up the Wordref insertion
        //                cmd.CommandText = insertStmt;



        //               Dictionary<string><SqlDbType> typeMap = new Dictionary<string><SqlDbType>();

        //                typeMap("int") = SqlDblType.Int;

        //               typeMap(typeof property)

        //                // Define parameters
        //                cmd.Parameters.Add("@word", SqlDbType.NVarChar);
        //                cmd.Parameters.Add("@paragraph", SqlDbType.Int);
        //                cmd.Parameters.Add("@sentence", SqlDbType.Int);
        //                cmd.Parameters.Add("@wordPosition", SqlDbType.Int);

        //                // Loop through the Wordref list
        //                foreach (Wordref wdref in anlz.wordRefs)
        //                {
        //                    cmd.Parameters["@word"].Value = wdref.word;
        //                    cmd.Parameters["@paragraph"].Value = wdref.paragraphIndex;
        //                    cmd.Parameters["@sentence"].Value = wdref.sentenceIndex;
        //                    cmd.Parameters["@wordPosition"].Value = wdref.wordPositionIndex;
        //                    cmd.ExecuteNonQuery();
        //                }
    

