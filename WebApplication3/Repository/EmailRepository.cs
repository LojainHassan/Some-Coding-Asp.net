using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication3.Model;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class EmailRepository : IServiceRepository<Emails>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public EmailRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Task Create(Emails entity)
        {  
            applicationDbContext.emails.Add(entity);
            applicationDbContext.SaveChanges();
             return Task.CompletedTask;
           
        }

        public void Delete(int? id)
        {
          


            var email = applicationDbContext.emails.First(e => e.emailId == id);
            applicationDbContext.emails.Remove(email);
              applicationDbContext.SaveChanges();

          
        }


        public IEnumerable<Emails> GetAll()
        {
            return applicationDbContext.emails.ToList();

          }

        public Emails GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Emails entity)
        {
            throw new NotImplementedException();
        }
    }
}
