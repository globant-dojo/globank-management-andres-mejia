using DojoProject.Application.Report.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DojoProject.Domain.Entities.Person;

namespace DojoProject.Application.Client.Command
{
    public record ClientUpdateCommand(
        [Required] Guid Guid,
        [Required] string Password,
        [Required] bool State,
        [Required] string Name,
        [Required] GenderType Gender,
        [Required] string Age,
        [Required] string Identification,
        [Required] string Address

        ) : IRequest<GuidResultDto>;
}
