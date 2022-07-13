using AutoMapper;
using DojoProject.Application.Account.Dtos;
using DojoProject.Domain.Exceptions;
using DojoProject.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Account.Queries
{
    public class AccountQueryHandler : IRequestHandler<AccountQuery, AccountDto>, IDisposable
    {

        private readonly IGenericRepository<Domain.Entities.Account> _repository;
        private IMapper _mapper;

        public AccountQueryHandler(IGenericRepository<Domain.Entities.Account> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<AccountDto> Handle(AccountQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request requerido");

            var result = await _repository.GetByIdAsync(request.Id);
            if (result == null)
                throw new RegisterAccountException("No se encuentra la cuenta");
            return new AccountDto
            {
                Account_Number = result.Account_Number,
                Client = result.Client,
                Initial_Balance = result.Initial_Balance,
                State = result.State,
                Type = result.Type
            };
        }

        protected virtual void Dispose(bool disposing)
        {
            this._repository.Dispose();
        }

    }
}
