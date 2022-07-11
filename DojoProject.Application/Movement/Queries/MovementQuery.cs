using DojoProject.Application.Movement.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Movement.Queries
{
    public record MovementQuery([Required] Guid Id) : IRequest<MovementDto>;
}
