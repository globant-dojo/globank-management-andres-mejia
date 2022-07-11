using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Movement.Command
{
    public record MovementDeleteCommand([Required] Guid Id) : IRequest;
}
