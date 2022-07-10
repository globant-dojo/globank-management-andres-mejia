using DojoProject.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Exceptions
{
    public class RegisterAccountException : AppException
    {
        public RegisterAccountException()
        {
        }

        public RegisterAccountException(string message) : base(message)
        {
        }

        public RegisterAccountException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected RegisterAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
