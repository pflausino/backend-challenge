using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SquareMetersValue.Domain.Queries;

namespace SquareMetersValue.Api.Controllers
{
    [ApiController]
    [Route("api/v1/property-statistic")]
    public class PropertyStatisticController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PropertyStatisticController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/api/v1/city/{cityId}/property-statistic")]
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
