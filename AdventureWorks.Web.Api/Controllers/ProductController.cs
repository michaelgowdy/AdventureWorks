using AdventureWorks.Models.Models;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Web.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductController : Controller//, INotifyDataErrorInfo
    {
        private readonly AppDataConnection _db;

        // Queries
        public ProductController(AppDataConnection db)
        {
            _db = db;
        }

        [HttpGet()]
        public async Task<ProductModel[]> GetProducts(int page, int pageSize)
        {
            var products = _db.GetTable<ProductModel>()
                         .Skip((page - 1) * pageSize)
                         .Take(pageSize)
                         .ToArrayAsync();

            return await products;
        }

        [HttpGet("id/{id}")]
        public async Task<ProductModel> GetProduct(int id)
        {
            return await _db.GetTable<ProductModel>().SingleOrDefaultAsync(product => product.ProductID == id);
        }

        [HttpPut]
        public void UpdateProduct(ProductModel product)
        {
            Guid guid = Guid.NewGuid();

            _db.GetTable<ProductModel>()
                    .Where(p => p.ProductID == product.ProductID)
                    .Set(p => p.Name, product.Name)
                    .Set(p => p.ProductNumber, product.ProductNumber)
                    .Set(p => p.Color, product.Color)
                    .Set(p => p.Size, product.Size)
                    .Set(p => p.ListPrice, product.ListPrice)
                    .Set(p => p.rowguid, guid)
                    .Update();
        }

        [HttpPost]
        public void AddProduct(ProductModel product)
        {
            Guid guid = Guid.NewGuid();

            _db.GetTable<ProductModel>()
                    .Value(p => p.Name, product.Name)
                    .Value(p => p.ProductNumber, product.ProductNumber)
                    .Value(p => p.Color, product.Color)
                    .Value(p => p.Size, product.Size)
                    .Value(p => p.ListPrice, product.ListPrice)
                    .Value(p => p.rowguid, guid)
                    .Insert();
        }

        [HttpDelete("id/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _db.GetTable<ProductModel>().Where(product => product.ProductID == id).Delete();
            return Ok();

            //if (!delete.IsCompleted)
            //{
            //    GetErrors(nameof(delete));
            //}
        }


        //[HttpDelete("id/{id}")]
        //public Task<int> DeleteProduct(int id)
        //{
        //    return _db.GetTable<ProductModel>.Where(p => p.ProductID == id).DeleteAsync();
        //}

        //public IEnumerable GetErrors(string propertyName)
        //{
        //    throw new NotImplementedException();
        //}

        //    if (ambassadors.TryGetValue(code, out var ambassador))
        //      {
        //          Console.WriteLine($"The ambassador is {ambassador.Name}");
        //      }
        //    else
        //      {
        //           Console.WriteLine($"The ambassador with the given code \"{code}\" does not exist in the dictonary");
        //      }



        // Error Handling

        //List<string> errors = new List<string>();

        //private readonly Dictionary<string, List<string>> propErrors = new Dictionary<string, List<string>>();

        //public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        //public IEnumerable GetErrors(string propertyName)
        //{
        //    List<string> errors = new List<string>();
        //    if (propertyName != null)
        //    {
        //        propErrors.TryGetValue(propertyName, out errors);
        //        return errors;
        //    }
        //    else
        //        return null;
        //}

        //public bool HasErrors
        //{
        //    get
        //    {
        //        try
        //        {
        //            var propErrorsCount = propErrors.Values.FirstOrDefault(r => r.Count > 0);
        //            if (propErrorsCount != null)
        //                return true;
        //            else
        //                return false;
        //        }
        //        catch { }
        //        return true;
        //    }
        //}
    }
}
