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

namespace DojoProject.Domain.Tests.Client
{
    [TestClass]
    public class ClientServiceTest
    {
        IGenericRepository<Entities.Client> _clientRepository = default!;
        ClientService _clientService = default!;

        [TestInitialize]
        public void Init()
        {
            _clientRepository = Substitute.For<IGenericRepository<Domain.Entities.Client>>();
            _clientService = new ClientService(_clientRepository);
        }
        
        [TestMethod]
        public async Task FailToRegisterClient()
        {
            try
            {
                Domain.Entities.Client newClient = null;
                await _clientService.RegisterClientAsync(newClient);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is RegisterClientException);
            }
        }

        [TestMethod]
        public async Task SuccessToRegisterClient()
        {
            Domain.Entities.Client newClient = new()
            {
                Id = Guid.NewGuid(),
                Name = "Carlos",
                Age = "24",
                Address = "Cra 23 # 23",
                Gender = Entities.Person.GenderType.Masculino,
                Identification = "12312312",
                Password = "Password",
                State = true
            };

            _clientRepository.AddAsync(Arg.Any<Domain.Entities.Client>()).Returns(Task.FromResult(
                new ClientDataBuilder()
                    .WithName(newClient.Name)
                    .WithAddress(newClient.Address)
                    .WithGender(newClient.Gender)
                    .WithIdentification(newClient.Identification)
                    .WithAge(newClient.Age)
                    .WithState(newClient.State)
                    .Build()
            ));

            var result = await _clientService.RegisterClientAsync(newClient);

            Assert.IsTrue(result is Domain.Entities.Client && result?.Id is not null);
        }
        
    }

}
