using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NCR.Exceptions
{
    public class RuleComputeException : Exception
    {
        public RuleComputeException()
        {
        }

        public RuleComputeException(string message) : base(message)
        {
        }

        public RuleComputeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RuleComputeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
