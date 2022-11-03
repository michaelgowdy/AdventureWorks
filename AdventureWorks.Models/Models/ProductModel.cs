using LinqToDB.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AdventureWorks.Models.Models
{
    [Table(Schema = "Production", Name = "Product")]
    public class ProductModel : INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();

        //[Column(Name = "ProductID")] public int ProductID { get; set; }
        //[Column(Name = "Name")] public string Name { get; set; }
        //[Column(Name = "ProductNumber")] public string ProductNumber { get; set; }
        //[Column(Name = "Color")] public string Color { get; set; }
        //[Column(Name = "Size")] public string Size { get; set; }
        //[Column(Name = "ListPrice")] public double ListPrice { get; set; }
        //[Column(Name = "rowguid")] public Guid rowguid { get; set; }

        

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _productId;
        private string _name;
        private string _productNumber;
        private string _color;
        private string _size;
        private double _listPrice;
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

                if (_name.Length < 1)
                {
                    AddError(nameof(Name), "This field is required.");
                }

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

                if (_productNumber.Length < 1)
                {
                    AddError(nameof(ProductNumber), "This field is required.");
                }

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
        public double ListPrice
        {
            get { return _listPrice; }
            set
            {
                _listPrice = value;

                if (_listPrice == null)
                {
                    AddError(nameof(ListPrice), "This field is required");
                }

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


        public bool HasErrors => _propertyErrors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }

        private void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }

            _propertyErrors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
