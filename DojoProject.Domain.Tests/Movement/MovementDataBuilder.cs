using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Tests.Movement
{

    public class MovementDataBuilder
    {
        Entities.Movement.MovementType Type = default!;
        int Value = default!;
        int Balance = default!;
        Entities.Account Account = default!;

        public Domain.Entities.Movement Build()
        {
            Domain.Entities.Movement movement = new(Type, Value, Balance, Account);
            return movement;
        }

        public MovementDataBuilder WithType(Entities.Movement.MovementType type)
        {
            Type = type;
            return this;
        }

        public MovementDataBuilder WithValue(int value)
        {
            Value = value;
            return this;
        }

        public MovementDataBuilder WithBalance(int balance)
        {
            Balance = balance;
            return this;
        }

        public MovementDataBuilder WithAccount(Domain.Entities.Account account)
        {
            Account = account;
            return this;
        }
    }

}
