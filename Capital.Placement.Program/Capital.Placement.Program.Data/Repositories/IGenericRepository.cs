

namespace Capital.Placement.Program.Data.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<T> GetByIdAsync( Guid id );
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync( T entity );
        Task UpdateAsync( T entity );
        Task DeleteAsync( T entity );
        Task<IEnumerable<T>> GetPaginatedAsync( int pageNumber, int pageSize );
    }
}
