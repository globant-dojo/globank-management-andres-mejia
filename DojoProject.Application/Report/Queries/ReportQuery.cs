using DojoProject.Application.Report.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Report.Queries
{
    public record ReportQuery(
        [Required] DateTime dateInit,
        [Required] DateTime dateEnd,
        [Required] Guid ClientId
        ) : IRequest<ReportsDto>;
}
