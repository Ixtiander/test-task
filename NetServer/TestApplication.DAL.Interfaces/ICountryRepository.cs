
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.Model;

namespace TestApplication.DAL.Interfaces
{
    public interface ICountryRepository
    {
        Task<IList<Country>> GetAll();
    }
}
