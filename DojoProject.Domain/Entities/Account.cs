using DojoProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Entities
{
    public class Account : EntityBase<Guid>
    {
        public int Account_Number { get; set; }
        public AccountType Type { get; set; }
        public int Initial_Balance { get; set; } = 0;
        public bool State { get; set; } = true;

        public Client Client { get; set; }

        public ICollection<Movement> Movements { get; set; }

        public Account(int account_Number, AccountType type, int initial_Balance, bool state)
        {
            Account_Number = account_Number;
            Type = type;
            Initial_Balance = initial_Balance;
            State = state;
        }

        public Account()
        {

        }

        public enum AccountType { Ahorro, Corriente }
    }
}
