using DojoProject.Domain.Entities;
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

namespace DojoProject.Domain.Tests.Movement
{
    [TestClass]
    public class MovementServiceTest
    {
        IGenericRepository<DojoProject.Domain.Entities.Movement> _movementRepository = default!;
        MovementService _movementService = default!;

        [TestInitialize]
        public void Init()
        {
            _movementRepository = Substitute.For<IGenericRepository<Domain.Entities.Movement>>();
            _movementService = new MovementService(_movementRepository);
        }

        [TestMethod]
        public async Task FailToRegisterMovement()
        {
            try
            {
                Entities.Account notExistAccount = new();
                Domain.Entities.Movement newMovement = new()
                {
                    Account = notExistAccount,
                    Value = -1000,
                };
                await _movementService.RegisterMovementAsync(newMovement);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is RegisterMovementException);
            }
        }

        [TestMethod]
        public async Task FailToRegisterMovementZeroBalance()
        {
            try
            {
                Entities.Account notExistAccount = new();
                Domain.Entities.Movement newMovement = new()
                {
                    Balance = 0,
                    Account = notExistAccount,
                    Value = -1000,
                };
                await _movementService.RegisterMovementAsync(newMovement);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is BalanceZeroException);
            }
        }

        [TestMethod]
        public async Task SuccessToRegisterCreditMovement()
        {
            try
            {
                Guid guid_Client = Guid.NewGuid();
                Guid guid_Account = Guid.NewGuid();
                Guid guid_Movement = Guid.NewGuid();

                DojoProject.Domain.Entities.Client newClient = new()
                {
                    Name = "Client Testing",
                    Address = "Av Test # 1-1",
                    Age = "21",
                    Gender = Person.GenderType.Masculino,
                    State = true,
                    Identification = "123123",
                    Id = guid_Client,
                    Password = "Test"

                };
                DojoProject.Domain.Entities.Account newAccount = new()
                {
                    Id = guid_Account,
                    Type = Entities.Account.AccountType.Ahorro,
                    Account_Number = 1,
                    Client = newClient

                };
                DojoProject.Domain.Entities.Movement newMovement = new()
                {
                    Id = guid_Movement,
                    Account = newAccount,
                    Value = 1000

                };

                _movementRepository.AddAsync(Arg.Any<DojoProject.Domain.Entities.Movement>()).Returns(Task.FromResult(
                    new MovementDataBuilder()
                            .WithType(newMovement.Type)
                            .WithBalance(newMovement.Balance)
                            .WithAccount(newAccount)
                            .WithValue(newMovement.Value).Build()
                ));

                var result = await _movementService.RegisterMovementAsync(newMovement);

                Assert.IsTrue(result is DojoProject.Domain.Entities.Movement && result?.Id is not null);

            }
            catch (System.Exception)
            {

                throw;
            }

        }


    }

}
