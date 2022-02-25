using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApplication.BL.Interfaces;
using TestApplication.ViewModel;

namespace TestApplication.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IEnumerable<EntityViewModel>> Get()
        {
            return await _countryService.GetCountries();
        }
    }
}