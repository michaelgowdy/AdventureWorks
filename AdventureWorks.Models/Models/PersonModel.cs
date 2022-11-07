using LinqToDB.Mapping;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace AdventureWorks.Models.Models
{
    [Table(Schema = "Person", Name = "Person")]
    public class PersonModel 
    {
        [Column(Name = "BusinessEntityID")] public int BusinessEntityID { get; set; }
        [Column(Name = "FirstName")] public string FirstName { get; set; }
        [Column(Name = "LastName")] public string LastName { get; set; }
    }
}
