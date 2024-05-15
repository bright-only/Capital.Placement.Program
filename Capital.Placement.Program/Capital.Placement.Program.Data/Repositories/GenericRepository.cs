using Capital.Placement.Program.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace Capital.Placement.Program.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _context;

        public GenericRepository( ApplicationDBContext context )
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync( Guid id )
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task AddAsync( T entity )
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync( T entity )
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync( T entity )
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetPaginatedAsync( int pageNumber, int pageSize )
        {
            // Calculate the number of items to skip
            int itemsToSkip = (pageNumber - 1) * pageSize;

            // Retrieve the subset of data based on pagination parameters
            return await _context.Set<T>()
                .Skip(itemsToSkip)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
