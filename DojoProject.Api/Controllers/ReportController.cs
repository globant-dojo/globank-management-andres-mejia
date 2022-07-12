using DojoProject.Application.Report.Dtos;
using DojoProject.Application.Report.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DojoProject.Api.Controllers
{
    [ApiController]
    [Route("reportes")]
    public class ReportController
    {
        readonly IMediator _mediator = default!;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ReportsDto> Get(DateTime dateInit, DateTime dateEnd, Guid clientId) => await _mediator.Send(new ReportQuery( dateInit , dateEnd , clientId));
    }
}
