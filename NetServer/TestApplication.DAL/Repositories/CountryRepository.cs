using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApplication.DAL.Interfaces;
using TestApplication.Model;

namespace TestApplication.DAL.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(DbSet<Country> countries) : base(countries)
        {
        }

        public async Task<IList<Country>> GetAll()
        {
            return await _dbSet
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
    }
}
