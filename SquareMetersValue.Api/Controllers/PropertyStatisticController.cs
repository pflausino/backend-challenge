using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SquareMetersValue.Domain.Queries;

namespace SquareMetersValue.Api.Controllers
{
    [ApiController]
    [Route("api/v1/Statistics")]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get Statistic about Real Estate like the price square meter average per city
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns>Return a SquareMeter Average per City</returns>
        /// <response code="400">If the item is null</response>   
        [HttpGet]
        [Route("/api/v1/city/{cityId}/Statistics")]
        public async Task<IActionResult> Get(
            [FromRoute] Guid cityId)
        {
            var query = new CalculateSquareMeterAverageByCityQuery(cityId);
            if (query.Invalid)
                return BadRequest(query.ValidationResult.Errors);

            var result = await _mediator.Send(query);


            return Ok(result.Value);

        }

    }
}
