using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Entities
{
    public class Client : Person
    {
        [StringLength(255)]
        public string Password { get; set; }
        [StringLength(255)]
        public string State { get; set; }

        public Client(string password, string state)
        {
            Password = password;
            State = state;
        }

        public Client()
        {
        }
    }
}
