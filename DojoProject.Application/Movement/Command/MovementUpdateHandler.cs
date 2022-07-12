using DojoProject.Application.Movement.Dtos;
using DojoProject.Application.Ports;
using DojoProject.Application.Report.Dtos;
using DojoProject.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Movement.Command
{
    public class MovementUpdateHandler : IRequestHandler<MovementUpdateCommand, GuidResultDto>
    {
        private readonly MovementService _movementService;

        public MovementUpdateHandler(MovementService _movementService)
        {
            this._movementService = _movementService;
        }



        async Task<GuidResultDto> IRequestHandler<MovementUpdateCommand, GuidResultDto>.Handle(MovementUpdateCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request),
                            "El objeto request es necesatio para esta Task");

            var resultMovement = await _movementService.UpdateMovementAsync(
                new Domain.Entities.Movement
                { 
                    Id = request.movementId,
                    Type = request.Type,
                    Balance = request.Balance,
                    Value = request.Value,
                }
                );
            return new GuidResultDto { id = resultMovement.Id };
        }
    }
}
