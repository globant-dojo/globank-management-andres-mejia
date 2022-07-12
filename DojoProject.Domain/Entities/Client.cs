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
        public bool State { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public Client(string password, bool state, string name,
            Client.GenderType gender, string age, string identification , string address) 
            : base(name, gender, age, identification, address)
        {
            Password = password;
            State = state;
        }

        public Client()
        {
        }
    }
}
