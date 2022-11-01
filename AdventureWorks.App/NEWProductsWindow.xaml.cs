using AdventureWorks.Models.Models;
using AdventureWorks.Web.Api.Client;
using System;
using System.Linq;
using System.Windows;

namespace AdventureWorks.App
{
    /// <summary>
    /// Interaction logic for NEWProductsWindow.xaml
    /// </summary>
    public partial class NEWProductsWindow : Window
    {
        public NEWProductsWindow()
        {
            InitializeComponent();
            GetProducts();
        }

        public void GetProducts()
        {
            ProductModel productModel = new ProductModel();
            ProductDataGrid.DataContext = productModel;
            ProductDataGrid.ItemsSource = ProductClient.GetProductsClient(1, 10).ToList();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            int selected = Convert.ToInt32(ComboBox.SelectionBoxItem);
            ProductDataGrid.ItemsSource = ProductClient.GetProductsClient(2, selected);
        }
    }
}
