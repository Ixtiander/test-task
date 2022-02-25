
namespace TestApplication.DAL.Interfaces
{
    public interface IApplicationDbContext
    {
        ICountryRepository CountryRepository { get; }
        ICityRepository CityRepository { get; }

        public void Migrate();
    }
}
