using AdventureWorks.Models;
using AdventureWorks.Models.Models;
using Azure.Core;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
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
                     orderby b.BusinessEntityID
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

        [HttpPost]
        public async Task AddEmployee(FullEmployeeModel employee)
        {
            using (AppDataConnection db = _db)
            {
                //DataSet ds = new DataSet();
                //ds.Locale = CultureInfo.InvariantCulture;
                //FillDataSet(ds);

                //DataTable businessid = ds.Tables["BusinessEntityID"];
                //DataTable person = ds.Tables["Person"];
                //DataTable employees = ds.Tables["Employee"];

                //var query =
                //    from bid in businessid.AsEnumerable()
                //    join p in person.AsEnumerable()
                //    on bid.Field<int>("BusinessEntityID") equals
                //        p.Field<int>("BusinessEntityID")
                //    join e in employees.AsEnumerable()
                //    on bid.Field<int>("BusinessEntityID") equals
                //        e.Field<int>("BusinessEntityID")
                //    select new FullEmployeeModel
                //    {
                //        BusinessEntityID = bid.Field<int>("BusinessEntityID"),
                //        FirstName = p.Field<string>("FirstName"),
                //        LastName = p.Field<string>("LastName"),
                //        JobTitle = e.Field<string>("JobTitle")
                //    };

                //DataTable orderTable = query.CopyToDataTable();

                //var authorsWithSNames =
                //from b in db.GetTable<Book>()
                //select new
                //{
                //    b.Id,
                //    b.Title,
                //    b.FirstName,
                //    b.MiddleName,
                //    b.LastName,
                //    SNames = db.GetTable<Book>()
                //          .Where(p2 => p2.LastName.StartsWith("S"))
                //};
                //var authorsWithSNamesCte = authorsWithSNames
                //                                     .AsCte("PeopleWithSNames");



                //var employees =
                //     (from b in db.GetTable<BusinessEntityIDModel>()
                //      from p in db.GetTable<PersonModel>().InnerJoin(p => p.BusinessEntityID == b.BusinessEntityID)
                //      from e in db.GetTable<EmployeeModel>().InnerJoin(e => e.BusinessEntityID == b.BusinessEntityID)
                //      .Insert

                //      select new FullEmployeeModel
                //      {
                //          BusinessEntityID = b.BusinessEntityID,
                //          FirstName = p.FirstName,
                //          LastName = p.LastName,
                //          JobTitle = e.JobTitle
                //          //LoginID = e.LoginID,
                //          //NationalIDNumber = e.NationalIDNumber
                //      });

                //var employeesCte = employees.AsCte("Employees");


                //----------------------------------------------------------------------------------------

                Guid guid = Guid.NewGuid();

                var businessEntityID = await db.GetTable<BusinessEntityIDModel>().Value(b => b.rowguid, guid).InsertWithInt32IdentityAsync();

                if (businessEntityID.HasValue)
                {
                    await db.GetTable<PersonModel>()
                        .Value(p => p.BusinessEntityID, businessEntityID.Value)
                        .Value(p => p.FirstName, employee.FirstName)
                        .Value(p => p.LastName, employee.LastName)
                        .InsertAsync();
                }



                ////Order order = new Order();
                ////Order.OrderDate = DateTime.Now();
                ////dataContext.InsertOnSubmit(order);

                ////OrderItem item1 = new OrderItem();
                ////Item1.ItemId = 123;
                //////Note: We set the Order property, which is an Order object
                ////// We do not set the OrderId property
                ////// LINQ will know to use the Id that is assigned from the order above
                ////Item1.Order = order;
                ////dataContext.InsertOnSubmit(item1);

                ////dataContext.SubmitChanges();
                //----------------------------------------------------------------------------------------




                //----------------------------------------------------------------------------------------
                //Guid guid = Guid.NewGuid();

                //db.GetTable<BusinessEntityIDModel>()
                //    .Value(b => b.rowguid, guid)
                //    .InsertWithIdentity();

                //BusinessEntityIDModel added = 
                //    (from b in db.GetTable<BusinessEntityIDModel>()
                //    orderby b.BusinessEntityID descending
                //    select b).ToList().First();

                //db.GetTable<PersonModel>()
                //    .Value(p => p.BusinessEntityID, added.BusinessEntityID)
                //    .Value(p => p.FirstName, employee.FirstName)
                //    .Value(p => p.LastName, employee.LastName)
                //    .Insert();

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

            using (AppDataConnection db = _db)
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

