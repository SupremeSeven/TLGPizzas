using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;


public partial class DatagramTransactionOrderAssemblyItemComponent
{
    public void InsertIntoDB()
    {
        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[Component] (ComponentSKU, Quantity, UnitPrice, Taxable, Description) VALUES(@ComponentSKU, @Quantity, @UnitPrice, @Taxable, @Description);";

            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {
                cmd.Parameters.Add("@ComponentSKU", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Quantity", SqlDbType.Int);
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal);
                cmd.Parameters.Add("@Taxable", SqlDbType.Bit);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar);

                cmd.Parameters["@ComponentSKU"].Value = SKU;
                cmd.Parameters["@Quantity"].Value = Quantity;
                cmd.Parameters["@UnitPrice"].Value = UnitPrice;
                cmd.Parameters["@Taxable"].Value = Taxable;
                cmd.Parameters["@Description"].Value = Description;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

public partial class DatagramTransactionOrderAssemblyItem
{
    public void InsertIntoDB()
    {
        foreach (DatagramTransactionOrderAssemblyItemComponent component in Component)
        {
            component.InsertIntoDB();
        }

        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[Item] (Notes) VALUES(@Notes);";

            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar);

                cmd.Parameters["@Notes"].Value = Notes;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

public partial class DatagramTransactionOrderAssembly
{
    public void InsertIntoDB()
    {
        foreach (DatagramTransactionOrderAssemblyItem item in Item)
        {
            item.InsertIntoDB();
        }

        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[Assembly] (SKU, Description, Quantity, UnitPrice, Taxable) VALUES(@SKU, @Description, @Quantity, @UnitPrice, @Taxable);";

            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {

                cmd.Parameters.Add("@SKU", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Quantity", SqlDbType.Int);
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal);
                cmd.Parameters.Add("@Taxable", SqlDbType.Bit);

                cmd.Parameters["@SKU"].Value = SKU;
                cmd.Parameters["@Description"].Value = Description;
                cmd.Parameters["@Quantity"].Value = Quantity;
                cmd.Parameters["@UnitPrice"].Value = UnitPrice;
                cmd.Parameters["@Taxable"].Value = Taxable;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

public partial class DatagramTransactionOrder
{
    public void InsertIntoDB()
    {
        foreach (DatagramTransactionOrderAssembly assembly in Assembly)
        {
            assembly.InsertIntoDB();
        }
        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[Order] (ReadyTime, ReadyTimeSpecified) VALUES(@ReadyTime, @ReadyTimeSpecified);";

            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {

                cmd.Parameters.Add("@ReadyTime", SqlDbType.DateTime);
                cmd.Parameters.Add("@ReadyTimeSpecified", SqlDbType.Bit);

                cmd.Parameters["@ReadyTime"].Value = ReadyTime;
                cmd.Parameters["@ReadyTimeSpecified"].Value = ReadyTimeSpecified;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

public partial class DatagramTransactionCustomerAddress
{
    public void InsertIntoDB()
    {
        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[Address] (Type, AddressLine1, AddressLine2, City, State, PostalCode, MobileTelephone, AlternateTelephone, Notes) VALUES(@Type, @AddressLine1, @AddressLine2, @City, @State, @PostalCode, @MobileTelephone, @AlternateTelephone, @Notes);";

            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {

                cmd.Parameters.Add("@Type", SqlDbType.Int);
                cmd.Parameters.Add("@AddressLine1", SqlDbType.NVarChar);
                cmd.Parameters.Add("@AddressLine2", SqlDbType.NVarChar);
                cmd.Parameters.Add("@City", SqlDbType.NVarChar);
                cmd.Parameters.Add("@State", SqlDbType.NVarChar);
                cmd.Parameters.Add("@PostalCode", SqlDbType.Int);
                cmd.Parameters.Add("@MobileTelephone", SqlDbType.Int);
                cmd.Parameters.Add("@AlternateTelephone", SqlDbType.Int);
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar);

                cmd.Parameters["@Type"].Value = Type;
                cmd.Parameters["@AddressLine1"].Value = AddressLine1;
                cmd.Parameters["@AddressLine2"].Value = AddressLine2;
                cmd.Parameters["@City"].Value = City;
                cmd.Parameters["@State"].Value = StateProvince;
                cmd.Parameters["@PostalCode"].Value = Int32.Parse(PostalCode);
                cmd.Parameters["@MobileTelephone"].Value = Int32.Parse(MobileTelephone);
                cmd.Parameters["@AlternateTelephone"].Value = Int32.Parse(AlternateTelephone);
                cmd.Parameters["@Notes"].Value = Notes;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

public partial class DatagramTransactionCustomer
{
    public void InsertIntoDB()
    {

        foreach (DatagramTransactionCustomerAddress address in Address)
        {
            address.InsertIntoDB();
        }

        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[Customer] (Language, LastName, FirstName, Notes) VALUES(@Language, @LastName, @FirstName, @Notes);";

            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {

                cmd.Parameters.Add("@Language", SqlDbType.NVarChar);
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar);
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar);

                cmd.Parameters["@Language"].Value = Language;
                cmd.Parameters["@LastName"].Value = Name.Split(' ')[1];
                cmd.Parameters["@FirstName"].Value = Name.Split(' ')[0];
                cmd.Parameters["@Notes"].Value = Notes;

                connection.Open();
                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}

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
                cmd.CommandText = insertStmt;

                cmd.Parameters.Add("@amount", SqlDbType.Decimal);
                cmd.Parameters.Add("@dueDate", SqlDbType.DateTime);
                cmd.Parameters.Add("@dueDateSpecified", SqlDbType.Bit);

                cmd.Parameters["@amount"].Value = Amount;
                cmd.Parameters["@dueDate"].Value = DueDate;
                cmd.Parameters["@dueDateSpecified"].Value = DueDateSpecified;

                connection.Open();
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
            string insertStmt = "INSERT INTO [TLGPizza].[Prepayment] (Amount, DatePaid, AuthorizationCode) VALUES(@amount, @datePaid, @authorizationCode);";
            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {
                cmd.CommandText = insertStmt;

                cmd.Parameters.Add("@amount", SqlDbType.Decimal);
                cmd.Parameters.Add("@datePaid", SqlDbType.DateTime);
                cmd.Parameters.Add("@authorizationCode", SqlDbType.VarChar);

                cmd.Parameters["@amount"].Value = Amount;
                cmd.Parameters["@datePaid"].Value = DatePaid;
                cmd.Parameters["@authorizationCode"].Value = AuthorizationCode;

                connection.Open();
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
                cmd.CommandText = insertStmt;

                cmd.Parameters.Add("@amount", SqlDbType.Decimal);
                cmd.Parameters.Add("@rate", SqlDbType.Decimal);
                cmd.Parameters.Add("@jurisdiction", SqlDbType.VarChar);

                cmd.Parameters["@amount"].Value = Amount;
                cmd.Parameters["@rate"].Value = Rate;
                cmd.Parameters["@jurisdiction"].Value = Jurisdiction;

                connection.Open();
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
                cmd.CommandText = insertStmt;

                cmd.Parameters.Add("@amount", SqlDbType.Decimal);
                cmd.Parameters.Add("@rate", SqlDbType.Decimal);
                cmd.Parameters.Add("@jurisdiction", SqlDbType.VarChar);

                cmd.Parameters["@amount"].Value = Amount;
                cmd.Parameters["@rate"].Value = Rate;
                cmd.Parameters["@jurisdiction"].Value = Jurisdiction;

                connection.Open();
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
        foreach (DatagramTransactionPaymentSalesTax tax in SalesTax)
        {
            tax.InsertIntoDB();
        }
        foreach (DatagramTransactionPaymentVAT vAT in VAT)
        {
            vAT.InsertIntoDB();
        }
        foreach (DatagramTransactionPaymentPrepayment prepayment in Prepayment)
        {
            prepayment.InsertIntoDB();
        }
        PaymentDue.InsertIntoDB();

        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[Payment] (PurchaseTotal, Notes) VALUES(@purchaseTotal, @notes);";
            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {
                cmd.CommandText = insertStmt;

                cmd.Parameters.Add("@purchaseTotal", SqlDbType.Decimal);
                cmd.Parameters.Add("@notes", SqlDbType.VarChar);

                cmd.Parameters["@purchaseTotal"].Value = PurchaseTotal.Amount;
                cmd.Parameters["@notes"].Value = Notes;

                connection.Open();
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
            string insertStmt = "INSERT INTO [TLGPizza].[Transaction] (TransactionId, CustomerId, TimeStamp) VALUES(@transactionId, @customerId, @timeStamp);";
            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {
                cmd.CommandText = insertStmt;

                cmd.Parameters.Add("@transactionId", SqlDbType.Int);
                cmd.Parameters.Add("@customerId", SqlDbType.Int);
                cmd.Parameters.Add("@timeStamp", SqlDbType.DateTime);

                cmd.Parameters["@transactionId"].Value = Id;
                cmd.Parameters["@customerId"].Value = Customer.Id;
                cmd.Parameters["@timeStamp"].Value = Timestamp;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        Customer.InsertIntoDB();
        Order.InsertIntoDB();
        Payment.InsertIntoDB();
    }
}

public partial class Datagram
{
    public void InsertIntoDB()
    {
        string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=TLGPizza;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertStmt = "INSERT INTO [TLGPizza].[Datagram] (DatagramId, TransactionId, TimeStamp) VALUES(@id, @transactionId, @timeStamp);";
            using (SqlCommand cmd = new SqlCommand(insertStmt, connection))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@transactionId", SqlDbType.Int);
                cmd.Parameters.Add("@timeStamp", SqlDbType.DateTime);

                cmd.Parameters["@id"].Value = Int32.Parse(Id);
                cmd.Parameters["@transactionId"].Value = Int32.Parse(Transaction.Id);
                cmd.Parameters["@timeStamp"].Value = Timestamp;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        Transaction.InsertIntoDB();
    }
}
