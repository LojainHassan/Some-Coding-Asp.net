using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeComapnyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
