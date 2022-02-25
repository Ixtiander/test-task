using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApplication.BL.Interfaces;
using TestApplication.ViewModel;

namespace TestApplication.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<PagedResponse<EntityViewModel>> Index(long countryId, string? search, int start, int pageSize)
        {
            return await _cityService.GetCities(countryId, search, start, pageSize);
        }
    }
}