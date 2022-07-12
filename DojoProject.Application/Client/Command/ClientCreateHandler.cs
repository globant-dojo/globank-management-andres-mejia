using DojoProject.Application.Report.Dtos;
using DojoProject.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Client.Command
{
    public class ClientCreateHandler : IRequestHandler<ClientCreateCommand, GuidResultDto>
    {
        private readonly ClientService _clientService;

        public ClientCreateHandler(ClientService clientService)
        {
            _clientService = clientService 
                ?? throw new ArgumentNullException(nameof(clientService));
        }

        

        

        async Task<GuidResultDto> IRequestHandler<ClientCreateCommand, GuidResultDto>.Handle(ClientCreateCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request),
                                        "Se necesita un objeto request para realizar esta Task");

            Guid guidResult = Guid.NewGuid(); 
            await _clientService.RegisterClientAsync(
                new Domain.Entities.Client
                {
                    Id = guidResult,
                    Name = request.Name,
                    Address = request.Address,
                    Age = request.Age,
                    Gender = request.GenderType,
                    Identification = request.Identification,
                    Password = request.Password,
                    State = request.State,
                }
            );

            return new GuidResultDto { id = guidResult};
        }
    }
}
