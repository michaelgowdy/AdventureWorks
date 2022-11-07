using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using LinqToDB.Mapping;

namespace AdventureWorks.Models.Models
{
    [Table(Schema ="Sales", Name ="SalesOrderHeader")]
    public class SalesOrderHeaderModel : IDataErrorInfo, INotifyPropertyChanged
    {
        //[Column(Name ="SalesOrderID")] public int SalesOrderID { get; set; }
        //[Column(Name ="OrderDate")]public DateTime OrderDate { get; set; }
        //[Column(Name ="BillToAddressID")]public int BillToAddressID { get; set; }
        //[Column(Name ="ShipToAddressID")]public int ShipToAddressID { get; set; }
        //[Column(Name ="TotalDue")] public double TotalDue { get; set; }

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

        public SalesOrderHeaderModel()
        {
            this.Validate();
        }


        [Column(Name = "SalesOrderID")]
        private int? _salesOrderId;

        public int? SalesOrderID
        {
            get { return _salesOrderId; }
            set 
            { 
                _salesOrderId = value;

                Validate();

                OnPropertyChanged(nameof(SalesOrderID));
            }
        }

        [Column(Name = "OrderDate")]
        private DateTime _orderDate;

        public DateTime OrderDate
        {
            get { return _orderDate; }
            set
            {
                _orderDate = value;

                Validate();

                OnPropertyChanged(nameof(OrderDate));
            }
        }

        [Column(Name = "BillToAddressID")]
        private int? _billToAddressId;

        public int? BillToAddressID
        {
            get { return _billToAddressId; }
            set 
            {
                _billToAddressId = value;

                Validate();

                OnPropertyChanged(nameof(BillToAddressID));
            }
        }

        [Column(Name = "ShipToAddressID")]
        private int? _shipToAddressId;

        public int? ShipToAddressID
        {
            get { return _shipToAddressId; }
            set
            {
                _shipToAddressId = value;

                Validate();

                OnPropertyChanged(nameof(ShipToAddressID));
            }
        }

        [Column(Name = "TotalDue")]
        private double? _totalDue;

        public double? TotalDue
        {
            get { return _totalDue; }
            set
            {
                _totalDue = value;

                Validate();

                OnPropertyChanged(nameof(TotalDue));
            }
        }


        private void Validate()
        {
            if (_salesOrderId == null)
            {
                AddError(nameof(SalesOrderID), "This field is required.");
            }
            else
            {
                ClearError(nameof(SalesOrderID));
            }

            if (_orderDate == null)
            {
                AddError(nameof(OrderDate), "This field is required.");
            }
            else
            {
                ClearError(nameof(OrderDate));
            }

            if (_billToAddressId == null)
            {
                AddError(nameof(BillToAddressID), "This field is required.");
            }
            else
            {
                ClearError(nameof(BillToAddressID));
            }

            if (_shipToAddressId == null)
            {
                AddError(nameof(ShipToAddressID), "This field is required.");
            }
            else
            {
                ClearError(nameof(ShipToAddressID));
            }

            if (_totalDue == null)
            {
                AddError(nameof(TotalDue), "This field is required.");
            }
            else
            {
                ClearError(nameof(TotalDue));
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
