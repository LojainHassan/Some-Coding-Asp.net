using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using WebApplication3.Dto;
using WebApplication3.Migrations;
using WebApplication3.Model;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    public class EmailTreeController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly IServiceRepository<Emails> serviceRepository;
        private readonly IMapper mapper;

        public EmailTreeController(ApplicationDbContext db, IServiceRepository<Emails> serviceRepository,
         IMapper mapper)
        {
            this.db = db;
            this.serviceRepository = serviceRepository;
            this.mapper = mapper;
         
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var EmailList = serviceRepository.GetAll();
            return DataSourceLoader.Load(mapper.Map<IEnumerable<EmailDto>>(EmailList), loadOptions);
        }


        [HttpPost]
        public IActionResult Post(string values)
        {
            var newItem = new Emails();
            JsonConvert.PopulateObject(values, newItem);

            serviceRepository.Create(newItem);
            return Ok();
        }



        [HttpDelete]

        public IActionResult Delete(int key)
        {
            serviceRepository.Delete(key);
            return Ok();
        }


        [HttpPut]

        public IActionResult Put(int key, string values)
        {
            var email = db.emails.First(e => e.emailId == key);

            JsonConvert.PopulateObject(values, email);

           
            db.SaveChanges();

            return Ok();
        }


    }
}

