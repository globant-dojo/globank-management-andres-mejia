using DojoProject.Application.Account.Command;
using DojoProject.Application.Account.Dtos;
using DojoProject.Application.Account.Queries;
using DojoProject.Application.Report.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DojoProject.Api.Controllers
{
    [ApiController]
    [Route("cuentas")]
    public class AccountController
    {
        readonly IMediator _mediator = default!;

        public AccountController(IMediator mediator)
            => _mediator = mediator
            ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("{id}")]
        public async Task<AccountDto> Get(Guid id) => await _mediator.Send(new AccountQuery(id));

        [HttpPost]
        public async Task<GuidResultDto> Post(AccountCreateCommand account) => await _mediator.Send(account);

        [HttpPut]
        public async Task<GuidResultDto> Put(AccountUpdateCommand account, Guid id)
        {

            var accountUpdateRequest = new AccountUpdateCommand(
                id, account.Account_Number, account.Type, account.Initial_Balance,
                account.State
            );

            await _mediator.Send(accountUpdateRequest);

            return new GuidResultDto { id = accountUpdateRequest.Guid };
        }
        [HttpDelete("{id}")]
        public async Task Delete(Guid id) => await _mediator.Send(new AccountDeleteCommand(id));
    }
}
