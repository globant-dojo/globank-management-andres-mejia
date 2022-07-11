using DojoProject.Application.Client.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Client.Queries
{
    public record ClientQuery([Required] Guid Id) : IRequest<ClientDto>;
}
