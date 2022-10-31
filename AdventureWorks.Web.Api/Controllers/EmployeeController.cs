using AdventureWorks.Models;
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
    public class EmployeeController : Controller
    {
        private readonly AppDataConnection _db;

        public EmployeeController(AppDataConnection db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<FullEmployeeModel[]> GetEmployees()
        {
            //return await _db.GetTable<EmployeeModel>().ToArrayAsync();

            var employees = (from b in _db.GetTable<BusinessEntityIDModel>()
                             from p in _db.GetTable<PersonModel>().InnerJoin(p => p.BusinessEntityID == b.BusinessEntityID)
                             from e in _db.GetTable<EmployeeModel>().InnerJoin(e => e.BusinessEntityID == b.BusinessEntityID)
                             select new FullEmployeeModel
                             {
                                 BusinessEntityID = b.BusinessEntityID,
                                 FirstName = p.FirstName,
                                 LastName = p.LastName,
                                 JobTitle = e.JobTitle
                             }).ToArrayAsync();

            return await employees;
        }

        [HttpGet("{id}")]
        public Task<FullEmployeeModel> GetEmployee(int id)
        {
            return _db.GetTable<FullEmployeeModel>().SingleOrDefaultAsync(employee => employee.BusinessEntityID == id);

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
            //Guid guid = Guid.NewGuid();

            //_db.GetTable<BusinessEntityIDModel>()
            //        .Value(b => b.rowguid, guid)
            //        .Insert();

            _db.GetTable<PersonModel>()
                    .Value(p => p.FirstName, employee.FirstName)
                    .Value(p => p.LastName, employee.LastName)
                    .Insert();

            _db.GetTable<EmployeeModel>()
                    .Value(e => e.JobTitle, employee.JobTitle)
                    .Insert();
        }

        [HttpPut]
        public void UpdateEmployee(FullEmployeeModel employee)
        {
            //Guid guid = Guid.NewGuid();

            //_db.GetTable<FullEmployeeModel>()
            //        .Where(p => p.BusinessEntityID == employee.BusinessEntityID)
            //        .Set(p => p.JobTitle, employee.JobTitle)
            //        .Set(p => p.rowguid, guid)
            //        .Update();

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

        [HttpDelete("{id}")]
        public async Task<int> DeleteEmployee(int id)
        {
            return await _db.GetTable<FullEmployeeModel>().Where(employee => employee.BusinessEntityID == id).DeleteAsync();
        }
    }
}
