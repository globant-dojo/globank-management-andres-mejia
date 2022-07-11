using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DojoProject.Domain.Entities.Movement;
using static DojoProject.Domain.Entities.Person;

namespace DojoProject.Application.Movement.Command
{
    public record MovementUpdateCommand(
        [Required] Guid Guid,
        [Required] MovementType Type,
        [Required] int Balance,
        [Required] int Value,
        [Required] Domain.Entities.Account Account


        ) : IRequest;
}
