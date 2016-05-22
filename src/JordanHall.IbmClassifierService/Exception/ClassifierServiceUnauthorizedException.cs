using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace JordanHall.ClassifierService.Exception
{
    public class ClassifierServiceUnauthorizedException : UnauthorizedAccessException
    {
        public ClassifierServiceUnauthorizedException()
        {
        }

        public ClassifierServiceUnauthorizedException(string message) : base(message)
        {
        }

        public ClassifierServiceUnauthorizedException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected ClassifierServiceUnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
