using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterLibrary
{
    public class LessThanOneWordException : Exception
    {
        public LessThanOneWordException()
        {
        }

        public LessThanOneWordException(string message) 
                : base(message)
        {
        }

        public LessThanOneWordException(string message, Exception innerException) 
                : base(message, innerException)
        {
        }

        protected LessThanOneWordException(SerializationInfo info, StreamingContext context) 
                : base(info, context)
        {
        }
    }
}
