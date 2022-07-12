using DojoProject.Application.Report.Dtos;
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
        [Required] Guid movementId,
        [Required] MovementType Type,
        [Required] int Balance,
        [Required] int Value


        ) : IRequest<GuidResultDto>;
}
