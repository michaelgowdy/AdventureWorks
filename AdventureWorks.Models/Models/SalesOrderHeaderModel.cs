using LinqToDB.Mapping;
using System;

namespace AdventureWorks.Models.Models
{
    [Table(Schema = "Sales", Name = "SalesOrderHeader")]
    public class SalesOrderHeaderModel
    {
        [Column(Name = "SalesOrderID")] public int SalesOrderID { get; set; }
        [Column(Name = "OrderDate")] public DateTime OrderDate { get; set; }
        [Column(Name = "BillToAddressID")] public int BillToAddressID { get; set; }
        [Column(Name = "ShipToAddressID")] public int ShipToAddressID { get; set; }
        [Column(Name = "TotalDue")] public double TotalDue { get; set; }
        [Column(Name = "SalesOrderNumber")] public string SalesOrderNumber { get; set; }
        [Column(Name = "SubTotal")] public double SubTotal { get; set; }
        [Column(Name = "TaxAmt")] public double TaxAmt { get; set; }
        [Column(Name = "Freight")] public double Freight { get; set; }

    }
}
