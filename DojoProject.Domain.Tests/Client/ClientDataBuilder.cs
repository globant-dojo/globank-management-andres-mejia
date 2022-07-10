using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Tests.Client
{
    public class ClientDataBuilder
    {
        bool State = default!;
        string Name = default!;
        Entities.Client.GenderType Gender = default!;
        string Age = default!;
        string Identification = default!;
        string Address = default!;
        string Password = default!;


        public Entities.Client Build()
        {
            Entities.Client Client = new(Password, State, Name, Gender, Age, Identification, Address);
            return Client;
        }

        public ClientDataBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public ClientDataBuilder WithState(bool state)
        {
            State = state;
            return this;
        }

        public ClientDataBuilder WithGender(Entities.Client.GenderType gender)
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


    }

}
