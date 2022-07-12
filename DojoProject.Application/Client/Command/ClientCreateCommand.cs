using DojoProject.Application.Client.Dtos;
using DojoProject.Application.Report.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Client.Command
{
    public record ClientCreateCommand(
            [Required] string Name,            
            [Required] Domain.Entities.Client.GenderType GenderType,
            [Required] bool State,
            [Required] string Password,
            [Required] string Age,
            [Required] string Identification,
            [Required] string Address
        ) : IRequest<GuidResultDto>;
    
}
