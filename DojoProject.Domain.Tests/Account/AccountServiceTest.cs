using DojoProject.Domain.Exceptions;
using DojoProject.Domain.Ports;
using DojoProject.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Tests.Account
{
    [TestClass]
    public class AccountServiceTest
    {
        IGenericRepository<Entities.Account> _accountRepository = default!;
        AccountService _accountService = default!;

        [TestInitialize]
        public void Init()
        {
            _accountRepository = Substitute.For<IGenericRepository<Domain.Entities.Account>>();
            _accountService = new AccountService(_accountRepository);
        }
        
        [TestMethod]
        public async Task FailToRegisterAccount()
        {
            try
            {
                Domain.Entities.Account newAccount = null;
                await _accountService.RegisterAccountAsync(newAccount);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is RegisterAccountException);
            }
        }

        [TestMethod]
        public async Task SuccessToRegisterAccount()
        {
            Entities.Client newClient = new()
            {
                Name = "Carlos",
                Age = "24",
                Identification = "1234",
                Password = "1234"
                
            };
            Entities.Account newAccount = new()
            {
                Id = Guid.NewGuid(),
                Client = newClient,
                Account_Number = 4321,
                Initial_Balance = 0,
                State = true,
                Type = Entities.Account.AccountType.Ahorro

            };

            _accountRepository.AddAsync(Arg.Any<Domain.Entities.Account>()).Returns(Task.FromResult(
                new AccountDataBuilder()
                    .WithAccount_Number(newAccount.Account_Number)
                    .WithInitial_Balance(newAccount.Initial_Balance)
                    .WithState(newAccount.State)
                    .WithType(newAccount.Type)
                    .WithClient(newClient)
                    .Build()
            ));

            var result = await _accountService.RegisterAccountAsync(newAccount);

            Assert.IsTrue(result is Domain.Entities.Account && result?.Id is not null);
        }
        
    }

}
