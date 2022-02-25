using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApplication.DAL.Interfaces;
using TestApplication.Model;

namespace TestApplication.DAL.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(DbSet<City> cities) : base(cities)
        {
        }

        public async Task<IList<City>> GetCitiesByCountry(long countryId, string? search, int startIndex, int pageSize)
        {
            var query = _dbSet
                .Where(c => c.CountryId == countryId);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query
                    .Where(c => c.Name.Contains(search));
            }
            
            var cities = await query
                .OrderBy(c => c.Name)
                .Skip(startIndex)
                .Take(pageSize)
                .ToListAsync();

            return cities;
        }

        public async Task<long> GetCount()
        {
            return await _dbSet.LongCountAsync();
        }
    }
}