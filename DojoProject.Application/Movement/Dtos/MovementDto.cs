using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DojoProject.Domain.Entities.Movement;

namespace DojoProject.Application.Movement.Dtos
{
    public class MovementDto
    {
        public MovementDto()
        {
        }

        public MovementType Type { get; set; }
        public int Value { get; set; } = 0;
        public int Balance { get; set; } = 0;

        public DateTime Date { get; set; }

        public Domain.Entities.Account Account { get; set; }


    }
}
