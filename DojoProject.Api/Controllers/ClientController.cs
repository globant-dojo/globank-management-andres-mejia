using DojoProject.Application.Client.Command;
using DojoProject.Application.Client.Dtos;
using DojoProject.Application.Client.Queries;
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
        public async Task Post(ClientCreateCommand client) => await _mediator.Send(client);

        [HttpPut]
        public async Task Put(ClientCreateCommand client, Guid id)
        {

            var clientUpdateRequest = new ClientUpdateCommand(
                id, client.Password, client.State, client.Name,
                client.GenderType, client.Age, client.Identification,
                client.Address
            );

            await _mediator.Send(clientUpdateRequest);
        }
        [HttpDelete("{id}")]
        public async Task Delete(ClientDeleteCommand client, Guid id) => await _mediator.Send(client);
    }
}
