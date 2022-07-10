using DojoProject.Domain.Entities;
using DojoProject.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Services
{
    [DomainService]
    public class AccountService
    {
        readonly IGenericRepository<Account> _repository;

        public AccountService(IGenericRepository<Account> repository)
        {
            _repository = repository ?? throw 
                new ArgumentNullException(nameof(repository));
        }

        public async Task<Account> RegisterAccountAsync(Account account)
        {
            if (account == null)
            {
                return await _repository.AddAsync(account);
            }
            throw new ArgumentNullException(nameof(account));

        }
    }
}
