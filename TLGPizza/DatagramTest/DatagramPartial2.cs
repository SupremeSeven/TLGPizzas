using System;
using System.Data;
using System.Data.SqlClient;

public partial class DatagramTransactionPaymentPaymentDue
{
    public void InsertIntoDB()
    {
        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[PaymentDue] (Amount, DueDate, DueDateSpecified) VALUES(@amount, @dueDate, @dueDateSpecified);";
            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = insertStmt;

                cmd.Parameters.Add("@amount", SqlDbType.Decimal);
                cmd.Parameters.Add("@dueDate", SqlDbType.DateTime);
                cmd.Parameters.Add("@dueDateSpecified", SqlDbType.DateTime);

                cmd.Parameters["@amount"].Value = Amount;
                cmd.Parameters["@dueDate"].Value = DueDate;
                cmd.Parameters["@dueDateSpecified"].Value = DueDateSpecified;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

public partial class DatagramTransactionPaymentPrepayment
{
    public void InsertIntoDB()
    {
        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[Prepayment] (Amount, DatePaid, TransactionId, AuthorizationCode) VALUES(@amount, @datePaid, @transactionId, @authorizationCode);";
            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = insertStmt;

                cmd.Parameters.Add("@amount", SqlDbType.Decimal);
                cmd.Parameters.Add("@datePaid", SqlDbType.DateTime);
                cmd.Parameters.Add("@transactionId", SqlDbType.Int);
                cmd.Parameters.Add("@authorizationCode", SqlDbType.VarChar);

                cmd.Parameters["@amount"].Value = Amount;
                cmd.Parameters["@datePaid"].Value = DatePaid;
                cmd.Parameters["@transactionId"].Value = TransactionId;
                cmd.Parameters["@authorizationCode"].Value = AuthorizationCode;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

public partial class DatagramTransactionPaymentVAT
{
    public void InsertIntoDB()
    {
        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[Tax] (Amount, Rate, Jurisdiction) VALUES(@amount, @rate, @jurisdiction);";
            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = insertStmt;

                cmd.Parameters.Add("@amount", SqlDbType.Decimal);
                cmd.Parameters.Add("@rate", SqlDbType.Decimal);
                cmd.Parameters.Add("@juristiction", SqlDbType.VarChar);

                cmd.Parameters["@amount"].Value = Amount;
                cmd.Parameters["@rate"].Value = Rate;
                cmd.Parameters["@juristiction"].Value = Jurisdiction;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

public partial class DatagramTransactionPaymentSalesTax
{
    public void InsertIntoDB()
    {
        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[Tax] (Amount, Rate, Jurisdiction) VALUES(@amount, @rate, @jurisdiction);";
            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = insertStmt;

                cmd.Parameters.Add("@amount", SqlDbType.Decimal);
                cmd.Parameters.Add("@rate", SqlDbType.Decimal);
                cmd.Parameters.Add("@juristiction", SqlDbType.VarChar);

                cmd.Parameters["@amount"].Value = Amount;
                cmd.Parameters["@rate"].Value = Rate;
                cmd.Parameters["@juristiction"].Value = Jurisdiction;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

public partial class DatagramTransactionPayment
{
    public void InsertIntoDB()
    {
        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[Payment] (PurchaseTotal, Notes) VALUES(@purchaseTotal, @notes);";
            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = insertStmt;

                cmd.Parameters.Add("@purchaseTotal", SqlDbType.Decimal);
                cmd.Parameters.Add("@notes", SqlDbType.VarChar);

                cmd.Parameters["@purchaseTotal"].Value = PurchaseTotal.Amount;
                cmd.Parameters["@notes"].Value = Notes;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

public partial class DatagramTransaction
{
    public void InsertIntoDB()
    {
        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[Transaction] (TimeStamp) VALUES(@timeStamp);";
            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = insertStmt;

                cmd.Parameters.Add("@timeStamp", SqlDbType.DateTime);

                cmd.Parameters["@purchaseTotal"].Value = Timestamp;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

public partial class Datagram
{
    public void InsertIntoDB()
    {
        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[Datagram] (TimeStamp) VALUES(@timeStamp);";
            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = insertStmt;

                cmd.Parameters.Add("@timeStamp", SqlDbType.DateTime);

                cmd.Parameters["@purchaseTotal"].Value = Timestamp;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
