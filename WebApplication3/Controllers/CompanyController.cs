using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Xml.Linq;
using WebApplication3.Dto;
using WebApplication3.Model;
using WebApplication3.Models;
using WebApplication3.Repository;


namespace WebApplication3.Controllers
{
 
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        public CompanyController( ApplicationDbContext applicationDb  , IMapper mapper)
        {
            this.applicationDb = applicationDb;
            this.mapper = mapper;
        }


        [HttpGet]
        public JsonResult Get()
        {
            var EmployeeList = from d in applicationDb.CompanyEmployee.ToList()
                               select new EmployeeDto
                               {
                                   employeeId = d.employeeId,
                                   position = d.Position,
                                   hireDate = d.HireDate,
                                   dateOfBirth = d.DateOfbirth,
                                   salary = d.Salary,
                                   firstName = d.FirstName,
                                   lastName = d.LastName,
                                   department = d.Department,
                                   gender =Convert.ToInt32(d.Gender)
                               };

            return Json(mapper.Map<IEnumerable<EmployeeDto>>(EmployeeList));
        }


        [HttpPost]
        public async Task Create(string values)
        {
            var employee = new CompanyEmployee();
            JsonConvert.PopulateObject(values, employee);
           // employee.Head_ID = 1;
            await applicationDb.CompanyEmployee.AddAsync(employee);
            await applicationDb.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int? key)
        {

            var emp = await applicationDb.CompanyEmployee.FirstOrDefaultAsync(o => o.employeeId == key);
            applicationDb.CompanyEmployee.Remove(emp);
            await applicationDb.SaveChangesAsync();
            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var emp = await applicationDb.CompanyEmployee.FirstOrDefaultAsync(o => o.employeeId == key);

        
            JsonConvert.PopulateObject(values, emp);


            await applicationDb.SaveChangesAsync();

            return Ok();
        }

    }
}
