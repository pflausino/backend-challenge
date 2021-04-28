using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SquareMetersValue.Domain.Commands;

namespace SquareMetersValue.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PropertiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Add a Property/Real State to a City
        /// </summary>
        /// <returns>No Content 204</returns>
        /// <response code="200"> </response>
        /// <response code="204">Property added to City </response>
        /// <response code="400">Bad Request</response>  
        [HttpPost]
        public async Task<IActionResult> Post(CreatePropertyCommand command)
        {
            var response = await _mediator.Send(command);

            return NoContent();
        }

    }
}
