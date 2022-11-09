using LinqToDB.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace AdventureWorks.Models.Models
{
    [Table(Schema = "Sales", Name = "SalesOrderHeader")]
    public class SalesOrderHeaderModel //: IDataErrorInfo, INotifyPropertyChanged
    {
        [Column(Name = "SalesOrderID")] 
        [Required]
        public int SalesOrderID { get; set; }

        [Column(Name = "OrderDate")]
        [Required]
        public DateTime OrderDate { get; set; }

        [Column(Name = "BillToAddressID")]
        [Required]
        public int BillToAddressID { get; set; }

        [Column(Name = "ShipToAddressID")]
        [Required]
        public int ShipToAddressID { get; set; }

        [Column(Name = "TotalDue")]
        [Required]
        public double TotalDue { get; set; }

        [Column(Name = "SalesOrderNumber")]
        [Required]
        [StringLength(10, ErrorMessage = "Number is too long.")]
        public string SalesOrderNumber { get; set; }

        [Column(Name = "SubTotal")]
        [Required]
        public double SubTotal { get; set; }

        [Column(Name = "TaxAmt")]
        [Required]
        public double TaxAmt { get; set; }

        [Column(Name = "Freight")]
        [Required]
        public double Freight { get; set; }



        //private readonly Dictionary<string, string> _propertyErrors = new Dictionary<string, string>();

        //public string this[string columnName] => this._propertyErrors.TryGetValue(columnName, out var error) ? error : null;

        //public string Error => null;

        //public event PropertyChangedEventHandler PropertyChanged;


        //public IEnumerable GetErrors(string propertyName)
        //{
        //    return _propertyErrors.GetValueOrDefault(propertyName, null);
        //}

        //private void AddError(string propertyName, string errorMessage)
        //{
        //    if (!_propertyErrors.ContainsKey(propertyName))
        //    {
        //        _propertyErrors.Add(propertyName, errorMessage);
        //    }
        //    else
        //    {
        //        _propertyErrors[propertyName] = errorMessage;
        //    }

        //    OnPropertyChanged(propertyName);
        //}

        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //public SalesOrderHeaderModel()
        //{
        //    this.Validate();
        //}

        //private int _salesOrderId;

        //[Column(Name = "SalesOrderID")]
        //public int SalesOrderID
        //{
        //    get { return _salesOrderId; }
        //    set { _salesOrderId = value; }
        //}


        //private DateTime _orderDate;

        //[Column(Name = "OrderDate")]
        //public DateTime OrderDate
        //{
        //    get { return _orderDate; }
        //    set { _orderDate = value; }
        //}


        //private int? _billToAddressId;

        //[Column(Name = "BillToAddressID")]
        //public int? BillToAddressID
        //{
        //    get { return _billToAddressId; }
        //    set 
        //    {
        //        _billToAddressId = value;
        //        Validate();
        //        OnPropertyChanged(nameof(BillToAddressID));
        //    }
        //}


        //private int _shipToAddressId;

        //[Column(Name = "ShipToAddressID")]
        //public int ShipToAddressID
        //{
        //    get { return _shipToAddressId; }
        //    set { _shipToAddressId = value; }
        //}


        //private double _totalDue;

        //[Column(Name = "TotalDue")]
        //public double TotalDue
        //{
        //    get { return _totalDue; }
        //    set { _totalDue = value; }
        //}


        //private string _salesOrderNumber;

        //[Column(Name = "SalesOrderNumber")]
        //public string SalesOrderNumber
        //{
        //    get { return _salesOrderNumber; }
        //    set { _salesOrderNumber = value; }
        //}


        //private double _subTotal;

        //[Column(Name = "SubTotal")]
        //public double SubTotal
        //{
        //    get { return _subTotal; }
        //    set { _subTotal = value; }
        //}


        //private double _taxAmt;

        //[Column(Name = "TaxAmt")]
        //public double TaxAmt
        //{
        //    get { return _taxAmt; }
        //    set { _taxAmt = value; }
        //}


        //private double _freight;

        //[Column(Name = "Freight")]
        //public double Freight
        //{
        //    get { return _freight; }
        //    set { _freight = value; }
        //}



        //private void Validate()
        //{
        //    if (_billToAddressId == null)
        //    {
        //        AddError(nameof(BillToAddressID), "This field is required.");
        //    }
        //    else
        //    {
        //        ClearError(nameof(BillToAddressID));
        //    }
        //}

        //private void ClearError(string propertyName)
        //{
        //    if (_propertyErrors.ContainsKey(propertyName))
        //    {
        //        _propertyErrors.Remove(propertyName);
        //    }
        //}
    }
}
