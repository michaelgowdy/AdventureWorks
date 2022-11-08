using LinqToDB.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace AdventureWorks.Models.Models
{
    [Table(Schema = "Person", Name = "BusinessEntity")]
    public class BusinessEntityIDModel 
    {
        [Column(Name = "BusinessEntityID")] public int BusinessEntityID { get; set; }
        [Column(Name ="ModifiedDate")] public DateTime ModifiedDate { get; set; }
        [Column(Name = "rowguid")] public Guid rowguid { get; set; }
    }
}
