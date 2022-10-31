using AdventureWorks.Models.Models;
using AdventureWorks.Web.Api.Client;
using System.Windows;

namespace AdventureWorks.App
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        int page = 1;

        public ProductListWindow()
        {
            InitializeComponent();
            GetProducts();
        }

        private void GetProducts()
        {
            ProductData.ItemsSource = ProductClient.GetProductsClient(page);
        }

        private void GetOneProduct(object sender, RoutedEventArgs e)
        {
            ProductModel selected = ProductData.SelectedItem as ProductModel;

            var id = selected.ProductID;

            ProductClient.GetOneProductClient(id);
        }

        private void LoadProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductData.ItemsSource = ProductClient.GetProductsClient(page);
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var selected = ProductData.SelectedItem as ProductModel;
            ProductAddEditWindow productAddEditWindow = new ProductAddEditWindow();
            productAddEditWindow.UpdateProductGrid.DataContext = selected;
            productAddEditWindow.Show();
        }

        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            var selected = ProductData.SelectedItem as ProductModel;
            ProductAddEditWindow productAddEditWindow = new ProductAddEditWindow();
            productAddEditWindow.UpdateProductGrid.DataContext = selected;
            productAddEditWindow.Show();
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductModel selected = ProductData.SelectedItem as ProductModel;

            var id = selected.ProductID;

            ProductClient.DeleteProductClient(id);
            
            GetProducts();
        }

        private void PreviousProducts_Click(object sender, RoutedEventArgs e)
        {
            if (page > 1)
            {
                previousButton.IsEnabled = true;
                page--;
                ProductData.ItemsSource = ProductClient.GetProductsClient(page);
            }
            else
            {
                previousButton.IsEnabled = false;
            }
        }

        private void NextProducts_Click(object sender, RoutedEventArgs e)
        {
            page++;

            if (page > 1)
            {
                previousButton.IsEnabled = true;
            }
            
            ProductData.ItemsSource = ProductClient.GetProductsClient(page);

            if (!ProductData.HasItems)
            {
                nextButton.IsEnabled = false;
            }
        }
    }
}
