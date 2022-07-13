using AutoMapper;
using DojoProject.Application.Movement.Dtos;
using DojoProject.Domain.Exceptions;
using DojoProject.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Movement.Queries
{
    public class MovementQueryHandler : IRequestHandler<MovementQuery, MovementDto>, IDisposable
    {

        private readonly IGenericRepository<Domain.Entities.Movement> _repository;
        private IMapper _mapper;

        public MovementQueryHandler(IGenericRepository<Domain.Entities.Movement> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<MovementDto> Handle(MovementQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request requerido");

            var result = await _repository.GetByIdAsync(request.Id);
            if (result == null)
                throw new RegisterMovementException("No se encuentra la cuenta");
            return new MovementDto
            {
                Date = result.Date,
                Account = result.Account,
                Balance = result.Balance,
                Type = result.Type,
                Value = result.Value,
            };
        }

        protected virtual void Dispose(bool disposing)
        {
            this._repository.Dispose();
        }

    }
}
