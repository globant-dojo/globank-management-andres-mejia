using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        // IGenericRepository<object> _AccountRepository = !default;
        // AccountService _accountService = !default;

        [TestInitialize]
        public void Init()
        {
            //_accountRepository = Substitute.For<IGenericRepository<Domain.Entities.Account>>();
            //_accountService = new AccountService(_accountRepository);
        }
        /*
        [TestMethod]
        public async Task FailToRegisterAccount()
        {
            try
            {
                Domain.Entities.Account newAccount = new()
                {
                };
                await _accountService.RegisterAccountAsync(newAccount);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is RegisterException);
            }
        }

        [TestMethod]
        public async Task SuccessToRegisterAccount()
        {
            ProjectMicroDapper.Domain.Entities.Account newAccount = new()
            {
                Name = "Carlos",
                Age = "24",
                Email = "carl@email.com",
            };

            _accountRepository.AddAsync(Arg.Any<Domain.Entities.Account>()).Returns(Task.FromResult(
                new AccountDataBuilder()
                    .WithName(newAccount.FirstName)
                    .WithLastName(newAccount.LastName)
                    .WithEmail(newAccount.Email)
                    .WithDateOfBirth(newAccount.DateOfBirth).Build()
            ));

            var result = await _accountService.RegisterAccountAsync(older);

            Assert.IsTrue(result is ProjectMicroDapper.Domain.Entities.Account && result?.Id is not null);
        }
        */
    }

}
