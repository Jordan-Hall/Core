using System;
using System.Runtime.Serialization;

namespace JordanHall.IbmClassifierService.Exception
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
