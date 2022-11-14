using AdventureWorks.Models.Models;
using AdventureWorks.Web.Api.Client;
using System;
using System.Windows;

namespace AdventureWorks.App
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        int page = 1;
        int pageSize = 20;

        public ProductListWindow()
        {
            InitializeComponent();
            GetProducts();
        }

        private void GetProducts()
        {
            //ProductModel productModel = new ProductModel();
            //ProductData.DataContext = productModel;
            ProductDataGrid.ItemsSource = ProductClient.GetProductsClient(page, pageSize);
        }

        private void GetOneProduct(object sender, RoutedEventArgs e)
        {
            ProductModel selected = ProductDataGrid.SelectedItem as ProductModel;

            var id = selected.ProductID;

            ProductClient.GetOneProductClient(id);
        }

        private void PageSizeSelected(object sender, System.EventArgs e)
        {
            pageSize = Convert.ToInt32(ComboBox.Text);
            ProductDataGrid.ItemsSource = ProductClient.GetProductsClient(page, pageSize);
        }



        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ProductDataGrid.ItemsSource = ProductClient.GetProductsClient(page, pageSize);
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductAddEditWindow productAddEditWindow = new ProductAddEditWindow();
            //var newProduct = ProductDataGrid.DataContext as ProductModel;
            //productAddEditWindow.AddNewProductGrid.DataContext = newProduct;
            productAddEditWindow.addId.IsEnabled = false;
            productAddEditWindow.Show();
        }

        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductAddEditWindow productAddEditWindow = new ProductAddEditWindow();
            var selected = ProductDataGrid.SelectedItem as ProductModel;
            productAddEditWindow.Title = "EditProductWindow";
            productAddEditWindow.addUpdateWindow.Content = "Edit Product Data";
            productAddEditWindow.addUpdateButton.Content = "Update";
            productAddEditWindow.AddNewProductGrid.DataContext = selected;
            productAddEditWindow.Show();
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductModel selected = ProductDataGrid.SelectedItem as ProductModel;

            var id = selected.ProductID;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this record?", "Final Project", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    ProductClient.DeleteProductClient(id);

                    ProductDataGrid.ItemsSource = ProductClient.GetProductsClient(page, pageSize);
                }
                catch
                {
                    MessageBox.Show("Delete cannot process. That employee record is being used elsewhere.", "Final Project", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void PreviousProducts_Click(object sender, RoutedEventArgs e)
        {
            if (page > 1)
            {
                PreviousButton.IsEnabled = true;
                page--;
                ProductDataGrid.ItemsSource = ProductClient.GetProductsClient(page, pageSize);
            }
            else
            {
                PreviousButton.IsEnabled = false;
            }
        }

        private void NextProducts_Click(object sender, RoutedEventArgs e)
        {
            page++;
            if (page > 1)
            {
                PreviousButton.IsEnabled = true;
            }

            if (ProductDataGrid.HasItems == false)
            {
                NextButton.IsEnabled = false;
            }
            else
            {
                ProductDataGrid.ItemsSource = ProductClient.GetProductsClient(page, pageSize);
            }
        }
    }
}
