using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using WebApplication3.Model;
using WebApplication3.Models;
using System.Text.Json;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext applicationDbContext;

        public HomeController(ILogger<HomeController> logger ,ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public JsonResult MyJson()
        {
            SillyData mysillyData = new SillyData()
            {
                Abc=99,
                Def ="my testing strings!"
            };
            return Json(mysillyData);       

        }

        public JsonResult emp()
        {
            var employees = applicationDbContext.Employees.ToList();
            string jsonString = JsonSerializer.Serialize(employees);

            // Return JSON result
            return Json(jsonString);
 
        }

        public IActionResult Tree()
        {
            return View();
        }

        public IActionResult EmailView()
        {
            return View();
        }

        public ActionResult GetCustomers()
        {
            // Fetch data from your data source and return as JSON
            var employees = applicationDbContext.Employees.ToList();
            return Json(employees);
        }

        public IActionResult GetProducts()
        {
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.99m },
            new Product { Id = 2, Name = "Product 2", Price = 19.99m },
            new Product { Id = 3, Name = "Product 3", Price = 5.99m }
        };

            return Json(products);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}