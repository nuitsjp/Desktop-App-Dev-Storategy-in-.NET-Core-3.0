using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MigrationDemo.Repository;

namespace MigrationDemo.App
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public ObservableCollection<SalesOrderDetail> SalesOrderDetails { get; } = new ObservableCollection<SalesOrderDetail>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var connection =
                new SqlConnection("Data Source=localhost;Initial Catalog=AdventureWorks2017;Integrated Security=True;"))
            {
                connection.Open();
                foreach (var salesOrderDetail in SalesOrderDetailRepository.GetSalesOrderDetail(connection))
                {
                    SalesOrderDetails.Add(salesOrderDetail);
                }
            }
        }
    }
}
