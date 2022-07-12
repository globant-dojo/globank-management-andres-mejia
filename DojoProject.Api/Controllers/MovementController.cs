using DojoProject.Application.Movement.Command;
using DojoProject.Application.Movement.Dtos;
using DojoProject.Application.Movement.Queries;
using DojoProject.Application.Report.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DojoProject.Api.Controllers
{
    [ApiController]
    [Route("movimientos")]
    public class MovementController
    {
        readonly IMediator _mediator = default!;

        public MovementController(IMediator mediator)
            => _mediator = mediator
            ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("{id}")]
        public async Task<MovementDto> Get(Guid id) => await _mediator.Send(new MovementQuery(id));

        [HttpPost]
        public async Task<GuidResultDto> Post(MovementCreateCommand movement) => await _mediator.Send(movement);

        [HttpPut]
        public async Task<GuidResultDto> Put(MovementUpdateCommand movement, Guid id)
        {

            var movementUpdateRequest = new MovementUpdateCommand(
                id, movement.Type, movement.Balance, movement.Value
            );

            await _mediator.Send(movementUpdateRequest);

            return new GuidResultDto { id = movementUpdateRequest.movementId };
        }
        [HttpDelete("{id}")]
        public async Task Delete(Guid id) => await _mediator.Send(new MovementDeleteCommand(id));
    }
}
