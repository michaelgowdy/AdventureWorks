using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AdventureWorks.Models.Models
{
    public class CreateProductCommand : ICommand
    {
        private readonly ProductModel _productModel;

        public event EventHandler CanExecuteChanged;

        public CreateProductCommand(ProductModel productModel)
        {
            _productModel = productModel;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        { 
            Console.WriteLine($"Successfully created '{_productModel.Name}'.");
        }
    }
}
