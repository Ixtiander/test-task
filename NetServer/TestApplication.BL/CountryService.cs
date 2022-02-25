using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.BL.Interfaces;
using TestApplication.DAL.Interfaces;
using TestApplication.ViewModel;

namespace TestApplication.BL
{
    public class CountryService : ICountryService
    {
        private readonly IApplicationDbContext _dbContext;

        public CountryService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EntityViewModel>> GetCountries()
        {
            var countries = await _dbContext.CountryRepository
                .GetAll();

            return countries.Select(c => new EntityViewModel
            {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
