using DojoProject.Application.Client.Command;
using DojoProject.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Account.Command
{
    public class AccountCreateHandler : IRequest<AccountCreateCommand>
    {
        private readonly AccountService _accountService;

        public AccountCreateHandler(AccountService accountService)
        {
            _accountService = accountService 
                ?? throw new ArgumentNullException(nameof(accountService));
        }

        protected async Task Handle(AccountCreateCommand request ,
            CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request) ,
                "Se necesita un objeto request para realizar esta Task");

            await _accountService.RegisterAccountAsync(
                new Domain.Entities.Account
                {
                    Account_Number = request.Account_Number,
                    Client = request.Client,
                    Initial_Balance = request.Initial_Balance,
                    State = request.State,
                    Type = request.Type,
                }

            );
        }
    }
}
