using LinqToDB.Mapping;
using System;

namespace AdventureWorks.Models.Models
{
    [Table(Schema = "Production", Name = "Product")]
    public class ProductModel
    {
        [Column(Name = "ProductID")] public int ProductID { get; set; }
        [Column(Name = "Name")] public string Name { get; set; }
        [Column(Name = "ProductNumber")] public string ProductNumber { get; set; }
        [Column(Name = "Color")] public string Color { get; set; }
        [Column(Name = "Size")] public string Size { get; set; }
        [Column(Name = "ListPrice")] public double ListPrice { get; set; }
        [Column(Name = "rowguid")] public Guid rowguid { get; set; }
    }
}
