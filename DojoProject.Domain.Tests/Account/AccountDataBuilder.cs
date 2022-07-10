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
        Entities.Account.AccountType Type = default!;
        int Initial_Balance = default!;
        bool State = default!;
        Entities.Client Client = default!;

        public Entities.Account Build()
        {
            Entities.Account Account = new(Account_Number,Type,Initial_Balance,State);
            return Account;
        }

        public AccountDataBuilder WithAccount_Number(int account_Number)
        {
            Account_Number = account_Number;
            return this;
        }

        public AccountDataBuilder WithType(Entities.Account.AccountType type)
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

        public AccountDataBuilder WithClient(Entities.Client client)
        {
            Client = client;
            return this;
        }

    }

}
