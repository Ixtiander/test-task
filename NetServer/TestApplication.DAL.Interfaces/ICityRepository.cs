using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.Model;

namespace TestApplication.DAL.Interfaces
{
    public interface ICityRepository
    {
        Task<IList<City>> GetCitiesByCountry(long countryId, string? search, int startIndex, int pageSize);
        Task<long> GetCount();
    }
}