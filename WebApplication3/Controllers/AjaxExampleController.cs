using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using WebApplication3.Model;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AjaxExampleController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AjaxExampleController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetNames()
        {
          
            var employees = applicationDbContext.employeeComs.ToList();

            return Json(employees);

        }

        [HttpPost]
        public async Task Create(string values)
        {
            var employee = new Employee();
            JsonConvert.PopulateObject(values, employee);
            employee.Head_ID = 1;
            await applicationDbContext.Employees.AddAsync(employee);
            await applicationDbContext.SaveChangesAsync();
        }


        [HttpDelete]
        public async Task<ActionResult> Delete(int? key)
        {
          


            var emp = await applicationDbContext.Employees.FirstOrDefaultAsync(o => o.employeeId == key);
           

            applicationDbContext.Employees.Remove(emp);
             await applicationDbContext.SaveChangesAsync();


            return Ok();

        }


        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var emp = await applicationDbContext.Employees.FirstOrDefaultAsync(o => o.employeeId == key);

            emp.Head_ID = 1;
            JsonConvert.PopulateObject(values, emp);

       
            await applicationDbContext.SaveChangesAsync();

            return Ok();
        }

        public IActionResult AjaxAsp(string name)
        {


            return View();

        }

        public ActionResult getDepartment()
        {
            return View();
        }



    }
}
