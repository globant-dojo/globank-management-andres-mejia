using DojoProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DojoProject.Domain.Entities.Account;

namespace DojoProject.Application.Account.Dtos
{
    public class AccountDto
    {
        public AccountDto()
        {
        }

        public int Account_Number { get; set; }
        public AccountType Type { get; set; }
        public int Initial_Balance { get; set; } = 0;
        public bool State { get; set; } = true;

        public Domain.Entities.Client Client { get; set; }



    }
}
