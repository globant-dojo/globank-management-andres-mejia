using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DojoProject.Domain.Entities;

using static DojoProject.Domain.Entities.Movement;
using DojoProject.Application.Report.Dtos;

namespace DojoProject.Application.Movement.Command
{
    public record MovementCreateCommand(
            
            [Required] MovementType Type,
            [Required] int Balance,
            [Required] int Value,
            [Required] Guid AccountId

        ) : IRequest<GuidResultDto>;
    
}
