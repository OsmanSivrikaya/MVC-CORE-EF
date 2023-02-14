using EntityLayer.Concrete;

namespace Core.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T p);
        Task DeleteAsync(T T);
        Task UpdateAsync(T p);
        Task<T> GetAsync(int Id);
    }
}
