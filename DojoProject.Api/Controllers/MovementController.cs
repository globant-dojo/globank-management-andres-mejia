using DojoProject.Application.Movement.Command;
using DojoProject.Application.Movement.Dtos;
using DojoProject.Application.Movement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DojoProject.Api.Controllers
{
    [ApiController]
    [Route("movementes")]
    public class MovementController
    {
        readonly IMediator _mediator = default!;

        public MovementController(IMediator mediator)
            => _mediator = mediator
            ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("{id}")]
        public async Task<MovementDto> Get(Guid id) => await _mediator.Send(new MovementQuery(id));

        [HttpPost]
        public async Task Post(MovementCreateCommand movement) => await _mediator.Send(movement);

        [HttpPut]
        public async Task Put(MovementCreateCommand movement, Guid id)
        {

            var movementUpdateRequest = new MovementUpdateCommand(
                id, movement.Type, movement.Balance, movement.Value, movement.Account
            );

            await _mediator.Send(movementUpdateRequest);
        }
        [HttpDelete("{id}")]
        public async Task Delete(MovementDeleteCommand movement, Guid id) => await _mediator.Send(movement);
    }
}
