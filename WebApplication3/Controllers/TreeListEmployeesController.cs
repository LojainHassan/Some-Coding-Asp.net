using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using WebApplication3.Model;
using WebApplication3.Repository;
using AutoMapper;
using WebApplication3.Dto;

namespace WebApplication3.Controllers
{

    [Route("api/[controller]")]
    public class TreeListEmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly IServiceRepository<Employee> serviceRepository;
        private readonly IMapper mapper;

        public TreeListEmployeesController(ApplicationDbContext db , IServiceRepository<Employee> serviceRepository,
            IMapper mapper)
        {
            this.db = db;
            this.serviceRepository = serviceRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public object Get (DataSourceLoadOptions loadOptions)
        {
            var EmployeeList = from d in db.Employees.ToList()
                               select new EmployeeDto
                               {
                                   employeeId = d.employeeId,
                                    position = d.position,
                                   hireDate = d.hireDate,
                                   dateOfBirth = d.dateOfBirth,
                                    salary = d.salary,
            };

            return DataSourceLoader.Load(mapper.Map<IEnumerable<EmployeeDto>>(EmployeeList), loadOptions);
        }



       



    }
}
