using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Commands;

namespace VendingMachine.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MachineController : ControllerBase
    {
        private readonly IMediator mediator;

        public MachineController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateMachineCommand command)
        {
            if (command == null)
            {
                return this.BadRequest();
            }

            var result = await this.mediator.Send(command);
            if (result)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }
    }
}