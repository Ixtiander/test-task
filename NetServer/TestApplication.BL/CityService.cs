using System.Linq;
using System.Threading.Tasks;
using TestApplication.BL.Interfaces;
using TestApplication.DAL.Interfaces;
using TestApplication.ViewModel;

namespace TestApplication.BL
{
    public class CityService : ICityService
    {
        private readonly IApplicationDbContext _dbContext;

        public CityService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedResponse<EntityViewModel>> GetCities(long countryId, string? search, int startIndex, int pageSize)
        {
            var cities = await _dbContext.CityRepository.GetCitiesByCountry(countryId, search, startIndex, pageSize);

            var totalCount = await _dbContext.CityRepository.GetCount();

            return new PagedResponse<EntityViewModel>
            {
                Items = cities.Select(c => new EntityViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
                HasMore = startIndex + pageSize < totalCount
            };
        }
    }
}