
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication3.Models;

namespace WebApplication3.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        
     
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeCom> employeeComs { get; set; }
        public DbSet<Emails> emails { get; set; }
        public DbSet<CompanyEmployee> CompanyEmployee { get; set; }
        public DbSet<ems> emps { get; set; }



    }
}
