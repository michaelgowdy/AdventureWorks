using LinqToDB.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;

namespace AdventureWorks.Models.Models
{
    [Table(Schema = "Sales", Name = "SalesOrderHeader")]
    public class SalesOrderHeaderModel : IDataErrorInfo, INotifyPropertyChanged
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

        public SalesOrderHeaderModel()
        {
            this.Validate();
        }


        //[Column(Name = "SalesOrderID")] public int SalesOrderID { get; set; }
        [Column(Name = "OrderDate")] public DateTime OrderDate { get; set; }
        //[Column(Name = "BillToAddressID")] public int BillToAddressID { get; set; }
        [Column(Name = "ShipToAddressID")] public int ShipToAddressID { get; set; }
        [Column(Name = "TotalDue")] public double TotalDue { get; set; }
        [Column(Name = "SalesOrderNumber")] public string SalesOrderNumber { get; set; }
        [Column(Name = "SubTotal")] public double SubTotal { get; set; }
        [Column(Name = "TaxAmt")] public double TaxAmt { get; set; }
        [Column(Name = "Freight")] public double Freight { get; set; }


        private int _salesOrderId;

        [Column(Name = "SalesOrderID")]
        public int SalesOrderID
        {
            get { return _salesOrderId; }
            set { _salesOrderId = value; }
        }


        private int? _billToAddressId;

        [Column(Name = "BillToAddressID")]
        public int? BillToAddressID
        {
            get { return _billToAddressId; }
            set 
            {
                _billToAddressId = value;
                OnPropertyChanged(nameof(BillToAddressID));
            }
        }



        private void Validate()
        {
            if (_billToAddressId == null)
            {
                AddError(nameof(BillToAddressID), "This field is required.");
            }
            else
            {
                ClearError(nameof(BillToAddressID));
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
