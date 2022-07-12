using DojoProject.Application.Report.Dtos;
using DojoProject.Domain.Ports;
using DojoProject.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Account.Command
{
    public class AccountCreateHandler : IRequestHandler<AccountCreateCommand, GuidResultDto>
    {
        private readonly AccountService _accountService;
        private readonly IGenericRepository<Domain.Entities.Client> _repository;

        public AccountCreateHandler(AccountService accountService , IGenericRepository<Domain.Entities.Client> repository)
        {
            _repository = repository;
            _accountService = accountService 
                ?? throw new ArgumentNullException(nameof(accountService));
        }





        async Task<GuidResultDto> IRequestHandler<AccountCreateCommand, GuidResultDto>.Handle(AccountCreateCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request),
                                        "Se necesita un objeto request para realizar esta Task");

            var actualClient = await _repository.GetByIdAsync(request.ClientId);

            if (actualClient == null)
                throw new ArgumentException(nameof(actualClient),"El Cliente no existe");

            Guid guidResult = Guid.NewGuid(); 
            await _accountService.RegisterAccountAsync(
                new Domain.Entities.Account
                {
                    Account_Number = request.Account_Number,
                    Initial_Balance = request.Initial_Balance,
                    State = request.State,
                    Type = request.Type,
                    Id = guidResult,
                    Client = actualClient
                }
            );

            return new GuidResultDto { id = guidResult};
        }
    }
}
