using DojoProject.Application.Client.Command;
using DojoProject.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Movement.Command
{
    public class MovementDeleteHandler : IRequest<MovementDeleteCommand>
    {
        private readonly MovementService _clientService;

        public MovementDeleteHandler(MovementService clientService)
        {
            _clientService = clientService
                ?? throw new ArgumentNullException(nameof(clientService));
        }

        protected async Task Handle(MovementDeleteCommand request , 
            CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request),
                "Se necesita un objeto request para realizar esta Task");
            await _clientService.DeleteMovementAsync(
                request.Id
                );
        }
    }
}
