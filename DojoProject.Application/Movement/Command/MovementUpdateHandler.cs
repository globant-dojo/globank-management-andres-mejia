using DojoProject.Application.Ports;
using DojoProject.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Movement.Command
{
    public class MovementUpdateHandler : IRequest<MovementUpdateCommand>
    {
        private readonly MovementService _accountService;

        public MovementUpdateHandler(MovementService _accountService)
        {
            this._accountService = _accountService;
        }

        protected async Task<Domain.Entities.Movement> Handle(MovementUpdateCommand request , CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request) ,
                "El objeto request es necesatio para esta Task");

            return await _accountService.UpdateMovementAsync(
                new Domain.Entities.Movement
                {
                    Account = request.Account,
                    Balance = request.Balance,
                    Id = request.Guid,
                    Type = request.Type,
                    Value = request.Value,
                }
                );

        }
        
    }
}
