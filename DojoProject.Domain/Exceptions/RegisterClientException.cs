using DojoProject.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Exceptions
{
    public class RegisterClientException : AppException
    {
        public RegisterClientException()
        {
        }

        public RegisterClientException(string message) : base(message)
        {
        }

        public RegisterClientException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected RegisterClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
