using DojoProject.Domain.Entities;
using DojoProject.Domain.Exceptions;
using DojoProject.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Services
{
    public class ClientService
    {
        readonly IGenericRepository<Client> _repository;

        public ClientService(IGenericRepository<Client> repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository), 
                "El repositorio de Clientes no esta disponible");
        }

        public async Task<Client> RegisterClientAsync(Client client)
        {
            if (client != null)
                return await _repository.AddAsync(client);
            throw new RegisterClientException();
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            var oldClient = await _repository.GetByIdAsync(client.Id);

            if (oldClient == null)
                throw new RegisterClientException("No se ha encontrado el cliente");

            await _repository.UpdateAsync(client);
            return client;
        }

        public async Task DeleteClientAsync(Guid clientId)
        {
            var clientDelete = await _repository.GetByIdAsync(clientId);
            if (clientDelete == null)
                throw new RegisterClientException("No se ha encontrado el cliente");

            await _repository.DeleteAsync(clientDelete);
        }
    }
}
