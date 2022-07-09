using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        // IGenericRepository<object> _MovementRepository = !default;
        // MovementService _movementService = !default;

        [TestInitialize]
        public void Init()
        {
            //_movementRepository = Substitute.For<IGenericRepository<Domain.Entities.Movement>>();
            //_movementService = new MovementService(_movementRepository);
        }
        /*
        [TestMethod]
        public async Task FailToRegisterMovement()
        {
            try
            {
                Domain.Entities.Movement newMovement = new()
                {
                };
                await _movementService.RegisterMovementAsync(newMovement);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is RegisterException);
            }
        }

        [TestMethod]
        public async Task SuccessToRegisterMovement()
        {
            ProjectMicroDapper.Domain.Entities.Movement newMovement = new()
            {
                Name = "Carlos",
                Age = "24",
                Email = "carl@email.com",
            };

            _movementRepository.AddAsync(Arg.Any<Domain.Entities.Movement>()).Returns(Task.FromResult(
                new MovementDataBuilder()
                    .WithName(newMovement.FirstName)
                    .WithLastName(newMovement.LastName)
                    .WithEmail(newMovement.Email)
                    .WithDateOfBirth(newMovement.DateOfBirth).Build()
            ));

            var result = await _movementService.RegisterMovementAsync(older);

            Assert.IsTrue(result is ProjectMicroDapper.Domain.Entities.Movement && result?.Id is not null);
        }
        */

    }

}
