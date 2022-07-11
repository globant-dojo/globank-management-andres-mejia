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
    public class AccountDeleteHandler : IRequest<AccountDeleteCommand>
    {
        private readonly AccountService _clientService;

        public AccountDeleteHandler(AccountService clientService)
        {
            _clientService = clientService
                ?? throw new ArgumentNullException(nameof(clientService));
        }

        protected async Task Handle(AccountDeleteCommand request , 
            CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request),
                "Se necesita un objeto request para realizar esta Task");
            await _clientService.DeleteAccountAsync(
                request.Id
                );
        }
    }
}
