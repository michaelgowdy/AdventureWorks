using AdventureWorks.Models.Models;
using AdventureWorks.Web.Api.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

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



        private void LoadProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductDataGrid.ItemsSource = ProductClient.GetProductsClient(page, pageSize);
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductAddEditWindow productAddEditWindow = new ProductAddEditWindow();
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

            ProductClient.DeleteProductClient(id);

            GetProducts();
        }

        private void PreviousProducts_Click(object sender, RoutedEventArgs e)
        {
            if (page > 1)
            {
                previousButton.IsEnabled = true;
                page--;
                ProductDataGrid.ItemsSource = ProductClient.GetProductsClient(page, pageSize);
            }
            else
            {
                previousButton.IsEnabled = false;
            }
        }

        private void NextProducts_Click(object sender, RoutedEventArgs e)
        {
            if (page > 1)
            {
                previousButton.IsEnabled = true;
            }

            if (ProductDataGrid.ToString() == "")
            {
                nextButton.IsEnabled = false;
            }
            else
            {
                page++;
                ProductDataGrid.ItemsSource = ProductClient.GetProductsClient(page, pageSize);
            }
        }
    }
}
