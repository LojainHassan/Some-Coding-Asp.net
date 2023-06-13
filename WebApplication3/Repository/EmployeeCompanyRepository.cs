using WebApplication3.Model;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class EmployeeCompanyRepository : IServiceRepository<ems>
    {


        private readonly ApplicationDbContext context;

        public EmployeeCompanyRepository(ApplicationDbContext context) {
            this.context = context;
        }
        public IEnumerable<ems> GetAll()
        {
            return context.emps.ToList();
        }

        public Task Create(ems entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

     

        public ems GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ems entity)
        {
            throw new NotImplementedException();
        }
    }
}
