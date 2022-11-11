using LinqToDB.Mapping;
using System;
using System.Collections;
using System.ComponentModel;

namespace AdventureWorks.Models.Models
{
    [Table(Schema = "Production", Name = "Product")]
    public class NEWProductModel : ModelBase, INotifyDataErrorInfo
    {
        private readonly ErrorsViewModel _errorsViewModel;

        public NEWProductModel()
        {
            this.Validate();
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


        private double? _listPrice;

        [Column(Name = "ListPrice")]
        public double? ListPrice
        {
            get { return _listPrice; }
            set
            {
                _listPrice = value;
                Validate();
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
            if (string.IsNullOrWhiteSpace(_productNumber))
            {
                _errorsViewModel.AddError(nameof(ProductNumber), "This field is required.");
            }
            else
            {
                _errorsViewModel.ClearErrors(nameof(ProductNumber));
            }

            if (_listPrice == null)
            {
                _errorsViewModel.AddError(nameof(ListPrice), "This field is required");
            }
            else
            {
                _errorsViewModel.ClearErrors(nameof(ListPrice));
            }
        }

        private Guid _rowguid;

        public bool CanCreate => !HasErrors;

        public bool HasErrors => _errorsViewModel.HasErrors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsViewModel.GetErrors(propertyName);
        }

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(CanCreate));
        }
    }

}
