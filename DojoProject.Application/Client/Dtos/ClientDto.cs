using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Client.Dtos
{
    public class ClientDto : PersonDto
    {
        public string Password { get; set; }
        public bool State { get; set; }
    }
}
