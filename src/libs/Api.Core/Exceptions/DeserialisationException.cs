using System;

namespace Api.Core.Exceptions
{
    public class DeserialisationException : Exception
    {
        public DeserialisationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DeserialisationException(string message)
            : base(message)
        {
        }

        public DeserialisationException()
        {
        }
    }
}
