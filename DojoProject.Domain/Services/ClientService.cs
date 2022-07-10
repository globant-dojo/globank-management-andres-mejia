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
                throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Client> RegisterClientAsync(Client client)
        {
            if (client != null)
                return await _repository.AddAsync(client);
            throw new RegisterClientException();

        }
    }
}
