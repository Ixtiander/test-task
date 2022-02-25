using Microsoft.EntityFrameworkCore;
using TestApplication.DAL.Interfaces;
using TestApplication.DAL.Repositories;
using TestApplication.Model;

namespace TestApplication.DAL
{
    public class ApplicationDbContext : DbContext,  IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public void Migrate()
        {
            Database.SetCommandTimeout(100);
            Database.Migrate();
        }

        private DbSet<Country> Country { get; set; }
        private DbSet<City> City { get; set; }
        
        private ICountryRepository? _countryRepository;
        public ICountryRepository CountryRepository => _countryRepository ??= new CountryRepository(Country);


        private ICityRepository? _cityRepository;
        public ICityRepository CityRepository => _cityRepository ??= new CityRepository(City);

    }
}