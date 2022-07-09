using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Tests.Account
{
    public class AccountDataBuilder
    {
        int Account_Number = default!;
        string Type = default!;
        int Initial_Balance = default!;
        bool State = default!;

        public object Build()
        {
            object Account = default!;
            return Account;
        }

        public AccountDataBuilder WithAccount_Number(int account_Number)
        {
            Account_Number = account_Number;
            return this;
        }

        public AccountDataBuilder WithType(string type)
        {
            Type = type;
            return this;
        }

        public AccountDataBuilder WithInitial_Balance(int initial_Balance)
        {
            Initial_Balance = initial_Balance;
            return this;
        }

        public AccountDataBuilder WithState(bool state)
        {
            State = state;
            return this;
        }

    }

}
