using AdventureWorks.Models.Models;
using AdventureWorks.Web.Api.Client;
using System;
using System.Windows;

namespace AdventureWorks.App
{
    /// <summary>
    /// Interaction logic for ProductAddEditWindow.xaml
    /// </summary>
    public partial class ProductAddEditWindow : Window
    {

        public ProductAddEditWindow()
        {
            //ProductModel productModel = new ProductModel();
            //AddNewProductGrid.DataContext = new ProductClient();
            InitializeComponent();
        }

        private void AddProduct()
        {
            if (addName.Text == "")
            {
                addUpdateButton.IsEnabled = false;
            }

            try
            {
                ProductModel newProduct = new ProductModel
                {
                    Name = addName.Text,
                    ProductNumber = addNumber.Text,
                    Color = addColor.Text,
                    Size = addSize.Text,
                    ListPrice = Convert.ToDouble(addPrice.Text)
                };

                ProductClient.AddProductClient(newProduct);
            }
            catch (Exception e)
            {

                addSize.Text = e.Message;
            }
            

            //if (Title == "AddProductWindow")
            //{
                
            //}
            //else
            //{
            //    newProduct.ProductID = Convert.ToInt32(addId.Text);
            //}
        }

        private void UpdateProduct()
        {
            ProductModel newProduct = new ProductModel
            {
                ProductID = Convert.ToInt32(addId.Text),
                Name = addName.Text,
                ProductNumber = addNumber.Text,
                Color = addColor.Text,
                Size = addSize.Text,
                ListPrice = Convert.ToDouble(addPrice.Text)
            };
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (Title == "AddProductWindow")
            {
                AddProduct();
            }
            else
            {
                UpdateProduct();
            };
        }
    }
}
