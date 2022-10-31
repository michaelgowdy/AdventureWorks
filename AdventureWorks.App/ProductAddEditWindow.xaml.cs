using AdventureWorks.Models.Models;
using AdventureWorks.Web.Api.Client;
using System;
using System.Threading;
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
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var name = addName.Text;
            var number = addNumber.Text;
            var color = addColor.Text;
            var size = addSize.Text;
            var price = Convert.ToDouble(addPrice.Text);

            ProductModel newProduct = new ProductModel
            {
                Name = name,
                ProductNumber = number,
                Color = color,
                Size = size,
                ListPrice = price
            };

            ProductClient.AddProductClient(newProduct);

            productAdded.Visibility = Visibility.Visible;
            addName.Clear();
        }

        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            var id = Convert.ToInt32(updateId.Text);
            var name = updateName.Text;
            var number = updateNumber.Text;
            var color = updateColor.Text;
            var size = updateSize.Text;
            var price = Convert.ToDouble(updatePrice.Text);

            ProductModel newProduct = new ProductModel
            {
                ProductID = id,
                Name = name,
                ProductNumber = number,
                Color = color,
                Size = size,
                ListPrice = price
            };

            ProductClient.UpdateProductClient(newProduct);
            productUpdated.Visibility = Visibility.Visible;
        }
    }
}
