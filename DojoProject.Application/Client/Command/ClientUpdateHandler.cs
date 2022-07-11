using DojoProject.Application.Client.Dtos;
using DojoProject.Application.Ports;
using DojoProject.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Client.Command
{
    public class ClientUpdateHandler : IRequest<ClientUpdateCommand>
    {
        private readonly ClientService _clienService;

        public ClientUpdateHandler(ClientService _clienService)
        {
            this._clienService = _clienService;
        }

        protected async Task<Domain.Entities.Client> Handle(ClientUpdateCommand request , CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request) ,
                "El objeto request es necesatio para esta Task");

            return await _clienService.UpdateClientAsync(
                new Domain.Entities.Client
                {
                    Address = request.Address,
                    Age = request.Age,
                    Gender = request.Gender,
                    Identification = request.Identification,
                    Name = request.Name,
                    Password = request.Password,
                    State = request.State,
                    Id = request.Guid
                }
                );

        }
        
    }
}
