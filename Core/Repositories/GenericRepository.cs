using Core.Abstract;
using Core.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public async Task AddAsync(T t)
        {
            using (var c = new Context())
            {
                await c.AddAsync(t);
                await c.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(T t)
        {
            using (var c = new Context())
            {
                c.Remove(t);
                await c.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var c = new Context())
            {
                var result = await c.Set<T>().ToListAsync();
                return result;
            }
        }

        public async Task<T> GetAsync(int Id)
        {
            using (var c = new Context())
            {
                var result = await c.Set<T>().FindAsync(Id);
                return result;
            }
        }

        public async Task UpdateAsync(T t)
        {
            using (var c = new Context())
            {
                c.Update(t);
                await c.SaveChangesAsync();
            }
        }
    }
}
