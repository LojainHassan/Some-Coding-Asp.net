using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class CompanyEmployee
    {
  
        [Key]
        public int employeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfbirth { get; set; }
        public DateTime HireDate { get; set; }
        public string Department { get; set; }

        public decimal Salary { get; set; }
        public string Position { get; set; }
        public int Gender { get; set; }


    }
}