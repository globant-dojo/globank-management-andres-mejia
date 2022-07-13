using DojoProject.Application.Report.Dtos;
using DojoProject.Domain.Ports;
using DojoProject.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Movement.Command
{
    public class MovementCreateHandler : IRequestHandler<MovementCreateCommand, GuidResultDto>
    {
        private readonly MovementService _clientService;
        private readonly AccountService _accountService;

        private readonly IGenericRepository<Domain.Entities.Account> _repository;

        public MovementCreateHandler(MovementService clientService, AccountService accountService, IGenericRepository<Domain.Entities.Account> repository)
        {
            _repository = repository;
            _clientService = clientService
                ?? throw new ArgumentNullException(nameof(clientService));
            _accountService = accountService
                ?? throw new ArgumentNullException(nameof(accountService));

        }





        async Task<GuidResultDto> IRequestHandler<MovementCreateCommand, GuidResultDto>.Handle(MovementCreateCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request),
                                        "Se necesita un objeto request para realizar esta Task");

            var actualAccount = await _repository.GetByIdAsync(request.AccountId);
            if (actualAccount == null)
                throw new ArgumentNullException(nameof(actualAccount), "La cuenta no existe");

            Guid guidResult = Guid.NewGuid();
            actualAccount.Initial_Balance += request.Value;
            await _clientService.RegisterMovementAsync(
                new Domain.Entities.Movement
                {
                    Id = guidResult,
                    Balance = request.Value + actualAccount.Initial_Balance,
                    Value = request.Value,
                    Type = request.Type,
                    Account = actualAccount,
                }
            );

            await _accountService.UpdateAccountAsync(
                actualAccount
                );

            return new GuidResultDto { id = guidResult };
        }
    }
}
