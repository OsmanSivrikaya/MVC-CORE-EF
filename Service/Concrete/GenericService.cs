using Core.Abstract;
using Service.Abstract;

namespace Service.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(T p)
        {
            await _repository.AddAsync(p);
        }

        public async Task DeleteAsync(T t)
        {
            await _repository.DeleteAsync(t);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return result;
        }

        public async Task<T> GetAsync(int Id)
        {
            var result = await _repository.GetAsync(Id);
            return result;
        }

        public async Task UpdateAsync(T p)
        {
            await _repository.UpdateAsync(p);
        }
    }
}
