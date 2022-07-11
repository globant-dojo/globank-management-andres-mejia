using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DojoProject.Domain.Entities;

using static DojoProject.Domain.Entities.Account;

namespace DojoProject.Application.Account.Command
{
    public record AccountCreateCommand(
            
            [Required] int Account_Number,
            [Required] AccountType Type,
            [Required] int Initial_Balance,
            [Required] bool State,
            [Required] Domain.Entities.Client Client

        ) : IRequest;
    
}
