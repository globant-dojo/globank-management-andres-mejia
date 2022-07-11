using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DojoProject.Domain.Entities.Person;

namespace DojoProject.Application.Client.Dtos
{
    public class PersonDto
    {
        public PersonDto()
        {
        }

        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public string Age { get; set; }
        public string Identification { get; set; }
        public string Address { get; set; }


    }
}
