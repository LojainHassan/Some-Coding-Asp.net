namespace WebApplication3.Repository
{
    public interface IServiceRepository<T>
    {
     
        Task Create(T entity);
        Task<int> Update(T entity);
        void Delete(int? id);
        T GetById(int id);
        IEnumerable<T> GetAll();


    }
}
