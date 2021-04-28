using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SquareMetersValue.Domain.Infra.Interfaces;

namespace SquareMetersValue.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesRepository _citiesRepository;
        public CitiesController(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }
        /// <summary>
        /// Get all cities Avaiable
        /// </summary>
        /// <response code="200">List of Cities</response>
        /// <response code="400">Not Found</response>
        /// <response code="500">Oops! The Server is unavailable</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _citiesRepository.GetAll();

            return Ok(cities);

        }
    }
}
