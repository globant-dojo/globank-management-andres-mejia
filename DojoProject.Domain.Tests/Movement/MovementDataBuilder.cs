using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Tests.Movement
{

    public class MovementDataBuilder
    {
        string Type = default!;
        int Value = default!;
        int Balance = default!;

        public object Build()
        {
            object Movement = default!;
            return Movement;
        }

        public MovementDataBuilder WithType(string type)
        {
            Type = type;
            return this;
        }

        public MovementDataBuilder WithValue(int value)
        {
            Value = value;
            return this;
        }

        public MovementDataBuilder WithValance(int valance)
        {
            Balance = valance;
            return this;
        }
    }

}
