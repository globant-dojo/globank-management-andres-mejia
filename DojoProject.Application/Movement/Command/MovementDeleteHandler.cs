using DojoProject.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Movement.Command
{
    public class MovementDeleteHandler : AsyncRequestHandler<MovementDeleteCommand>
    {
        private readonly MovementService _movementService;

        public MovementDeleteHandler(MovementService movementService)
        {
            _movementService = movementService
                ?? throw new ArgumentNullException(nameof(movementService));
        }

        protected override async Task Handle(MovementDeleteCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request),
                "Se necesita un objeto request para realizar esta Task");
            await _movementService.DeleteMovementAsync(
                request.Id
                );
        }

    }
}
