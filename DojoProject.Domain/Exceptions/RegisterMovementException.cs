using DojoProject.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Exceptions
{
    public class RegisterMovementException : AppException
    {
        public RegisterMovementException()
        {
        }

        public RegisterMovementException(string message) : base(message)
        {
        }

        public RegisterMovementException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected RegisterMovementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
