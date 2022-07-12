using AutoMapper;
using DojoProject.Application.Client.Dtos;
using DojoProject.Domain.Exceptions;
using DojoProject.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Client.Queries
{
    public class ClientQueryHandler : IRequestHandler<ClientQuery, ClientDto>, IDisposable
    {

        private readonly IGenericRepository<Domain.Entities.Client> _repository;
        private IMapper _mapper;

        public ClientQueryHandler(IGenericRepository<Domain.Entities.Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<ClientDto> Handle(ClientQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request requerido");

            var result = await _repository.GetByIdAsync(request.Id);
            if (result == null)
                throw new RegisterClientException("Cliente no Encontrado");
            return new ClientDto
            {
                Address = result.Address,
                Age = result.Age,
                Gender = result.Gender,
                Identification = result.Identification,
                Name = result.Name,
                Password = result.Password,
                State = result.State                
            };
        }

        protected virtual void Dispose(bool disposing)
        {
            this._repository.Dispose();
        }

    }
}
