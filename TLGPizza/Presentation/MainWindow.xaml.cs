using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string constring = ConfigurationManager.ConnectionStrings
          ["Connection_String"].ConnectionString;

        SqlConnection con;
        public MainWindow()
        {
            InitializeComponent();
            con = new SqlConnection(constring);

            List<string> Store = new List<string> { "testStore1", "testStore2", "testStore3" };
            StoreList.ItemsSource = Store;
        }

        //    string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS; 
        //Initial Catalog=TestDatabase; Integrated Security=True;";
        //        using (SqlConnection connection = 
        //new SqlConnection(connectionString))
        //        {
        //            string truncateTransactions = "TRUNCATE TABLE [Test].[Transactions];";
        //string truncateStores = "TRUNCATE TABLE [Test].[Stores];";

        //            using (SqlCommand cmd = new SqlCommand(truncateTransactions, connection))
        //            {
        //                connection.Open();

        //                cmd.ExecuteNonQuery();

        //                cmd.CommandText = truncateStores;
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("foo");
        }

        private void TestConnection_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            MessageBox.Show("Connected");
            con.Close();
        }

    }
}
