namespace WebApplication3.Dto
{
    public class EmployeeDto
    {
        public int employeeId { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime hireDate { get; set; }
        public string position { get; set; }
        public string department { get; set; }

        public decimal salary { get; set; }
        public int gender { get; set; }
    }
}
