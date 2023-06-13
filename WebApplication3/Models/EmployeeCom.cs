using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class EmployeeCom
    {

        [Key]
        public int employeeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime hireDate { get; set; }
        public string department { get; set; }

        public decimal salary { get; set; }
        public string position { get; set; }
        public int Head_ID { get; set; }
        public bool Female { get; set; }
        public bool Male { get; set; }
    }
}
