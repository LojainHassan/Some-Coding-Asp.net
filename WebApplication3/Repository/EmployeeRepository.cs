using Microsoft.EntityFrameworkCore;
using WebApplication3.Model;

namespace WebApplication3.Repository
{
    public class EmployeeRepository : IServiceRepository<Employee>
    {
        private readonly ApplicationDbContext db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Employee> GetAll()
        {

            return  db.Employees.ToList();

        }

        public async Task Create(Employee entity)
        {
           
                await db.Employees.AddAsync(entity);
                await db.SaveChangesAsync();
               
            
          
        }

        public async Task<int> Delete(int? id)
        {
            int idGather = 0;
            
                  var  emp = db.Employees.Where(d => d.employeeId == id).First();
                    db.Employees.Remove(emp);
                    idGather = await db.SaveChangesAsync();


            return idGather;

        }

      

        public  Employee GetById(int id)
        {
           if(db != null)
            {
                return db.Employees.SingleOrDefault(em =>em.employeeId == id);
            }
           return null;
        }

        public async Task<int> Update(Employee entity)
        {
            if (entity != null)
            {
                db.Employees.Update(entity);
                await db.SaveChangesAsync();
                return entity.employeeId;
            }
            return 0;
        }

       

        void IServiceRepository<Employee>.Delete(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
