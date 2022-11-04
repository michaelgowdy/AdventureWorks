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

                var sale = (from s in _db.GetTable<SalesOrderHeaderModel>()
                            where s.SalesOrderID == id
                            select s).SingleOrDefaultAsync(product => product.SalesOrderID == id);


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
                    .Set(s => s.TotalDue, sale.TotalDue)
                    .Update();
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
