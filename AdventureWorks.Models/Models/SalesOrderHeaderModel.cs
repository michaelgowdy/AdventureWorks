﻿using LinqToDB.Mapping;
using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
