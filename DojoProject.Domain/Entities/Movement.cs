using DojoProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Entities
{
    public class Movement : EntityBase<Guid>
    {
        public MovementType Type { get; set; }
        public int Value { get; set; } = 0;
        public int Balance { get; set; } = 0;

        public Account Account { get; set; }

        public Movement(MovementType type, int value, int balance, Account account)
        {
            Type = type;
            Value = value;
            Balance = balance;
            Account = account;
        }

        public Movement()
        {
        }

        public enum MovementType { Credito, Debito};


    }
}
