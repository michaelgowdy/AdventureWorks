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
        public async Task<IEnumerable<FullSalesModel>> GetSales(int page, int pageSize)
        {
            using (AppDataConnection db = _db)
            {
                var sales =
                    (from h in db.GetTable<SalesOrderHeaderModel>()
                     from d in db.GetTable<SalesOrderDetailModel>().InnerJoin(d => d.SalesOrderID == h.SalesOrderID)
                     select new FullSalesModel
                     {
                         SalesOrderID = h.SalesOrderID,
                         OrderDate = h.OrderDate,
                         BillToAddressID = h.BillToAddressID,
                         ShipToAddressID = h.ShipToAddressID,
                         TotalDue = h.TotalDue,
                         SalesOrderNumber = h.SalesOrderNumber,
                         SubTotal = h.SubTotal,
                         TaxAmt = h.TaxAmt,
                         Freight = h.Freight,
                         SalesOrderDetailID = d.SalesOrderDetailID,
                         CarrierTrackingNumber = d.CarrierTrackingNumber,
                         OrderQty = d.OrderQty,
                         ProductID = d.ProductID,
                         SpecialOfferID = d.SpecialOfferID,
                         UnitPrice = d.UnitPrice,
                         UnitPriceDiscount = d.UnitPriceDiscount,
                         ModifiedDate = d.ModifiedDate
                     }).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

                return await sales;
            }
        }

        //[HttpGet()]
        //public async Task<SalesOrderHeaderModel[]> GetSales(int page, int pageSize)
        //{
        //    using (AppDataConnection db = _db)
        //    {
        //        var sales = db.GetTable<SalesOrderHeaderModel>()
        //                 .Skip((page - 1) * pageSize)
        //                 .Take(pageSize)
        //                 .ToArrayAsync();

        //        return await sales;
        //    }
        //}

        //[HttpGet("id/{id}")]
        //public async Task<SalesOrderHeaderModel> GetSale(int id)
        //{
        //    return await _db.GetTable<SalesOrderHeaderModel>().SingleOrDefaultAsync(sale => sale.SalesOrderID == id);
        //}

        [HttpGet("id/{id}")]
        public async Task<FullSalesModel> GetSale(int id)
        {
            using (AppDataConnection db = _db)
            {
                var sale =
                    (from d in db.GetTable<SalesOrderDetailModel>().Where(d => d.SalesOrderDetailID == id)
                     from h in db.GetTable<SalesOrderHeaderModel>().InnerJoin(h => h.SalesOrderID == d.SalesOrderID)
                     select new FullSalesModel
                     {
                         SalesOrderID = h.SalesOrderID,
                         OrderDate = h.OrderDate,
                         BillToAddressID = h.BillToAddressID,
                         ShipToAddressID = h.ShipToAddressID,
                         TotalDue = h.TotalDue,
                         SalesOrderNumber = h.SalesOrderNumber,
                         SubTotal = h.SubTotal,
                         TaxAmt = h.TaxAmt,
                         Freight = h.Freight,
                         SalesOrderDetailID = d.SalesOrderDetailID,
                         CarrierTrackingNumber = d.CarrierTrackingNumber,
                         OrderQty = d.OrderQty,
                         ProductID = d.ProductID,
                         SpecialOfferID = d.SpecialOfferID,
                         UnitPrice = d.UnitPrice,
                         UnitPriceDiscount = d.UnitPriceDiscount,
                         ModifiedDate = d.ModifiedDate
                     }).SingleOrDefaultAsync();

                return await sale;
            }
        }

        [HttpPut]
        public IActionResult UpdateSale(FullSalesModel sale)
        {
            using (AppDataConnection db = _db)
            {
                db.GetTable<SalesOrderHeaderModel>()
                    .Where(s => s.SalesOrderID == sale.SalesOrderID)
                    .Set(s => s.OrderDate, sale.OrderDate)
                    .Set(s => s.BillToAddressID, sale.BillToAddressID)
                    .Set(s => s.ShipToAddressID, sale.ShipToAddressID)
                    .Set(s => s.SubTotal, sale.SubTotal)
                    .Set(s => s.TaxAmt, sale.TaxAmt)
                    .Set(s => s.Freight, sale.Freight)
                    .Update();

                db.GetTable<SalesOrderDetailModel>()
                    .Where(s => s.SalesOrderDetailID == sale.SalesOrderDetailID)
                    //.Set(s => s.CarrierTrackingNumber, sale.CarrierTrackingNumber)
                    .Set(s => s.OrderQty, sale.OrderQty)
                    .Set(s => s.ProductID, sale.ProductID)
                    .Set(s => s.SpecialOfferID, sale.SpecialOfferID)
                    .Set(s => s.UnitPrice, sale.UnitPrice)
                    .Set(s => s.UnitPriceDiscount, sale.UnitPriceDiscount)
                    .Update();

                return Ok();
            }

        }

        //public void Post([FromBody] CustomObject customObject, string name, string fatherName)
        //{
        //    //customObject is null
        //}

        [HttpPost]
        public void AddSale([FromBody] FullSalesModel sale)
        {  
            
                _db.GetTable<SalesOrderHeaderModel>()
                    .Value(s => s.OrderDate, sale.OrderDate)
                    .Value(s => s.BillToAddressID, sale.BillToAddressID)
                    .Value(s => s.ShipToAddressID, sale.ShipToAddressID)
                    .Value(s => s.SubTotal, sale.SubTotal)
                    .Value(s => s.TaxAmt, sale.TaxAmt)
                    .Value(s => s.Freight, sale.Freight)
                    .Insert();

                //var added = _db.GetTable<SalesOrderHeaderModel>().Last();

                //_db.GetTable<SalesOrderDetailModel>()
                //    .Value(s => s.SalesOrderID, added.SalesOrderID)
                //    .Value(s => s.OrderQty, sale.OrderQty)
                //    .Value(s => s.ProductID, sale.ProductID)
                //    .Value(s => s.SpecialOfferID, sale.SpecialOfferID)
                //    .Value(s => s.UnitPrice, sale.UnitPrice)
                //    .Value(s => s.UnitPriceDiscount, sale.UnitPriceDiscount)
                //    .Insert();
        }

        [HttpDelete("id/{id}")]
        public async Task<int> DeleteSale(int id)
        {
           using(AppDataConnection db = _db)
            {
                //db.GetTable<SalesOrderHeaderModel>().Where(s => s.SalesOrderID == id).Delete();
                //return Ok();

                return await db.GetTable<SalesOrderDetailModel>().Where(s => s.SalesOrderDetailID == id).DeleteAsync();
                
            }
        }


        // --------------------------------------------------------------------------------------------------------------------


        //[HttpGet()]
        //public async Task<SalesOrderHeaderModel[]> GetSales(int page, int pageSize)
        //{
        //    using (AppDataConnection db = _db)
        //    {
        //        var sales = _db.GetTable<SalesOrderHeaderModel>()
        //                 .Skip((page - 1) * pageSize)
        //                 .Take(pageSize)
        //                 .ToArrayAsync();

        //        return await sales;
        //    }
        //}

        //[HttpGet("id/{id}")]
        //public async Task<SalesOrderHeaderModel> GetSale(int id)
        //{
        //    using (AppDataConnection db = _db)
        //    {
        //        SalesOrderHeaderModel saleModel = new SalesOrderHeaderModel();

        //        //var sale = (from s in _db.GetTable<SalesOrderHeaderModel>()
        //        //            where s.SalesOrderID == id
        //        //            select s).SingleOrDefaultAsync(product => product.SalesOrderID == id);

        //        var sale = (from s in _db.GetTable<SalesOrderHeaderModel>()
        //                    where s.SalesOrderID == id
        //                    select s).SingleOrDefaultAsync();

        //        return await sale;
        //    }    
        //}

        //[HttpPut]
        //public void UpdateSale(SalesOrderHeaderModel sale)
        //{
        //    //Guid guid = Guid.NewGuid();

        //    _db.GetTable<SalesOrderHeaderModel>()
        //            .Where(s => s.SalesOrderID == sale.SalesOrderID)
        //            .Set(s => s.OrderDate, sale.OrderDate)
        //            .Set(s => s.BillToAddressID, sale.BillToAddressID)
        //            .Set(s => s.ShipToAddressID, sale.ShipToAddressID)
        //            .Set(s => s.SubTotal, sale.SubTotal)
        //            .Set(s => s.TaxAmt, sale.TaxAmt)
        //            .Set(s => s.Freight, sale.Freight)
        //            .Update();
        //}

        //[HttpPost]
        //public void AddSale(SalesOrderHeaderModel sale)
        //{
        //    //Guid guid = Guid.NewGuid();

        //    _db.GetTable<SalesOrderHeaderModel>()
        //            .Value(s => s.OrderDate, sale.OrderDate)
        //            .Value(s => s.BillToAddressID, sale.BillToAddressID)
        //            .Value(s => s.ShipToAddressID, sale.ShipToAddressID)
        //            .Value(s => s.SubTotal, sale.SubTotal)
        //            .Value(s => s.TaxAmt, sale.TaxAmt)
        //            .Value(s => s.Freight, sale.Freight)
        //            .Insert();
        //}

        //[HttpDelete("id/{id}")]
        //public IActionResult DeleteSale(int id)
        //{
        //    _db.GetTable<SalesOrderHeaderModel>().Where(s => s.SalesOrderID == id).Delete();
        //    return Ok();
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
