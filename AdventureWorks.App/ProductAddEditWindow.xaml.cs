﻿using AdventureWorks.Models.Models;
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
            InitializeComponent();
        }

        private void AddProduct()
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
            //try
            //{
            //    ProductModel newProduct = new ProductModel
            //    {
            //        Name = addName.Text,
            //        ProductNumber = addNumber.Text,
            //        Color = addColor.Text,
            //        Size = addSize.Text,
            //        ListPrice = Convert.ToDouble(addPrice.Text)
            //    };

            //    ProductClient.AddProductClient(newProduct);
            //}
            //catch (Exception e)
            //{

            //    addSize.Text = e.Message;
            //}


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

            ProductClient.UpdateProductClient(newProduct);
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (Title == "AddProductWindow")
            {
                AddProduct();
                ProductAddEditWindow productAddEditWindow = new ProductAddEditWindow();
                productAddEditWindow.Close();
            }
            else
            {
                UpdateProduct();
            };
        }
    }
}
