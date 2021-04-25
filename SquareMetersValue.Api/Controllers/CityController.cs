using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SquareMetersValue.Domain.Infra.Interfaces;

namespace SquareMetersValue.Api.Controllers
{
    [ApiController]
    [Route("api/v1/cities")]
    public class CityController : ControllerBase
    {
        private readonly ICitiesRepository _citiesRepository;
        public CityController(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _citiesRepository.GetAll();

            return Ok(cities);

        }
    }
}
