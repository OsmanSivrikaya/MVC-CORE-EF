namespace Service.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T p);
        Task DeleteAsync(T t);
        Task UpdateAsync(T p);
        Task<T> GetAsync(int Id);
    }
}
