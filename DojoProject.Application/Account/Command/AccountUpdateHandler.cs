using DojoProject.Application.Account.Dtos;
using DojoProject.Application.Ports;
using DojoProject.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Account.Command
{
    public class AccountUpdateHandler : IRequest<AccountUpdateCommand>
    {
        private readonly AccountService _accountService;

        public AccountUpdateHandler(AccountService _accountService)
        {
            this._accountService = _accountService;
        }

        protected async Task<Domain.Entities.Account> Handle(AccountUpdateCommand request , CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request) ,
                "El objeto request es necesatio para esta Task");

            return await _accountService.UpdateAccountAsync(
                new Domain.Entities.Account
                {
                    Account_Number = request.Account_Number,
                    Client = request.Client,
                    Initial_Balance = request.Initial_Balance,
                    Type = request.Type,
                    State = request.State,
                    Id = request.Guid
                }
                );

        }
        
    }
}
