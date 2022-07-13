using DojoProject.Application.Account.Dtos;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DojoProject.Application.Account.Queries
{
    public record AccountQuery([Required] Guid Id) : IRequest<AccountDto>;
}
