using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using LinqToDB.Mapping;

namespace AdventureWorks.Models.Models
{
    [Table(Schema ="Sales", Name ="SalesOrderHeader")]
    public class SalesOrderHeaderModel //: IDataErrorInfo, INotifyPropertyChanged
    {
        [Column(Name = "SalesOrderID")] public int SalesOrderID { get; set; }
        [Column(Name = "OrderDate")] public DateTime OrderDate { get; set; }
        [Column(Name = "BillToAddressID")] public int BillToAddressID { get; set; }
        [Column(Name = "ShipToAddressID")] public int ShipToAddressID { get; set; }
        [Column(Name = "TotalDue")] public double TotalDue { get; set; }
    }
}
