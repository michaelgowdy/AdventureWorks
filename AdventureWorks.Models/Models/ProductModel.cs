using LinqToDB.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace AdventureWorks.Models.Models
{
    [Table(Schema = "Production", Name = "Product")]
    public class ProductModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private readonly Dictionary<string, string> _propertyErrors = new Dictionary<string, string>();

        public string this[string columnName] => this._propertyErrors.TryGetValue(columnName, out var error) ? error : null; 

        public ProductModel()
        {
            this.Validate();
        }

        public string Error => null;
        //private readonly ErrorsViewModel _errors;

        //public bool HasErrors => _errors.HasErrors;
        //
        //public bool CanCreate => !HasErrors;

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }

        public void AddError(string propertyName, string errorMessage)
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

        public void ClearError(string propertyName)
        {
            if (_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Remove(propertyName);
            }
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private int _productId;

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


        private string _name;

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


        private string _productNumber;

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


        private string _color;

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


        private string _size;

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


        private decimal? _listPrice;

        [Column(Name = "ListPrice")]
        public decimal? ListPrice
        {
            get { return _listPrice; }
            set
            {
                _listPrice = value;
                Validate();
                OnPropertyChanged(nameof(ListPrice));
            }
        }


        private Guid _rowguid;

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
            if (string.IsNullOrWhiteSpace(_productNumber))
            {
                AddError(nameof(ProductNumber), "Product Number is required.");
                //_errors.AddError(nameof(ProductNumber), "This field is required.");
            }
            else
            {
                ClearError(nameof(ProductNumber));
                //_errors.ClearErrors(nameof(ProductNumber));
            }

            if (_listPrice == null)
            {
                AddError(nameof(ListPrice), "List Price is requried");
                //_errors.AddError(nameof(ListPrice), "This field is required");
            }
            else
            {
                ClearError(nameof(ListPrice));
                //_errors.ClearErrors(nameof(ListPrice));
            }
        }
    }
}
