using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DojoProject.Domain.Entities;

using static DojoProject.Domain.Entities.Account;
using DojoProject.Application.Report.Dtos;

namespace DojoProject.Application.Account.Command
{
    public record AccountCreateCommand(
            
            [Required] int Account_Number,
            [Required] AccountType Type,
            [Required] int Initial_Balance,
            [Required] bool State,
            [Required] Guid ClientId

        ) : IRequest<GuidResultDto>;
    
}
