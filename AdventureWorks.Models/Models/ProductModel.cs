using LinqToDB.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AdventureWorks.Models.Models
{
    [Table(Schema = "Production", Name = "Product")]
    public class ProductModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private readonly Dictionary<string, string> _propertyErrors = new Dictionary<string, string>();

        public string this[string columnName] => this._propertyErrors.TryGetValue(columnName, out var error) ? error : null;

        public string Error => null;

        public event PropertyChangedEventHandler PropertyChanged;


        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }

        private void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, errorMessage);
            }
            else
            {
                _propertyErrors[propertyName] = errorMessage;
            }

            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ProductModel()
        {
            this.Validate();
        }

        private int _productId;
        private string _name;
        private string _productNumber;
        private string _color;
        private string _size;
        private double? _listPrice;
        private Guid _rowguid;


        [Column(Name = "ProductID")]
        public int ProductID
        {
            get { return _productId; }
            set
            {
                _productId = value;
                OnPropertyChanged(nameof(ProductID));
            }
        }

        [Column(Name = "Name")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;

                Validate();

                OnPropertyChanged(nameof(Name));
            }
        }


        [Column(Name = "ProductNumber")]
        public string ProductNumber
        {
            get { return _productNumber; }
            set
            {
                _productNumber = value;

                Validate();

                OnPropertyChanged(nameof(ProductNumber));
            }
        }

        [Column(Name = "Color")]
        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged(nameof(Color));
            }
        }


        [Column(Name = "Size")]
        public string Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Size));
            }
        }


        [Column(Name = "ListPrice")]
        public double? ListPrice
        {
            get { return _listPrice; }
            set
            {
                _listPrice = value;
                this.Validate();
                OnPropertyChanged(nameof(ListPrice));
            }
        }


        [Column(Name = "rowguid")]
        public Guid rowguid
        {
            get { return _rowguid; }
            set
            {
                _rowguid = value;
                OnPropertyChanged(nameof(rowguid));
            }
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                AddError(nameof(Name), "This field is required.");
            }
            else
            {
                ClearError(nameof(Name));
            }

            if (string.IsNullOrWhiteSpace(_productNumber))
            {
                AddError(nameof(ProductNumber), "This field is required.");
            }
            else
            {
                ClearError(nameof(ProductNumber));
            }

            if (_listPrice == null)
            {
                AddError(nameof(ListPrice), "This field is required");
            }
            else
            {
                ClearError(nameof(ListPrice));
            }
        }

        private void ClearError(string propertyName)
        {
            if (_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Remove(propertyName);
            }
        }
    }
}
