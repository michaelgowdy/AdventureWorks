using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AdventureWorks.Models.Models
{
    public class FullSalesModel
    {
        [Required]
        public int SalesOrderID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public int BillToAddressID { get; set; }

        [Required]
        public int ShipToAddressID { get; set; }

        [Required]
        public decimal TotalDue { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Number is too long.")]
        public string SalesOrderNumber { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public decimal TaxAmt { get; set; }

        [Required]
        public decimal Freight { get; set; }



        public int SalesOrderDetailID { get; set; }

        public string CarrierTrackingNumber { get; set; }

        public int OrderQty { get; set; }

        public int ProductID { get; set; }

        public int SpecialOfferID { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal UnitPriceDiscount { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
