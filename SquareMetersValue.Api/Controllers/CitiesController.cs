using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SquareMetersValue.Domain.Infra.Interfaces;
using SquareMetersValue.Domain.Models;
using SquareMetersValue.Domain.ViewModel;

namespace SquareMetersValue.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICitiesRepository citiesRepository, IMapper mapper)
        {
            _citiesRepository = citiesRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all cities Avaiable
        /// </summary>
        /// <response code="200">List of Cities</response>
        /// <response code="500">Oops! The Server is unavailable</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _citiesRepository.GetAll();
            if (!cities.Any())
                return Ok(cities);

            var citiesVM = _mapper.Map<List<CityViewModel>>(cities);          
            return Ok(citiesVM);

        }
    }
}
