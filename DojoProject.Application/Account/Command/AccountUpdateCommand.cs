using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DojoProject.Domain.Entities.Account;
using static DojoProject.Domain.Entities.Person;

namespace DojoProject.Application.Account.Command
{
    public record AccountUpdateCommand(
        [Required] Guid Guid,
        [Required] int Account_Number,
        [Required] AccountType Type,
        [Required] int Initial_Balance,
        [Required] bool State,
        [Required] Domain.Entities.Client Client


        ) : IRequest;
}
