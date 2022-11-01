using AdventureWorks.Models.Models;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Web.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDataConnection _db;

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

        [HttpGet("/id{id}")]
        public async Task<ProductModel> GetPerson(int id)
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

        [HttpDelete("{id}")]
        public async Task<int> DeletePerson(int id)
        {
            return await _db.GetTable<ProductModel>().Where(product => product.ProductID == id).DeleteAsync();
        }
    }
}
