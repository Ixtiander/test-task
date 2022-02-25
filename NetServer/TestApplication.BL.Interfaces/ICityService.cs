using System.Threading.Tasks;
using TestApplication.ViewModel;

namespace TestApplication.BL.Interfaces
{
    public interface ICityService
    {
        Task<PagedResponse<EntityViewModel>> GetCities(long countryId, string? search, int startIndex, int pageSize);
    }
}