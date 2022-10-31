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
        public async Task<EmployeeModel[]> GetEmployees()
        {
            return await _db.GetTable<EmployeeModel>().ToArrayAsync();
        }

        [HttpGet("{id}")]
        public Task<EmployeeModel> GetEmployee(int id)
        {
            return _db.GetTable<EmployeeModel>().SingleOrDefaultAsync(employee => employee.BusinessEntityID == id);
        }

        [HttpPut]
        public void UpdateEmployee(EmployeeModel employee)
        {
            Guid guid = Guid.NewGuid();

            _db.GetTable<EmployeeModel>()
                    .Where(p => p.BusinessEntityID == employee.BusinessEntityID)
                    .Set(p => p.JobTitle, employee.JobTitle)
                    .Set(p => p.rowguid, guid)
                    .Update();
        }

        [HttpPost]
        public void AddEmployee(EmployeeModel employee)
        {
            Guid guid = Guid.NewGuid();

            _db.GetTable<EmployeeModel>()
                    .Value(p => p.BusinessEntityID, employee.BusinessEntityID)
                    .Value(p => p.JobTitle, employee.JobTitle)
                    .Value(p => p.rowguid, guid)
                    .Insert();
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteEmployee(int id)
        {
            return await _db.GetTable<EmployeeModel>().Where(employee => employee.BusinessEntityID == id).DeleteAsync();
        }
    }
}
