using DojoProject.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Account.Command
{
    public class AccountDeleteHandler : AsyncRequestHandler<AccountDeleteCommand>
    {
        private readonly AccountService _accountService;

        public AccountDeleteHandler(AccountService accountService)
        {
            _accountService = accountService
                ?? throw new ArgumentNullException(nameof(accountService));
        }

        protected override async Task Handle(AccountDeleteCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request),
                "Se necesita un objeto request para realizar esta Task");
            await _accountService.DeleteAccountAsync(
                request.Id
                );
        }

    }
}
