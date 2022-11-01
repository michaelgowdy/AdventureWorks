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

        //private int _productId;
        //private string _name;
        //private string _productNumber;
        //private string _color;
        //private string _size;
        //private double _listPrice;
        //private Guid _rowguid;


        //[Column(Name = "ProductID")]
        //public int ProductID
        //{
        //    get { return _productId; }
        //    set 
        //    { 
        //        _productId = value; 
        //        OnPropertyChanged();
        //    }
        //}

        //[Column(Name = "Name")]
        //public string Name
        //{
        //    get { return _name; }
        //    set 
        //    { 
        //        _name = value;
        //        OnPropertyChanged();
        //    }
        //}


        //[Column(Name = "ProductNumber")]
        //public string ProductNumber
        //{
        //    get { return _productNumber; }
        //    set 
        //    { 
        //        _productNumber = value;
        //        OnPropertyChanged();
        //    }
        //}


        //[Column(Name = "Color")]
        //public string Color
        //{
        //    get { return _color; }
        //    set 
        //    { 
        //        _color = value;
        //        OnPropertyChanged();
        //    }
        //}


        //[Column(Name = "Size")]
        //public string Size
        //{
        //    get { return _size; }
        //    set 
        //    { 
        //        _size = value;
        //        OnPropertyChanged();
        //    }
        //}


        //[Column(Name = "ListPrice")]
        //public double ListPrice
        //{
        //    get { return _listPrice; }
        //    set 
        //    { 
        //        _listPrice = value;
        //        OnPropertyChanged();
        //    }
        //}


        //[Column(Name = "rowguid")]
        //public Guid rowguid
        //{
        //    get { return _rowguid; }
        //    set 
        //    { 
        //        _rowguid = value;
        //        OnPropertyChanged();
        //    }
        //}

    }
}
