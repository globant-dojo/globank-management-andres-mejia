using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        // IGenericRepository<object> _ClientRepository = !default;
        // ClientService _clientService = !default;

        [TestInitialize]
        public void Init()
        {
            //_clientRepository = Substitute.For<IGenericRepository<Domain.Entities.Client>>();
            //_clientService = new ClientService(_clientRepository);
        }
        /*
        [TestMethod]
        public async Task FailToRegisterClient()
        {
            try
            {
                Domain.Entities.Client newClient = new()
                {
                };
                await _clientService.RegisterClientAsync(newClient);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is RegisterException);
            }
        }

        [TestMethod]
        public async Task SuccessToRegisterClient()
        {
            ProjectMicroDapper.Domain.Entities.Client newClient = new()
            {
                Name = "Carlos",
                Age = "24",
                Email = "carl@email.com",
            };

            _clientRepository.AddAsync(Arg.Any<Domain.Entities.Client>()).Returns(Task.FromResult(
                new ClientDataBuilder()
                    .WithName(newClient.FirstName)
                    .WithLastName(newClient.LastName)
                    .WithEmail(newClient.Email)
                    .WithDateOfBirth(newClient.DateOfBirth).Build()
            ));

            var result = await _clientService.RegisterClientAsync(older);

            Assert.IsTrue(result is ProjectMicroDapper.Domain.Entities.Client && result?.Id is not null);
        }
        */
    }

}
