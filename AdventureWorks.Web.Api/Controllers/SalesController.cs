using AdventureWorks.Models.Models;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Web.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class SalesController : Controller
    {
        private readonly AppDataConnection _db;

        // Queries
        public SalesController(AppDataConnection db)
        {
            _db = db;
        }

        [HttpGet()]
        public async Task<SalesOrderHeaderModel[]> GetSales(int page, int pageSize)
        {
            using (AppDataConnection db = _db)
            {
                var sales = _db.GetTable<SalesOrderHeaderModel>()
                         .Skip((page - 1) * pageSize)
                         .Take(pageSize)
                         .ToArrayAsync();

                return await sales;
            }
        }

        [HttpGet("id/{id}")]
        public async Task<SalesOrderHeaderModel> GetSale(int id)
        {
            using (AppDataConnection db = _db)
            {
                SalesOrderHeaderModel saleModel = new SalesOrderHeaderModel();

                //var sale = (from s in _db.GetTable<SalesOrderHeaderModel>()
                //            where s.SalesOrderID == id
                //            select s).SingleOrDefaultAsync(product => product.SalesOrderID == id);

                var sale = (from s in _db.GetTable<SalesOrderHeaderModel>()
                            where s.SalesOrderID == id
                            select s).SingleOrDefaultAsync();

                return await sale;
            }    
        }

        [HttpPut]
        public void UpdateSale(SalesOrderHeaderModel sale)
        {
            //Guid guid = Guid.NewGuid();

            _db.GetTable<SalesOrderHeaderModel>()
                    .Where(s => s.SalesOrderID == sale.SalesOrderID)
                    .Set(s => s.OrderDate, sale.OrderDate)
                    .Set(s => s.BillToAddressID, sale.BillToAddressID)
                    .Set(s => s.ShipToAddressID, sale.ShipToAddressID)
                    .Set(s => s.SubTotal, sale.SubTotal)
                    .Set(s => s.TaxAmt, sale.TaxAmt)
                    .Set(s => s.Freight, sale.Freight)
                    .Update();
        }

        [HttpPost]
        public void AddSale(SalesOrderHeaderModel sale)
        {
            //Guid guid = Guid.NewGuid();

            _db.GetTable<SalesOrderHeaderModel>()
                    .Value(s => s.OrderDate, sale.OrderDate)
                    .Value(s => s.BillToAddressID, sale.BillToAddressID)
                    .Value(s => s.ShipToAddressID, sale.ShipToAddressID)
                    .Value(s => s.SubTotal, sale.SubTotal)
                    .Value(s => s.TaxAmt, sale.TaxAmt)
                    .Value(s => s.Freight, sale.Freight)
                    .Insert();
        }

        [HttpDelete("id/{id}")]
        public IActionResult DeleteSale(int id)
        {
            _db.GetTable<SalesOrderHeaderModel>().Where(s => s.SalesOrderID == id).Delete();
            return Ok();
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
