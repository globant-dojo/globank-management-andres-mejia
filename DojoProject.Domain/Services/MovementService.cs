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
    public class MovementService
    {
        readonly IGenericRepository<Movement> _repository;

        public MovementService(IGenericRepository<Movement> repository)
        {
            _repository = repository ?? 
                throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Movement> RegisterMovementAsync(Movement movement)
        {
            if (movement.Balance > 0)            
                movement.Type = Movement.MovementType.Credito;
            if (movement.Balance < 0)
                movement.Type = Movement.MovementType.Debito;
            if (movement.Balance == 0 
                && movement.Type == Movement.MovementType.Debito)
                throw new BalanceZeroException("Saldo No Disponible");

            movement.Balance += movement.Value;

            return await _repository.AddAsync(movement);
        }


        public async Task<Movement> UpdateMovementAsync(Movement movement)
        {
            var oldMovement = await _repository.GetByIdAsync(movement.Id);

            if (oldMovement == null)
                throw new RegisterMovementException("No se ha encontrado el movemente");

            await _repository.UpdateAsync(movement);
            return movement;
        }

        public async Task DeleteMovementAsync(Guid movementId)
        {
            var movementDelete = await _repository.GetByIdAsync(movementId);
            if (movementDelete == null)
                throw new RegisterMovementException("No se ha encontrado el movemente");

            await _repository.DeleteAsync(movementDelete);
        }
    }
}
