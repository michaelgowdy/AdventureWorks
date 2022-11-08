using LinqToDB.Mapping;
using System;

namespace AdventureWorks.Models
{
    [Table(Schema = "HumanResources", Name = "Employee")]
    public class EmployeeModel
    {
        [Column(Name = "BusinessEntityID")] public int BusinessEntityID { get; set; }
        [Column(Name = "JobTitle")] public string JobTitle { get; set; }
        [Column(Name = "LoginID")] public string LoginID { get; set; }
        [Column(Name = "NationalIDNumber")] public string NationalIDNumber { get; set; }
        [Column(Name = "rowguid")] public Guid rowguid { get; set; }
    }
}
