using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.ViewModel;

namespace TestApplication.BL.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<EntityViewModel>> GetCountries();
    }
}
