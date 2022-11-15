using LinqToDB.Mapping;
using System;

namespace AdventureWorks.Models.Models
{
    [Table(Schema = "Sales", Name = "SalesOrderDetail")]
    public class SalesOrderDetailModel
    {
        [Column(Name = "SalesOrderID")]
        public int SalesOrderID { get; set; }

        [Column(Name = "SalesOrderDetailID")]
        public int SalesOrderDetailID { get; set; }

        [Column(Name = "CarrierTrackingNumber")]
        public string CarrierTrackingNumber { get; set; }

        [Column(Name = "OrderQty")]
        public int OrderQty { get; set; }

        [Column(Name = "ProductID")]
        public int ProductID { get; set; }

        [Column(Name = "SpecialOfferID")]
        public int SpecialOfferID { get; set; }

        [Column(Name = "UnitPrice")]
        public decimal UnitPrice { get; set; }

        [Column(Name = "UnitPriceDiscount")]
        public decimal UnitPriceDiscount { get; set; }

        [Column(Name = "ModifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
