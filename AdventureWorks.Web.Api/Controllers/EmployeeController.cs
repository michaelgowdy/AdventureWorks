using AdventureWorks.Models;
using AdventureWorks.Models.Models;
using Azure.Core;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Web.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EmployeeController : Controller, IDataErrorInfo
    {
        private readonly AppDataConnection _db;

        public string Error => throw new NotImplementedException();

        public string this[string columnName] => throw new NotImplementedException();



        public EmployeeController(AppDataConnection db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<FullEmployeeModel>> GetEmployees()
        {
            using (AppDataConnection db = _db)
            {
                var employees =
                    (from b in db.GetTable<BusinessEntityIDModel>()
                     from p in db.GetTable<PersonModel>().InnerJoin(p => p.BusinessEntityID == b.BusinessEntityID)
                     from e in db.GetTable<EmployeeModel>().InnerJoin(e => e.BusinessEntityID == b.BusinessEntityID)
                     select new FullEmployeeModel
                     {
                         BusinessEntityID = b.BusinessEntityID,
                         FirstName = p.FirstName,
                         LastName = p.LastName,
                         JobTitle = e.JobTitle,
                         LoginID = e.LoginID,
                         NationalIDNumber = e.NationalIDNumber
                     }).ToListAsync();

                return await employees;
            }

        }

        [HttpGet("id/{id}")]
        public async Task<IEnumerable<FullEmployeeModel>> GetEmployee(int id)
        {
            using (AppDataConnection db = _db)
            {
                var employee = (from b in db.GetTable<BusinessEntityIDModel>()
                                from p in db.GetTable<PersonModel>().InnerJoin(p => p.BusinessEntityID == b.BusinessEntityID)
                                from e in db.GetTable<EmployeeModel>().InnerJoin(e => e.BusinessEntityID == b.BusinessEntityID)
                                where b.BusinessEntityID == id
                                select new FullEmployeeModel
                                {
                                    BusinessEntityID = b.BusinessEntityID,
                                    FirstName = p.FirstName,
                                    LastName = p.LastName,
                                    JobTitle = e.JobTitle
                                }).ToListAsync();

                return await employee;
            }
        }

        public void InsertEmployee(int id, string jobTitle, string login, string nationalid, Guid guid)
        {
            using(AppDataConnection db = _db)
            {
                db.GetTable<EmployeeModel>()
               .Value(e => e.BusinessEntityID, id)
               .Value(e => e.JobTitle, jobTitle)
               .Value(e => e.LoginID, login)
               .Value(e => e.NationalIDNumber, nationalid)
               .Value(e => e.rowguid, guid)
               .Insert();
            }
           
        }

        [HttpPost]
        public void AddEmployee(FullEmployeeModel employee)
        {
            using (AppDataConnection db = _db)
            {
                Guid guid = Guid.NewGuid();

                db.GetTable<BusinessEntityIDModel>()
                    .Value(b => b.rowguid, guid)
                    .Insert();

                BusinessEntityIDModel added = db.GetTable<BusinessEntityIDModel>().ToList().Last();

                db.GetTable<PersonModel>()
                    .Value(p => p.BusinessEntityID, added.BusinessEntityID)
                    .Value(p => p.FirstName, employee.FirstName)
                    .Value(p => p.LastName, employee.LastName)
                    .Insert();

                //InsertEmployee(added.BusinessEntityID, employee.JobTitle, employee.LoginID, employee.NationalIDNumber, guid);

                //db.GetTable<EmployeeModel>()
                //    .Value(e => e.BusinessEntityID, added.BusinessEntityID)
                //    .Value(e => e.JobTitle, employee.JobTitle)
                //    .Value(e => e.LoginID, employee.LoginID)
                //    .Value(e => e.NationalIDNumber, employee.NationalIDNumber)
                //    .Value(e => e.rowguid, guid)
                //    .Insert();
            }
        }

        [HttpPut]
        public void UpdateEmployee(FullEmployeeModel employee)
        {
            using (AppDataConnection db = _db)
            {
                db.GetTable<PersonModel>()
                    .Where(p => p.BusinessEntityID == employee.BusinessEntityID)
                    .Set(p => p.FirstName, employee.FirstName)
                    .Set(p => p.LastName, employee.LastName)
                    .Update();

                db.GetTable<EmployeeModel>()
                    .Where(e => e.BusinessEntityID == employee.BusinessEntityID)
                    .Set(e => e.JobTitle, employee.JobTitle)
                    .Update();
            }
        }

        [HttpDelete("id/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            //_db.GetTable<FullEmployeeModel>().Where(e => e.BusinessEntityID == id).Delete();
            //return Ok();

            using(AppDataConnection db = _db)
            {
                var employee = _db.GetTable<BusinessEntityIDModel>().Where(e => e.BusinessEntityID == id).ToList();

                if (employee != null)
                {
                    try
                    {
                        (from b in db.GetTable<BusinessEntityIDModel>()
                         from p in db.GetTable<PersonModel>().InnerJoin(p => p.BusinessEntityID == b.BusinessEntityID)
                         from e in db.GetTable<EmployeeModel>().InnerJoin(e => e.BusinessEntityID == b.BusinessEntityID)
                         where b.BusinessEntityID == id
                         select new FullEmployeeModel
                         {
                             BusinessEntityID = b.BusinessEntityID,
                             FirstName = p.FirstName,
                             LastName = p.LastName,
                             JobTitle = e.JobTitle
                         }).Delete();

                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
    }
}

