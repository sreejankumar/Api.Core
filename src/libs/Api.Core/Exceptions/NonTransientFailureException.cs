using System;

namespace Api.Core.Exceptions
{
    public class NonTransientFailureException: Exception
    {
        public NonTransientFailureException(string message, Exception ex) : base(message, ex)
        {

        }
        public NonTransientFailureException(string message) : base(message)
        {

        }
    }
}
