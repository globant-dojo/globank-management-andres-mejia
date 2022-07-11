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

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            var oldAccount = await _repository.GetByIdAsync(account.Id);

            if (oldAccount == null)
                throw new RegisterAccountException("No se ha encontrado el accounte");

            await _repository.UpdateAsync(account);
            return account;
        }

        public async Task DeleteAccountAsync(Guid id)
        {
            var accountDelete = await _repository.GetByIdAsync(id);
            if (accountDelete == null)
                throw new RegisterClientException("No se ha encontrado la cuenta");

            await _repository.DeleteAsync(accountDelete);
        }
    }
}
