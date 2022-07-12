using DojoProject.Application.Client.Command;
using DojoProject.Application.Client.Dtos;
using DojoProject.Application.Client.Queries;
using DojoProject.Application.Report.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DojoProject.Api.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientController
    {
        readonly IMediator _mediator = default!;

        public ClientController(IMediator mediator)
            => _mediator = mediator
            ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("{id}")]
        public async Task<ClientDto> Get(Guid id) => await _mediator.Send(new ClientQuery(id));

        [HttpPost]
        public async Task<GuidResultDto> Post(ClientCreateCommand client) => await _mediator.Send(client);

        [HttpPut]
        public async Task<GuidResultDto> Put(ClientUpdateCommand client, Guid id)
        {

            var clientUpdateRequest = new ClientUpdateCommand(
                id, client.Password, client.State, client.Name,
                client.Gender, client.Age, client.Identification,
                client.Address
            );

            await _mediator.Send(clientUpdateRequest);

            return new GuidResultDto { id = clientUpdateRequest.Guid };
        }
        [HttpDelete("{id}")]
        public async Task Delete(Guid id) => await _mediator.Send(new ClientDeleteCommand(id));
    }
}
