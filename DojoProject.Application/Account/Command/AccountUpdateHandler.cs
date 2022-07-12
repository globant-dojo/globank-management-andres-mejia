using DojoProject.Application.Account.Dtos;
using DojoProject.Application.Ports;
using DojoProject.Application.Report.Dtos;
using DojoProject.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Account.Command
{
    public class AccountUpdateHandler : IRequestHandler<AccountUpdateCommand, GuidResultDto>
    {
        private readonly AccountService _accountService;

        public AccountUpdateHandler(AccountService _accountService)
        {
            this._accountService = _accountService;
        }

        

        async Task<GuidResultDto> IRequestHandler<AccountUpdateCommand, GuidResultDto>.Handle(AccountUpdateCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request),
                            "El objeto request es necesatio para esta Task");

            var resultAccount = await _accountService.UpdateAccountAsync(
                new Domain.Entities.Account
                {
                    Account_Number = request.Account_Number,
                    Type = request.Type,
                    State = request.State,
                    Initial_Balance = request.Initial_Balance
                }
                );
            return new GuidResultDto { id = resultAccount.Id };
        }
    }
}
