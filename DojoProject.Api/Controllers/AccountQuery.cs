using DojoProject.Application.Account.Dtos;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DojoProject.Api.Controllers
{
    public record AccountQuery([Required] Guid Id) : IRequest<AccountDto>;
}
