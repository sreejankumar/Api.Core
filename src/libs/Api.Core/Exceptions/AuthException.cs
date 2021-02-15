using System;

namespace Api.Core.Exceptions
{
    public class AuthException : Exception
    {
        public AuthException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
