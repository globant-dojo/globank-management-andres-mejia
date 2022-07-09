using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Tests.Client
{
    public class ClientDataBuilder
    {
        string Name = default!;
        string Gender = default!;
        string Age = default!;
        string Identification = default!;
        string Address = default!;
        string Phone = default!;


        public object Build()
        {
            object Client = default!;
            return Client;
        }

        public ClientDataBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public ClientDataBuilder WithGender(string gender)
        {
            Gender = gender;
            return this;
        }

        public ClientDataBuilder WithAge(string age)
        {
            Age = age;
            return this;
        }

        public ClientDataBuilder WithIdentification(string identification)
        {
            Identification = identification;
            return this;
        }

        public ClientDataBuilder WithAddress(string address)
        {
            Address = address;
            return this;
        }

        public ClientDataBuilder WithPhone(string phone)
        {
            Phone = phone;
            return this;
        }
    }

}
