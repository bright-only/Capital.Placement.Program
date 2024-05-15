using Capital.Placement.Program.Data.Context;
using Capital.Placement.Program.Data.Model;

using Microsoft.EntityFrameworkCore;

namespace Capital.Placement.Program.Data.Repositories
{
    public class PersonalInformationRepository : IGenericRepository<PersonalInformation>
    {
        private readonly ApplicationDBContext _context;

        public PersonalInformationRepository( ApplicationDBContext context )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PersonalInformation> GetByIdAsync( Guid id )
        {
            return await _context.PersonalInformations.FindAsync(id);
        }

        public async Task<IEnumerable<PersonalInformation>> GetAllAsync()
        {
            return await _context.PersonalInformations.ToListAsync();
        }

        public async Task AddAsync( PersonalInformation entity )
        {
            await _context.PersonalInformations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync( PersonalInformation entity )
        {
            _context.PersonalInformations.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync( PersonalInformation entity )
        {
            _context.PersonalInformations.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PersonalInformation>> GetPaginatedAsync( int pageNumber, int pageSize )
        {
            // Calculate the number of items to skip
            int itemsToSkip = (pageNumber - 1) * pageSize;

            // Retrieve the subset of data based on pagination parameters
            return await _context.PersonalInformations
                .Skip(itemsToSkip)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
