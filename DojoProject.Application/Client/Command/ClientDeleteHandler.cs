using DojoProject.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Client.Command
{
    public class ClientDeleteHandler : AsyncRequestHandler<ClientDeleteCommand>
    {
        private readonly ClientService _clientService;

        public ClientDeleteHandler(ClientService clientService)
        {
            _clientService = clientService
                ?? throw new ArgumentNullException(nameof(clientService));
        }

        protected override async Task Handle(ClientDeleteCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request),
                "Se necesita un objeto request para realizar esta Task");
            await _clientService.DeleteClientAsync(
                request.Id
                );
        }

    }
}
