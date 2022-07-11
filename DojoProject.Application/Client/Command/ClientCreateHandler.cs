using DojoProject.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Client.Command
{
    public class ClientCreateHandler : IRequest<ClientCreateCommand>
    {
        private readonly ClientService _clientService;

        public ClientCreateHandler(ClientService clientService)
        {
            _clientService = clientService 
                ?? throw new ArgumentNullException(nameof(clientService));
        }

        protected async Task Handle(ClientCreateCommand request ,
            CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request) ,
                "Se necesita un objeto request para realizar esta Task");

            await _clientService.RegisterClientAsync(
                new Domain.Entities.Client
                {
                    Name = request.Name,
                    Address = request.Address,
                    Age = request.Age,
                    Gender = request.GenderType,
                    Identification = request.Identification,
                    Password = request.Password,
                    State = request.State,
                }

            );
        }
    }
}
