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
    public class MovementCreateHandler : IRequest<MovementCreateCommand>
    {
        private readonly MovementService _accountService;

        public MovementCreateHandler(MovementService accountService)
        {
            _accountService = accountService 
                ?? throw new ArgumentNullException(nameof(accountService));
        }

        protected async Task Handle(MovementCreateCommand request ,
            CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request) ,
                "Se necesita un objeto request para realizar esta Task");

            await _accountService.RegisterMovementAsync(
                new Domain.Entities.Movement
                {
                    Account = request.Account,
                    Balance = request.Balance,
                    Type = request.Type,
                    Value = request.Value,
                }

            );
        }
    }
}
