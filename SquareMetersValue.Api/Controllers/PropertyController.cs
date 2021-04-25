using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SquareMetersValue.Domain.Commands;

namespace SquareMetersValue.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PropertyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePropertyCommand command)
        {
            var response = await _mediator.Send(command);

            return NoContent();
        }

    }
}
