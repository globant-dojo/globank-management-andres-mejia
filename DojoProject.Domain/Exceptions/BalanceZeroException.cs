using DojoProject.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Exceptions
{
    public class BalanceZeroException : AppException
    {
        public BalanceZeroException()
        {
        }

        public BalanceZeroException(string message) : base(message)
        {
        }

        public BalanceZeroException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected BalanceZeroException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
