using AdventureWorks.Models;
using AdventureWorks.Models.Models;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Web.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly AppDataConnection _db;

        public EmployeeController(AppDataConnection db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<FullEmployeeModel>> GetEmployees()
        {
            //return await _db.GetTable<EmployeeModel>().ToArrayAsync();

            using (AppDataConnection db = _db)
            {
                var employees = (from b in _db.GetTable<BusinessEntityIDModel>()
                                 from p in _db.GetTable<PersonModel>().InnerJoin(p => p.BusinessEntityID == b.BusinessEntityID)
                                 from e in _db.GetTable<EmployeeModel>().InnerJoin(e => e.BusinessEntityID == b.BusinessEntityID)
                                 select new FullEmployeeModel
                                 {
                                     BusinessEntityID = b.BusinessEntityID,
                                     FirstName = p.FirstName,
                                     LastName = p.LastName,
                                     JobTitle = e.JobTitle
                                 }).ToListAsync();

                return await employees;
            }

        }

        [HttpGet("{id}")]
        public Task<FullEmployeeModel> GetEmployee(int id)
        {
            using (AppDataConnection db = _db)
            {
                return _db.GetTable<FullEmployeeModel>().SingleOrDefaultAsync(employee => employee.BusinessEntityID == id);
            }

            //(from b in _db.GetTable<BusinessEntityIDModel>()
            // from p in _db.GetTable<PersonModel>().LeftJoin(p => p.BusinessEntityID == b.BusinessEntityID)
            // from e in _db.GetTable<EmployeeModel>().LeftJoin(e => e.BusinessEntityID == b.BusinessEntityID)
            // select new
            // {
            //     b.BusinessEntityID,
            //     p.FirstName,
            //     p.LastName,
            //     e.JobTitle
            // }).ToList();
        }

        [HttpPost]
        public void AddEmployee(FullEmployeeModel employee)
        {
            using (AppDataConnection db = _db)
            {
                //Guid guid = Guid.NewGuid();
                DateTime dateTime = DateTime.Now;

                var insert = _db.GetTable<BusinessEntityIDModel>()
                        .Value(b => b.ModifiedDate, dateTime)
                        .Insert();

                var added = _db.GetTable<BusinessEntityIDModel>().ToList().Last();

                _db.GetTable<PersonModel>()
                        .Where(p => p.BusinessEntityID == added.BusinessEntityID)
                        .Set(p => p.FirstName, employee.FirstName)
                        .Set(p => p.LastName, employee.LastName)
                        .Update();

                _db.GetTable<EmployeeModel>()
                        .Where(e => e.BusinessEntityID == added.BusinessEntityID)
                        .Set(e => e.JobTitle, employee.JobTitle)
                        .Update();
            }
                
        }

        [HttpPut]
        public void UpdateEmployee(FullEmployeeModel employee)
        {
            using (AppDataConnection db = _db)
            {
                _db.GetTable<PersonModel>()
                   .Where(p => p.BusinessEntityID == employee.BusinessEntityID)
                   .Set(p => p.FirstName, employee.FirstName)
                   .Set(p => p.LastName, employee.LastName)
                   .Update();

                _db.GetTable<EmployeeModel>()
                        .Where(e => e.BusinessEntityID == employee.BusinessEntityID)
                        .Set(e => e.JobTitle, employee.JobTitle)
                        .Update();
            }
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteEmployee(int id)
        {
            using (AppDataConnection db = _db)
            {
                return await _db.GetTable<FullEmployeeModel>().Where(employee => employee.BusinessEntityID == id).DeleteAsync();

            }
        }
    }
}
