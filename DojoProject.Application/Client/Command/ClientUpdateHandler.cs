using DojoProject.Application.Client.Dtos;
using DojoProject.Application.Ports;
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
    public class ClientUpdateHandler : IRequestHandler<ClientUpdateCommand, GuidResultDto>
    {
        private readonly ClientService _clienService;

        public ClientUpdateHandler(ClientService _clienService)
        {
            this._clienService = _clienService;
        }

        

        async Task<GuidResultDto> IRequestHandler<ClientUpdateCommand, GuidResultDto>.Handle(ClientUpdateCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request),
                            "El objeto request es necesatio para esta Task");

            var resultClient = await _clienService.UpdateClientAsync(
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
            return new GuidResultDto { id = resultClient.Id };
        }
    }
}
