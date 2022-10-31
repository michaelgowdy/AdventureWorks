using LinqToDB.Mapping;
using System;

namespace AdventureWorks.Models.Models
{
    [Table(Schema = "Person", Name = "BusinessEntity")]
    public class BusinessEntityIDModel
    {
        [Column(Name = "BusinessEntityID")] public int BusinessEntityID { get; set; }
        [Column(Name ="ModifiedDate")] public DateTime ModifiedDate { get; set; }
        //[Column(Name = "rowguid")] public Guid rowguid { get; set; }
    }
}
